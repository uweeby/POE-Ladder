POE-Ladder
==========
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

          * Exp/behind - Works, however it's using a public static uint LeaderEXP; from Form1.cs with 
            LeaderEXP = LadderData.entries[0].character.experience; to feed it through to PlayerDB.cs
            LeaderEXP = Form1.LeaderEXP;
           
