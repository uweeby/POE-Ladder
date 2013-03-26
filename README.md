POE-Ladder
==========

Overview
--------
Track Path of Exile Ladders with expanded race details in real time.

Screenshot
----------
[![](http://i.imgur.com/ltOXV8V.png)](http://i.imgur.com/ltOXV8V.png)


Tools
-----
* .Net 3.5 / Visual Studio 2012

Bugs/Suggestions: 
uweenukr@gmail.com, 
Ministry@live.com.au


Version 1.0
-----------
*/ Bugs

          * Exp/update returning to zero due to everyone not updating in the same update
          * Table sorting during live races, by rank, (When people die?) the rank is 'removed',
            and when the table is populating gradually (before races start) duplicate people are inserted.
          * Table refreshing after filtering by class/search.

*/ Goals/Plans

          * Season ladder if possible (Next build)
          * [Maybe] grabbing data from exilestats such as race records(?)
          * Death tracking
          * Forum link for race events (Maybe not necesarry, mainly to show the brackets for reward points)
          * Hyperlink accounts to their pathofexile.com account page (Not necesarry/useful really)
          * [Maybe] Hard-coded list of people who are known to stream races (Nugi/Kripp/Rhox etc)

*/ Bugs fixed 

          * Exp/behind - Wrong data sent during update. Corrected
          * UpdateEXPMin() - Not correctly using UpdateTime List. Corrected.
          * Exp/minute calculation done (Commit 20)
