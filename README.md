POE-Ladder
==========

Overview
--------
Track Path of Exile Ladders with expanded race details in real time.

Screenshot
----------
[![](http://i.imgur.com/cbv23UE.png)](http://i.imgur.com/cbv23UE.png)

Demo Link
---------
https://dl.dropbox.com/u/31365922/POELadder%201.1.zip


Tools
-----
* .Net 3.5 / Visual Studio 2012

Bugs/Suggestions: 
uweenukr@gmail.com, 
Ministry@live.com.au


Version 1.0
-----------
Bugs -

          * Update methods in playerDB.cs aren't being called.
          * Redo filtering and search - current is sloppy and slow

Goals -

          * [Maybe] grabbing data from exilestats such as race records(?)
          * Death tracking
          * Forum link for race events (Maybe not necesarry, mainly to show the brackets for reward points)
          * Log area to log events (Race start/finish) at a later date potentially server global messages.
          * [Maybe] Hard-coded list of people who are known to stream races (Nugi/Kripp/Rhox etc)

Bugs fixed/features added - 

          * Exp/behind - Wrong data sent during update. Corrected.
          * UpdateEXPMin() - Not correctly using UpdateTime List. Corrected.
          * Exp/minute calculation done (Commit 20).
          * Table size added (30-200) and further fixed in a later build.
          * Season ladder added - URL is currently hard coded and will need changing next season.
