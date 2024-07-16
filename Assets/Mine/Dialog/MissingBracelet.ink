#addQuest MissingBracelet
VAR completable_MissingBracelet = false

# speaker: Redd
Hmh?
Huh?!
Where's my bracelet, did I forget to put it back?
...
Actually, if I remember correctly, I had a picnic on top of the mountain yesterday. Maybe I forgot it there...

* "Find bracelet."
-> MissingBracelet
* {completable_MissingBracelet} "Find bracelet."

=== MissingBracelet===
Silly me, I should look for it then.
-> END