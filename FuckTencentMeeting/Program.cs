using FuckTencentMeeting;
using System.Diagnostics;
using Spectre.Console;

#region 配置区域

var meetingId = AnsiConsole.Ask<string>("请输入[green]腾讯会议号[/] "); //会议号
var reserveTime = AnsiConsole.Ask<string>("请输入[green]预定时间[/] [red](小时/分钟)[/] "); //预定时间
const string path = "E:\\Tencent Room\\WeMeet\\wemeetapp.exe";
const int x1 = 820;
const int y1 = 319;
const int x2 = 959;
const int y2 = 813;
const int waitTime = 3800; //单位为毫秒
string now;

#endregion

#region 渲染表格

AnsiConsole.MarkupLine("请检查[yellow]配置[/]");

var table = new Table();
table.Border(TableBorder.Rounded);

table.AddColumn("腾讯会议安装路径");
table.AddColumn("会议号");
table.AddColumn("预定时间");
table.AddColumn("按钮1");
table.AddColumn("按钮2");
table.AddRow(path, meetingId, reserveTime, $"({x1}, {y1})", $"({x2}, {y2})");

AnsiConsole.Write(table);
AnsiConsole.MarkupLine("程序正在[green]运行[/]，等待到达指定时间...");

#endregion

while (true)
{
    now = DateTime.Now.ToString("HH/mm"); //注意格式：小时/分钟，删除了输入麻烦的日期

    if (reserveTime == now)
    {
        Start(meetingId);
        break;
    }
}

void Start(string id)
{
    AnsiConsole.MarkupLine($"已经到达[yellow]指定时间({reserveTime})[/]，正在启动[blue]腾讯会议[/]");
    try
    {
        Process.Start(path);
    }
    catch (Exception e)
    {
        AnsiConsole.WriteException(e);
        throw;
    }

    Thread.Sleep(waitTime);

    Win32Method.LeftMouseClick(x1, y1);
    Thread.Sleep(500);

    Win32Method.KeyInput(id);
    Thread.Sleep(500);

    Win32Method.LeftMouseClick(x2, y2);
    
    AnsiConsole.MarkupLine("[green]成功[/]加入会议");
}