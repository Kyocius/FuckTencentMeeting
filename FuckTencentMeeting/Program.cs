using FuckTencentMeeting;
using System.Diagnostics;
using WindowsInput;

Console.WriteLine("会议号？ ");
string code = Console.ReadLine(); //会议号
Console.WriteLine("预定时间？(天数/小时/分钟)  ");
string now = Console.ReadLine(); //预定时间

var dateTime = DateTime.Now.ToString("dd/H/m");

while (true)
{
    dateTime = DateTime.Now.ToString("dd/H/m");
    Console.WriteLine(dateTime);

    if (now == dateTime)
    {
        Start(code);
        break;
    }
}

void Start(string code)
{
    //这里改成自己的安装路径
    Process.Start("E:\\Tencent Room\\WeMeet\\wemeetapp.exe");
    Thread.Sleep(3000);

    Win32Method.LeftMouseClick(820, 319);
    Thread.Sleep(500);

    new InputSimulator().Keyboard.TextEntry(code);
    Thread.Sleep(1000);

    Win32Method.LeftMouseClick(959, 813);
    Console.WriteLine("入会成功了吧");
}