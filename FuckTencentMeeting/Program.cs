using FuckTencentMeeting;
using System.Diagnostics;

Console.WriteLine("输入一下会议号？ ");
string meetingId = Console.ReadLine(); //会议号

Console.WriteLine("输入一下预定时间？(天/小时/分钟)  ");
string reserveTime = Console.ReadLine(); //预定时间

string now;

while (true)
{
    now = DateTime.Now.ToString("HH/mm"); //注意格式：小时/分钟，删除了输入麻烦的日期

    if (reserveTime == now)
    {
        Console.WriteLine($"已经到达指定时间({reserveTime})，正在启动腾讯会议");
        Start(meetingId);
        break;
    }
}

void Start(string meetingId)
{
    //这里改成自己的安装路径
    try
    {
        Process.Start("E:\\Tencent Room\\WeMeet\\wemeetapp.exe");
    }
    catch (Exception e)
    {
        Console.WriteLine(e);
        throw;
    }

    Thread.Sleep(3800); //单位为毫秒

    Win32Method.LeftMouseClick(820, 319);
    Thread.Sleep(500);

    Win32Method.KeyInput(meetingId);
    Thread.Sleep(500);

    Win32Method.LeftMouseClick(959, 813);
    Console.WriteLine("成功加入会议");
}