VisualSearch: A Windows Forms tool for searching across multiple files
======================================================================

[EditPad Pro]( http://www.editpadpro.com/) is by far my favourite text editor for Windows. Yes, I know Notepad++ is great and free. Yes I have used Emacs and Vim and I know they are broadly available, and free. The truth is: Muscle memory is very difficult to defeat, and I've been using EditPad Pro for the best part of the last 9 years on a daily basis. There's no way to compete with that.

Anyway, although EPP has one of the most powerful search tools available, searching across multiple files on disk is less than ideal. You have to open the files before being able to search. Not good. The rationale is that this functionality is available as a separate application called [PowerGREP]( http://www.powergrep.com/), which for some reason is more than triple the price of the text editor. If you want to buy it, be my guest. I didn't want to.

I like the simplicity of the _Find in files_ dialog on Notepad++ instead. So that is what I tried to do here. Enter the text you want to find, add some file filters, add some exclusion filters, point to a directory, click Search and that's it. You can select some basic options like searching whole words, using regular expressions ([.Net syntax]( http://www.regular-expressions.info/refext.html)), case sensitive searches and traversing subdirectories.

Because I wanted to integrate this tool with EditPad Pro, when you double-click on a search result a process called EditPadPro will be launched, with the file name and the line number of the result as command arguments. In my case, this opens the file on EPP and positions the cursor on the right line. Obviously the executable (or an appropriate named shortcut) must be on the system's/user's PATH. You can change this (or anything) to suit your needs if you want.

On EPP, I setup a tool with the following command line and a shortcut key, so I can call it on the path of the current file:

    VisualSearch.exe /folder "%PATH%"

Requirements
------------

* Visual Studio 2010 (any C# edition will do)
* Microsoft .Net Framework 4.0
* Just Great Software EditPad Pro
