#define APPNAME "iSmartOffGrid"
#define APPEXE "iSmartOffGrid.exe"
#define APPDESKTOPNAME "iSmartOffGrid"
;文件路径
#define APPDIR "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\"
;版本号
#define APPVERSION "2.6.1.0"  
;输出安装文件名称
#define OutputBaseFilename "setup_v2.6.1"  
;输出文件夹
#define OutputDir "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\release"
;开始菜单栏分组名称
#define DefaultGroupName "iSmartOffGrid"
;安装目录

[Setup]
; 注意: AppId 值用于唯一识别该应用程序。
; 禁止对其他应用程序的安装器使用相同的 AppId 值！
; (若要生成一个新的 GUID，请选择“工具 | 生成 GUID”。)
AppId={{7CC5E20A-8572-4D6E-919A-FDAB6331D0BB}
AppName={#APPNAME}
AppVerName={#APPNAME}
VersionInfoVersion={#APPVERSION}
AppPublisher=IDBK
;DefaultDirName={pf}\{#APPNAME}
;直接安装到C盘根目录
DefaultDirName=C:\{#APPNAME}
;不要使用以前的安装路径
UsePreviousAppDir=false
DefaultGroupName={#DefaultGroupName}
OutputDir={#OutputDir}
OutputBaseFilename={#OutputBaseFilename}
Compression=lzma
SolidCompression=yes

[Languages]
Name: "chinese"; MessagesFile: "compiler:Default.isl"
Name: "english"; MessagesFile: "compiler:Languages\English.isl"
[CustomMessages]
chinese.uninstall=Monitoring program is running, click "Yes" to terminate the monitoring program and uninstall; click "No" to exit the uninstall.
chinese.deletedata=Do you want to delete a user profile and data?
chinese.isinstall=The software is already installed on the machine. % n Click "Yes" means unloading and reloading; click "No" means to terminate the installation.
chinese.isrunning=Monitoring program is running, click "Yes" to terminate the monitoring program and continue the installation; click "No" to exit the installation.

[Tasks]
   Name: "desktopicon"; Description: "{cm:CreateDesktopIcon}"; GroupDescription: "{cm:AdditionalIcons}"; Flags: unchecked
[Files]
; 注意: 不要在任何共享系统文件上使用“Flags: ignoreversion”
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\ACCESSDBDAL.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\ACCESSDBDAL.pdb"; DestDir: "{app}"; Flags: ignoreversion

Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\Communication.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\Communication.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.Charts.v11.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.Data.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.Data.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.Printing.v11.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.Utils.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.Utils.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraBars.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraBars.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraCharts.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraCharts.v11.1.UI.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraCharts.v11.1.UI.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraCharts.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraEditors.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraEditors.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraGauges.v11.1.Core.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraGauges.v11.1.Core.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraGauges.v11.1.Win.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraGauges.v11.1.Win.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraGrid.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraGrid.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraLayout.v11.1.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DevExpress.XtraLayout.v11.1.xml"; DestDir: "{app}"; Flags: ignoreversion


Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmart.mdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmart.vshost.exe.Config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.vshost.exe"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.vshost.exe.config"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\iSmartOffGrid.vshost.exe.manifest"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\MathConvertHelper.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\MathConvertHelper.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\Model_Data.dll"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\Model_Data.pdb"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\schedule.xml"; DestDir: "{app}"; Flags: ignoreversion
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\scheduleTask.xml"; DestDir: "{app}"; Flags: ignoreversion

Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\CN.xml"; DestDir: "{app}"; Flags: ignoreversion ; Languages: chinese
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DeviceCN.xml"; DestDir: "{app}"; Flags: ignoreversion ; Languages: chinese
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DeviceEN.xml"; DestDir: "{app}"; Flags: ignoreversion ; Languages: english
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DocCN.chm"; DestDir: "{app}"; Flags: ignoreversion ; Languages: chinese
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\DocEn.chm"; DestDir: "{app}"; Flags: ignoreversion ; Languages: english
Source: "E:\需要维护的软件\offgrid\2.0标准版本\OF2.0\SolarMonitor\bin\Debug\EN.xml"; DestDir: "{app}"; Flags: ignoreversion ; Languages: english
[Code]
const
WM_CLOSE = 16;    //应用程序收到本消息后会 有退出判断
WM_DESTROY = 2;   //

//检查.net2.0是否已经安装
function CheckDotNet2_0():boolean;
begin
  Result:=not RegKeyExists(HKLM, 'SOFTWARE\Microsoft\NET Framework Setup\NDP\v2.0.50727');
end;

//检查程序是否已经安装
function GetUninstallString: string;
var
  sUnInstPath: string;
  sUnInstallString: String;
begin
  Result := '';
  sUnInstPath := ExpandConstant('Software\Microsoft\Windows\CurrentVersion\Uninstall\{{7CC5E20A-8572-4D6E-919A-FDAB6331D0BB}_is1'); //Your App GUID/ID
  sUnInstallString := '';
  if not RegQueryStringValue(HKLM, sUnInstPath, 'UninstallString', sUnInstallString) then
    RegQueryStringValue(HKCU, sUnInstPath, 'UninstallString', sUnInstallString);
  Result := sUnInstallString;
end;

//获取 窗体 句柄
function GetAppHandle():longint;
var 
  strProg : string;
  winHwnd : longint;
begin
   strProg := 'iSmartOffGrid';
   winHwnd := FindWindowByWindowName(strProg);
   Result :=  winHwnd;
end;

//检查程序是否已经运行
function CheckAppRunnging():boolean;
var 
  winHwnd : longint;
begin
    winHwnd := GetAppHandle(); 
    if winHwnd<>0 then
      begin
        Result:= true;
      end
    else
      Result:= false;
end;

{-----------------以上是工具函数--------------------------------------}

{-----------------以下是执行函数--------------------------------------}

//安装前 
function InitializeSetup(): Boolean;
var     Path:string;
        ResultCode: Integer;
        Return20: Boolean;
        MsgResult :Integer;
        strProg: string;
        winHwnd: longint;
        sUnInstallString: string;
        retVal: boolean;
begin
    Result := true;
    //step1:检查框架
    if CheckDotNet2_0() then
    begin
      MsgBox('Monitoring software needed for the operation .NET2.0 frame, install this frame.',mbInformation,MB_OK);      
      Result:=  false;
      Exit;
    end
    //step2:检查 程序是否已经运行
    if CheckAppRunnging() then
    begin
      MsgResult := MsgBox(ExpandConstant('{cm:isrunning}'), mbConfirmation, MB_YESNO);
      if MsgResult = IDNO then
      begin
         Result:= false;
         Exit;
      end 
      else
        begin
          winHwnd := GetAppHandle();
          retVal:=postmessage(winHwnd,WM_DESTROY,0,0);
        end
    end
    //step3:检查 程序是否已经卸载  
    if RegValueExists(HKEY_LOCAL_MACHINE,'Software\Microsoft\Windows\CurrentVersion\Uninstall\{7CC5E20A-8572-4D6E-919A-FDAB6331D0BB}_is1', 'UninstallString') then  //Your App GUID/ID  
    begin
      MsgResult := MsgBox(ExpandConstant('{cm:isinstall}'), mbConfirmation, MB_YESNO);
      if MsgResult = IDNO then
      begin
        Result:= false;
        Exit;
      end
      else
      begin
        sUnInstallString := GetUninstallString();
        sUnInstallString :=  RemoveQuotes(sUnInstallString);
        Exec(ExpandConstant(sUnInstallString), '', '', SW_SHOW, ewWaitUntilTerminated, ResultCode);
        Result := True; //if you want to proceed after uninstall
                //Exit; //if you want to quit after uninstall
      end
    end  
end;

//卸载前 保证程序不是运行状态(如果在运行，则终止程序)
function InitializeUninstall(): Boolean;
var winHwnd: longint;
    strProg: string;
    retVal : boolean;
begin 
  //Either use FindWindowByClassName. ClassName can be found with Spy++ included with Visual C++. 
  strProg := 'iSmartOffGrid';
  winHwnd := FindWindowByWindowName(strProg);
  //Or FindWindowByWindowName.  If using by Name, the name must be exact and is case sensitive.
  //strProg := 'Untitled - Notepad';
  //winHwnd := FindWindowByWindowName(strProg);
  //如果在运行，则让用户进行选择
  if winHwnd <> 0 then
    begin
      if MsgBox(ExpandConstant('{cm:uninstall}'), mbConfirmation, MB_YESNO) = IDNO then
        begin
           Result := False;
        end
      else
        begin
          retVal:=postmessage(winHwnd,WM_DESTROY,0,0);
          if retVal then
            Result := True
          else
            Result := False;
        end
    end   
  else
    Result := True
end;

//卸载后 删除数据文件
//usUninstall开始卸载,usPostUninstall卸载完成
procedure CurUninstallStepChanged(CurUninstallStep: TUninstallStep);
begin
if CurUninstallStep = usPostUninstall then
  begin
    if MsgBox(ExpandConstant('{cm:deletedata}'), mbConfirmation, MB_YESNO) = IDYES then
        //删除 {app} 文件夹及其中所有文件
      DelTree(ExpandConstant('{app}'), True, True, True);
      //DelTree(ExpandConstant('{commonappdata}\iSmartView'), True, True, True);
  end;
end;


[Icons]
Name: "{group}\{#APPDESKTOPNAME}"; Filename: "{app}\{#APPEXE}"
Name: "{group}\{cm:UninstallProgram,{#APPNAME}}"; Filename: "{uninstallexe}"
Name: "{commondesktop}\{#APPDESKTOPNAME}"; Filename: "{app}\{#APPEXE}"; Tasks: desktopicon

[Run]
Filename: "{app}\{#APPEXE}"; Description: "{cm:LaunchProgram,{#APPNAME}}"; Flags:shellexec nowait postinstall skipifsilent unchecked

