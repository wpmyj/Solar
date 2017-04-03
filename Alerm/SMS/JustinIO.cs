using System;
using System.Runtime.InteropServices;

namespace JustinIO {
	class CommPort {

		public string PortNum; 
		public int BaudRate;
		public byte ByteSize;
		public byte Parity; // 0-4=no,odd,even,mark,space 
		public byte StopBits; // 0,1,2 = 1, 1.5, 2 
		public int ReadTimeout;
		
		//comm port win32 file handle
		private int hComm = -1;
		
		public bool Opened = false;
		 
		//win32 api constants
		  private const uint GENERIC_READ = 0x80000000;
		  private const uint GENERIC_WRITE = 0x40000000;
		  private const int OPEN_EXISTING = 3;		
		  private const int INVALID_HANDLE_VALUE = -1;
		
		[StructLayout(LayoutKind.Sequential)]
		public struct DCB {
			//taken from c struct in platform sdk 
			public int DCBlength;           // sizeof(DCB) 
			public int BaudRate;            // 指定当前波特率 current baud rate
			// these are the c struct bit fields, bit twiddle flag to set
			public int fBinary;          // 指定是否允许二进制模式,在windows95中必须主TRUE binary mode, no EOF check 
			public int fParity;          // 指定是否允许奇偶校验 enable parity checking 
			public int fOutxCtsFlow;      // 指定CTS是否用于检测发送控制，当为TRUE是CTS为OFF，发送将被挂起。 CTS output flow control 
			public int fOutxDsrFlow;      // 指定CTS是否用于检测发送控制 DSR output flow control 
			public int fDtrControl;       // DTR_CONTROL_DISABLE值将DTR置为OFF, DTR_CONTROL_ENABLE值将DTR置为ON, DTR_CONTROL_HANDSHAKE允许DTR"握手" DTR flow control type 
			public int fDsrSensitivity;   // 当该值为TRUE时DSR为OFF时接收的字节被忽略 DSR sensitivity 
			public int fTXContinueOnXoff; // 指定当接收缓冲区已满,并且驱动程序已经发送出XoffChar字符时发送是否停止。TRUE时，在接收缓冲区接收到缓冲区已满的字节XoffLim且驱动程序已经发送出XoffChar字符中止接收字节之后，发送继续进行。　FALSE时，在接收缓冲区接收到代表缓冲区已空的字节XonChar且驱动程序已经发送出恢复发送的XonChar之后，发送继续进行。XOFF continues Tx 
			public int fOutX;          // TRUE时，接收到XoffChar之后便停止发送接收到XonChar之后将重新开始 XON/XOFF out flow control 
			public int fInX;           // TRUE时，接收缓冲区接收到代表缓冲区满的XoffLim之后，XoffChar发送出去接收缓冲区接收到代表缓冲区空的XonLim之后，XonChar发送出去 XON/XOFF in flow control 
			public int fErrorChar;     // 该值为TRUE且fParity为TRUE时，用ErrorChar 成员指定的字符代替奇偶校验错误的接收字符 enable error replacement 
			public int fNull;          // eTRUE时，接收时去掉空（0值）字节 enable null stripping 
			public int fRtsControl;     // RTS flow control 
											/*RTS_CONTROL_DISABLE时,RTS置为OFF
			　								RTS_CONTROL_ENABLE时, RTS置为ON
　　										RTS_CONTROL_HANDSHAKE时,
　　										当接收缓冲区小于半满时RTS为ON
　			　								当接收缓冲区超过四分之三满时RTS为OFF
　　										RTS_CONTROL_TOGGLE时,
　　										当接收缓冲区仍有剩余字节时RTS为ON ,否则缺省为OFF*/

			public int fAbortOnError;   // TRUE时,有错误发生时中止读和写操作 abort on error 
			public int fDummy2;        // 未使用 reserved 
			
			public uint flags;
			public ushort wReserved;          // 未使用,必须为0 not currently used 
			public ushort XonLim;             // 指定在XON字符发送这前接收缓冲区中可允许的最小字节数 transmit XON threshold 
			public ushort XoffLim;            // 指定在XOFF字符发送这前接收缓冲区中可允许的最小字节数 transmit XOFF threshold 
			public byte ByteSize;           // 指定端口当前使用的数据位	number of bits/byte, 4-8 
			public byte Parity;             // 指定端口当前使用的奇偶校验方法,可能为:EVENPARITY,MARKPARITY,NOPARITY,ODDPARITY  0-4=no,odd,even,mark,space 
			public byte StopBits;           // 指定端口当前使用的停止位数,可能为:ONESTOPBIT,ONE5STOPBITS,TWOSTOPBITS  0,1,2 = 1, 1.5, 2 
			public char XonChar;            // 指定用于发送和接收字符XON的值 Tx and Rx XON character 
			public char XoffChar;           // 指定用于发送和接收字符XOFF值 Tx and Rx XOFF character 
			public char ErrorChar;          // 本字符用来代替接收到的奇偶校验发生错误时的值 error replacement character 
			public char EofChar;            // 当没有使用二进制模式时,本字符可用来指示数据的结束 end of input character 
			public char EvtChar;            // 当接收到此字符时,会产生一个事件 received event character 
			public ushort wReserved1;         // 未使用 reserved; do not use 
		}

		[StructLayout(LayoutKind.Sequential)]
		private struct COMMTIMEOUTS {  
		  public int ReadIntervalTimeout; 
		  public int ReadTotalTimeoutMultiplier; 
		  public int ReadTotalTimeoutConstant; 
		  public int WriteTotalTimeoutMultiplier; 
		  public int WriteTotalTimeoutConstant; 
		} 	

		[StructLayout(LayoutKind.Sequential)]	
		private struct OVERLAPPED { 
		    public int  Internal; 
		    public int  InternalHigh; 
		    public int  Offset; 
		    public int  OffsetHigh; 
		    public int hEvent; 
		}  
		
		[DllImport("kernel32.dll")]
		private static extern int CreateFile(
		  string lpFileName,                         // 要打开的串口名称
		  uint dwDesiredAccess,                      // 指定串口的访问方式，一般设置为可读可写方式
		  int dwShareMode,                          // 指定串口的共享模式，串口不能共享，所以设置为0
		  int lpSecurityAttributes, // 设置串口的安全属性，WIN9X下不支持，应设为NULL
		  int dwCreationDisposition,                // 对于串口通信，创建方式只能为OPEN_EXISTING
		  int dwFlagsAndAttributes,                 // 指定串口属性与标志，设置为FILE_FLAG_OVERLAPPED(重叠I/O操作)，指定串口以异步方式通信
		  int hTemplateFile                        // 对于串口通信必须设置为NULL
		);
		[DllImport("kernel32.dll")]
		private static extern bool GetCommState(
		  int hFile,  //通信设备句柄
		  ref DCB lpDCB    // 设备控制块DCB
		);	
		[DllImport("kernel32.dll")]
		private static extern bool BuildCommDCB(
		  string lpDef,  // 设备控制字符串
		  ref DCB lpDCB     // 设备控制块
		);
		[DllImport("kernel32.dll")]
		private static extern bool SetCommState(
		  int hFile,  // 通信设备句柄
		  ref DCB lpDCB    // 设备控制块
		);
		[DllImport("kernel32.dll")]
		private static extern bool GetCommTimeouts(
		  int hFile,                  // 通信设备句柄 handle to comm device
		  ref COMMTIMEOUTS lpCommTimeouts  // 超时时间 time-out values
		);	
		[DllImport("kernel32.dll")]	
		private static extern bool SetCommTimeouts(
		  int hFile,                  // 通信设备句柄 handle to comm device
		  ref COMMTIMEOUTS lpCommTimeouts  // 超时时间 time-out values
		);
		[DllImport("kernel32.dll")]
		private static extern bool ReadFile(
		  int hFile,                // 通信设备句柄 handle to file
		  byte[] lpBuffer,             // 数据缓冲区 data buffer
		  int nNumberOfBytesToRead,  // 多少字节等待读取 number of bytes to read
		  ref int lpNumberOfBytesRead, // 读取多少字节 number of bytes read
		  ref OVERLAPPED lpOverlapped    // 溢出缓冲区 overlapped buffer
		);
		[DllImport("kernel32.dll")]	
		private static extern bool WriteFile(
		  int hFile,                    // 通信设备句柄 handle to file
		  byte[] lpBuffer,                // 数据缓冲区 data buffer
		  int nNumberOfBytesToWrite,     // 多少字节等待写入 number of bytes to write
		  ref int lpNumberOfBytesWritten,  // 已经写入多少字节 number of bytes written
		  ref OVERLAPPED lpOverlapped        // 溢出缓冲区 overlapped buffer
		);
		[DllImport("kernel32.dll")]
		private static extern bool CloseHandle(
		  int hObject   // handle to object
		);
		[DllImport("kernel32.dll")]
		private static extern uint GetLastError();
		
		public void Open()
		{
		
            DCB dcbCommPort = new DCB();
            COMMTIMEOUTS ctoCommPort = new COMMTIMEOUTS();	
		 	 
			 // 打开串口 OPEN THE COMM PORT.
            hComm = CreateFile(PortNum ,GENERIC_READ | GENERIC_WRITE,0, 0,OPEN_EXISTING,0,0);
			 // 如果串口没有打开，就打开 IF THE PORT CANNOT BE OPENED, BAIL OUT.
			if(hComm == INVALID_HANDLE_VALUE) 
			{
		  		throw(new ApplicationException("非法操作，不能打开串口！"));
			}
		
			// 设置通信超时时间 SET THE COMM TIMEOUTS.
			GetCommTimeouts(hComm,ref ctoCommPort);
			ctoCommPort.ReadTotalTimeoutConstant = ReadTimeout;
			ctoCommPort.ReadTotalTimeoutMultiplier = 0;
			ctoCommPort.WriteTotalTimeoutMultiplier = 0;
			ctoCommPort.WriteTotalTimeoutConstant = 0;  
			SetCommTimeouts(hComm,ref ctoCommPort);
		
			// 设置串口 SET BAUD RATE, PARITY, WORD SIZE, AND STOP BITS.
			GetCommState(hComm, ref dcbCommPort);
			dcbCommPort.BaudRate=BaudRate;
			dcbCommPort.flags=0;
			//dcb.fBinary=1;
			dcbCommPort.flags|=1;
			if (Parity>0)
			{
		 	  //dcb.fParity=1
		      dcbCommPort.flags|=2;
			}
			dcbCommPort.Parity=Parity;
			dcbCommPort.ByteSize=ByteSize;
			dcbCommPort.StopBits=StopBits;
			if (!SetCommState(hComm, ref dcbCommPort))
			{
			 //uint ErrorNum=GetLastError();
		     throw(new ApplicationException("非法操作，不能打开串口！"));
			}
		  //unremark to see if setting took correctly
		  //DCB dcbCommPort2 = new DCB();
		  //GetCommState(hComm, ref dcbCommPort2);
			Opened = true;
		}
		
		public void Close() {
			if (hComm!=INVALID_HANDLE_VALUE) {
				CloseHandle(hComm);
                Opened = false;
			}
		}
		
		public byte[] Read(int NumBytes) {
			byte[] BufBytes;
			byte[] OutBytes;
			BufBytes = new byte[NumBytes];
			if (hComm!=INVALID_HANDLE_VALUE) {
				OVERLAPPED ovlCommPort = new OVERLAPPED();
				int BytesRead=0;
				ReadFile(hComm,BufBytes,NumBytes,ref BytesRead,ref ovlCommPort);
				OutBytes = new byte[BytesRead];
				Array.Copy(BufBytes,OutBytes,BytesRead);
			} 
			else {
				throw(new ApplicationException("串口未打开！"));
			}
			return OutBytes;
		}
		
		public void Write(byte[] WriteBytes) {
			if (hComm!=INVALID_HANDLE_VALUE) {
				OVERLAPPED ovlCommPort = new OVERLAPPED();
				int BytesWritten = 0;
				WriteFile(hComm,WriteBytes,WriteBytes.Length,ref BytesWritten,ref ovlCommPort);
			}
			else {
				throw(new ApplicationException("串口未打开！"));
			}		
		}
	}

	class HexCon {
	// 把十六进制字符串转换成字节型和把字节型转换成十六进制字符串 converter hex string to byte and byte to hex string
		public static string ByteToString(byte[] InBytes) {
			string StringOut="";
			foreach (byte InByte in InBytes) {
				StringOut=StringOut + String.Format("{0:X2} ",InByte);
			}
			return StringOut; 
		}
		public static byte[] StringToByte(string InString) {
			string[] ByteStrings;
			ByteStrings = InString.Split(" ".ToCharArray());
			byte[] ByteOut;
			ByteOut = new byte[ByteStrings.Length-1];
			for (int i = 0;i==ByteStrings.Length-1;i++) {
				ByteOut[i] = Convert.ToByte(("0x" + ByteStrings[i]));
			} 
			return ByteOut;
		}
	}
}