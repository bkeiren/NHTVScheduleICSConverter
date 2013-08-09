NHTV Schedule ICS Converter
========================

Software to download NHTV schedules from the NHTV roster website, and convert them to .ics format (iCalendar) so that they can be read by digital agendas.

Skip the talk! Where can I get those nifty iCal files?
------------------------

From time to time I will grab all NHTV schedules available and put them online at http://schedules.bryankeiren.com/. You are free to check that webpage for the schedule(s) you're interested in and add them to your agenda from their own URL,
so that your schedules appears automatically in your agenda.

If you'd like me to update any of those files I host online, let me know and I'll get on it (let me know through GitHub, my [website](http://bryankeiren.com/contact) or Facebook (if you know me) or even in person!).

If all you want is to use the .ics files provided on http://schedules.bryankeiren.com/, then you don't have to read on! You can just visit that webpage, download or copy the url to your schedule and import it into your favourite digital agenda application!

If you want to use the software itself to manually download and convert schedules or if you want to use or view the source code, read on!

How to use the software
------------------------

- Open *dist\Debug\SchoolScheduleICSConverter_GUI.exe* or *dist\Release\SchoolScheduleICSConverter_GUI.exe*.
- Select one or multiple of the classes you wish to get schedules for from the list of classes on the right side.
- **OPTIONAL:** Select a range of weeks and/or select a start year from the Parse Settings section.
- Press RUN and wait for the process to complete.

How to build the software
------------------------

Open the solution in Visual Studio and build it.

Valid class codes
------------------------

Note that not each of the listed classcodes will result in an iCalendar file. This is because not each of these classcodes has a schedule listed by the NHTV roster website.
Most (if not all) 'regular' classes should work, however.