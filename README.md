NHTV Schedule ICS Converter
========================

Software to download NHTV schedules from the NHTV roster website, and convert them to .ics format (iCalendar) so that they can be read by digital agendas.

Skip the talk! Where can I get those nifty iCal files?
------------------------

From time to time I will grab all NHTV schedules available and put them online at http://schedules.bryankeiren.com/. You are free to check that webpage for the schedule(s) you're interested in and add them to your agenda from their own URL,
so that your schedules appears automatically in your agenda.

If you'd like me to update any of those files I host online, let me know and I'll get on it (let me know through GitHub, my [website](http://bryankeiren.com/contact) or Facebook (if you know me) or even in person!).

How to use
------------------------

You have two options:

- ScheduleICSConverter_CLI.exe
- SchoolScheduleICSConverter_GUI.exe

Both of these can be found in the *dist* folder. To use either one of these, *curl.exe* and *libSICSC.dll* need to be present (by default they are, if you grab *dist* from GitHub).
To run *SchoolScheduleICSConverter_GUI.exe*, you also need to have the ScheduleICSConverter_CLI.exe somewhere on your computer (the program let's you specify where to find the CLI .exe).

### ScheduleICSConverter_CLI.exe

If you've run ScheduleICSConverter_CLI.exe and don't know how to operate it, it's probably not for you and you should be using SchoolScheduleICSConverter_GUI.exe (the one with the fancy white/blue icon). See below.

### SchoolScheduleICSConverter_GUI.exe

If you've read and followed the instructions above, you should be able to run SchoolScheduleICSConverter_GUI.exe by double clicking on it. This will open a window such as this:

![](http://i.imgur.com/zayrz2F.png)

You should first specify where to find the ScheduleICSConverter_CLI.exe program. If it's located in the same folder, simply press "Current":

![](http://i.imgur.com/LLIdC3B.png)

You can now choose which schedules to download by selecting one or multiple class codes.

![](http://i.imgur.com/GvWi6zJ.png)

Optionally, you can now choose a starting year for the current schoolyear (should be set correctly by default, but you can change it if you so desire. If you don't know whether you should change this, leave it at what it is by default!).
You can also now choose which range of weeks to download (Again, this should be set correctly by default to the range of weeks 0 thru 52. You won't have to change anything).

Now, you can press "Run" to let the software do its thing. While it's busy you will see the progress bar fill up to indicate how far the program is coming along.
If the "View output when done" checkbox is checked, the software will automatically open the output folder containing all generated .ics files. This folder is always located in the same folder as the program, and it's always called 'output'.

![](http://i.imgur.com/HU0PCI0.png)
![](http://i.imgur.com/ocTakoB.png)

You can now import the .ics files into your digital agenda!

How to build
------------------------

- Open the solution in Visual Studio and build it.
- Grab a copy of [*curl.exe*](http://curl.haxx.se/) and place it in the output folder (either *dist/Debug* or *dist/Release*).
- Pick your poison:
  - *ScheduleICSConverter_CLI.exe* : This is a command line interface (CLI) program that will download and convert specific schedules based on the command line parameters passed to it. If no parameters are passed, it will open in a 'UI' mode which allows you to manually input the data needed to grab and convert a schedule. This application is used by the GUI application.
  - *SchoolScheduleICSConverter_GUI.exe* : This is a graphical user interface (GUI) program (meaning it has buttons and stuff!) that will let you pick which schedules you want to download and convert in a more user-friendly manner. This program invokes the CLI executable.

Valid class codes
------------------------

Valid classcodes that you can pass to the CLI executable are listed in the file *classlist.txt*.

Note that not each of these classcodes will result in an iCalendar file. This is because not each of these classcodes has a schedule listed by the NHTV roster website.
Most (if not all) 'regular' classes should work, however.