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
* .Net 3.5 / Visual Studio 2010

Bugs/Suggestions: 
uweenukr@gmail.com
Ministry@live.com.au


Version 1.0
-----------
*/ Bugs

          * Exp/update returning to zero due to everyone not updating at the same update
          * Exp/minute calculation done (Commit 20), TotalEXP and average exp needs re-look,
            Catch out all returns of 0 when a player isn't updated so it isn't inserting 0's into
            the lists/database.
          * Table sorting during live races, by rank, (When people die?) the rank is 'removed',
            and when the table is populating gradually (before races start) duplicate people are inserted.

*/ Goals/Plans

          * Number formating, uint to strings, to ##,###,###,### etc.
          * Color codding rows/cells by class
          * Filtering the display by class
          * Searching for an Account/character, (only work for the top 200)
          * Season ladder if possible (I emailed the support about this just earlier)
          * [Maybe] grabbing data from exilestats such as race records(?)
          * Brainstorm a way to effectively display deaths without guessing too much [Waiting to hear back about
            live chat publishing]
          * Forum link for race events (Maybe not necesarry, mainly to show the brackets for reward points)
          * Hyperlink accounts to their pathofexile.com account page
          * [Maybe] Hard-coded list of people who are known to stream races (Nugi/Kripp/Rhox etc)

*/ Bugs fixed 

          * Exp/behind - Wrong data sent during update. Corrected
          * UpdateEXPMin() - Not correctly using UpdateTime List. Corrected.
