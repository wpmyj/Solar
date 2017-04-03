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
			public int BaudRate;            // ָ����ǰ������ current baud rate
			// these are the c struct bit fields, bit twiddle flag to set
			public int fBinary;          // ָ���Ƿ����������ģʽ,��windows95�б�����TRUE binary mode, no EOF check 
			public int fParity;          // ָ���Ƿ�������żУ�� enable parity checking 
			public int fOutxCtsFlow;      // ָ��CTS�Ƿ����ڼ�ⷢ�Ϳ��ƣ���ΪTRUE��CTSΪOFF�����ͽ������� CTS output flow control 
			public int fOutxDsrFlow;      // ָ��CTS�Ƿ����ڼ�ⷢ�Ϳ��� DSR output flow control 
			public int fDtrControl;       // DTR_CONTROL_DISABLEֵ��DTR��ΪOFF, DTR_CONTROL_ENABLEֵ��DTR��ΪON, DTR_CONTROL_HANDSHAKE����DTR"����" DTR flow control type 
			public int fDsrSensitivity;   // ����ֵΪTRUEʱDSRΪOFFʱ���յ��ֽڱ����� DSR sensitivity 
			public int fTXContinueOnXoff; // ָ�������ջ���������,�������������Ѿ����ͳ�XoffChar�ַ�ʱ�����Ƿ�ֹͣ��TRUEʱ���ڽ��ջ��������յ��������������ֽ�XoffLim�����������Ѿ����ͳ�XoffChar�ַ���ֹ�����ֽ�֮�󣬷��ͼ������С���FALSEʱ���ڽ��ջ��������յ����������ѿյ��ֽ�XonChar�����������Ѿ����ͳ��ָ����͵�XonChar֮�󣬷��ͼ������С�XOFF continues Tx 
			public int fOutX;          // TRUEʱ�����յ�XoffChar֮���ֹͣ���ͽ��յ�XonChar֮�����¿�ʼ XON/XOFF out flow control 
			public int fInX;           // TRUEʱ�����ջ��������յ�������������XoffLim֮��XoffChar���ͳ�ȥ���ջ��������յ����������յ�XonLim֮��XonChar���ͳ�ȥ XON/XOFF in flow control 
			public int fErrorChar;     // ��ֵΪTRUE��fParityΪTRUEʱ����ErrorChar ��Աָ�����ַ�������żУ�����Ľ����ַ� enable error replacement 
			public int fNull;          // eTRUEʱ������ʱȥ���գ�0ֵ���ֽ� enable null stripping 
			public int fRtsControl;     // RTS flow control 
											/*RTS_CONTROL_DISABLEʱ,RTS��ΪOFF
			��								RTS_CONTROL_ENABLEʱ, RTS��ΪON
����										RTS_CONTROL_HANDSHAKEʱ,
����										�����ջ�����С�ڰ���ʱRTSΪON
��			��								�����ջ����������ķ�֮����ʱRTSΪOFF
����										RTS_CONTROL_TOGGLEʱ,
����										�����ջ���������ʣ���ֽ�ʱRTSΪON ,����ȱʡΪOFF*/

			public int fAbortOnError;   // TRUEʱ,�д�����ʱ��ֹ����д���� abort on error 
			public int fDummy2;        // δʹ�� reserved 
			
			public uint flags;
			public ushort wReserved;          // δʹ��,����Ϊ0 not currently used 
			public ushort XonLim;             // ָ����XON�ַ�������ǰ���ջ������п��������С�ֽ��� transmit XON threshold 
			public ushort XoffLim;            // ָ����XOFF�ַ�������ǰ���ջ������п��������С�ֽ��� transmit XOFF threshold 
			public byte ByteSize;           // ָ���˿ڵ�ǰʹ�õ�����λ	number of bits/byte, 4-8 
			public byte Parity;             // ָ���˿ڵ�ǰʹ�õ���żУ�鷽��,����Ϊ:EVENPARITY,MARKPARITY,NOPARITY,ODDPARITY  0-4=no,odd,even,mark,space 
			public byte StopBits;           // ָ���˿ڵ�ǰʹ�õ�ֹͣλ��,����Ϊ:ONESTOPBIT,ONE5STOPBITS,TWOSTOPBITS  0,1,2 = 1, 1.5, 2 
			public char XonChar;            // ָ�����ڷ��ͺͽ����ַ�XON��ֵ Tx and Rx XON character 
			public char XoffChar;           // ָ�����ڷ��ͺͽ����ַ�XOFFֵ Tx and Rx XOFF character 
			public char ErrorChar;          // ���ַ�����������յ�����żУ�鷢������ʱ��ֵ error replacement character 
			public char EofChar;            // ��û��ʹ�ö�����ģʽʱ,���ַ�������ָʾ���ݵĽ��� end of input character 
			public char EvtChar;            // �����յ����ַ�ʱ,�����һ���¼� received event character 
			public ushort wReserved1;         // δʹ�� reserved; do not use 
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
		  string lpFileName,                         // Ҫ�򿪵Ĵ�������
		  uint dwDesiredAccess,                      // ָ�����ڵķ��ʷ�ʽ��һ������Ϊ�ɶ���д��ʽ
		  int dwShareMode,                          // ָ�����ڵĹ���ģʽ�����ڲ��ܹ�����������Ϊ0
		  int lpSecurityAttributes, // ���ô��ڵİ�ȫ���ԣ�WIN9X�²�֧�֣�Ӧ��ΪNULL
		  int dwCreationDisposition,                // ���ڴ���ͨ�ţ�������ʽֻ��ΪOPEN_EXISTING
		  int dwFlagsAndAttributes,                 // ָ�������������־������ΪFILE_FLAG_OVERLAPPED(�ص�I/O����)��ָ���������첽��ʽͨ��
		  int hTemplateFile                        // ���ڴ���ͨ�ű�������ΪNULL
		);
		[DllImport("kernel32.dll")]
		private static extern bool GetCommState(
		  int hFile,  //ͨ���豸���
		  ref DCB lpDCB    // �豸���ƿ�DCB
		);	
		[DllImport("kernel32.dll")]
		private static extern bool BuildCommDCB(
		  string lpDef,  // �豸�����ַ���
		  ref DCB lpDCB     // �豸���ƿ�
		);
		[DllImport("kernel32.dll")]
		private static extern bool SetCommState(
		  int hFile,  // ͨ���豸���
		  ref DCB lpDCB    // �豸���ƿ�
		);
		[DllImport("kernel32.dll")]
		private static extern bool GetCommTimeouts(
		  int hFile,                  // ͨ���豸��� handle to comm device
		  ref COMMTIMEOUTS lpCommTimeouts  // ��ʱʱ�� time-out values
		);	
		[DllImport("kernel32.dll")]	
		private static extern bool SetCommTimeouts(
		  int hFile,                  // ͨ���豸��� handle to comm device
		  ref COMMTIMEOUTS lpCommTimeouts  // ��ʱʱ�� time-out values
		);
		[DllImport("kernel32.dll")]
		private static extern bool ReadFile(
		  int hFile,                // ͨ���豸��� handle to file
		  byte[] lpBuffer,             // ���ݻ����� data buffer
		  int nNumberOfBytesToRead,  // �����ֽڵȴ���ȡ number of bytes to read
		  ref int lpNumberOfBytesRead, // ��ȡ�����ֽ� number of bytes read
		  ref OVERLAPPED lpOverlapped    // ��������� overlapped buffer
		);
		[DllImport("kernel32.dll")]	
		private static extern bool WriteFile(
		  int hFile,                    // ͨ���豸��� handle to file
		  byte[] lpBuffer,                // ���ݻ����� data buffer
		  int nNumberOfBytesToWrite,     // �����ֽڵȴ�д�� number of bytes to write
		  ref int lpNumberOfBytesWritten,  // �Ѿ�д������ֽ� number of bytes written
		  ref OVERLAPPED lpOverlapped        // ��������� overlapped buffer
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
		 	 
			 // �򿪴��� OPEN THE COMM PORT.
            hComm = CreateFile(PortNum ,GENERIC_READ | GENERIC_WRITE,0, 0,OPEN_EXISTING,0,0);
			 // �������û�д򿪣��ʹ� IF THE PORT CANNOT BE OPENED, BAIL OUT.
			if(hComm == INVALID_HANDLE_VALUE) 
			{
		  		throw(new ApplicationException("�Ƿ����������ܴ򿪴��ڣ�"));
			}
		
			// ����ͨ�ų�ʱʱ�� SET THE COMM TIMEOUTS.
			GetCommTimeouts(hComm,ref ctoCommPort);
			ctoCommPort.ReadTotalTimeoutConstant = ReadTimeout;
			ctoCommPort.ReadTotalTimeoutMultiplier = 0;
			ctoCommPort.WriteTotalTimeoutMultiplier = 0;
			ctoCommPort.WriteTotalTimeoutConstant = 0;  
			SetCommTimeouts(hComm,ref ctoCommPort);
		
			// ���ô��� SET BAUD RATE, PARITY, WORD SIZE, AND STOP BITS.
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
		     throw(new ApplicationException("�Ƿ����������ܴ򿪴��ڣ�"));
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
				throw(new ApplicationException("����δ�򿪣�"));
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
				throw(new ApplicationException("����δ�򿪣�"));
			}		
		}
	}

	class HexCon {
	// ��ʮ�������ַ���ת�����ֽ��ͺͰ��ֽ���ת����ʮ�������ַ��� converter hex string to byte and byte to hex string
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