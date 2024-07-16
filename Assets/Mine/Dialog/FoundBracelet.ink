#addQuest MissingBracelet
VAR completable_MissingBracelet = false

# speaker: Redd
There you are! I finally found you~

* "Take bracelet."
-> MissingBracelet
* {completable_MissingBracelet} "Take bracelet."

=== MissingBracelet===
#removeQuest MissingBracelet
I'll keep a better eye on you from now on, after all, I'm just holding on to you for my sister~
I hope she is having as much fun as I did today!~
-> END