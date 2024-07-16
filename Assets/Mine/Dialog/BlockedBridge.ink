# removeQuest TalkToYonder
VAR completable_BlockedBridge = false
VAR completable_GatherMaterial = false

# speaker: Redd
Hello Yonder!

# speaker: Yonder
Oh, hey there lil' Redd! How are you? You look a little distraught.

# speaker: Redd
Well, I kind of am...
I think I forgot my bracelet in the mountains but I can't get there!

# speaker: Yonder
Oh? How come?

# speaker: Redd
There's a big tree in the way of the bridge, I thought you could help me remove it?

# speaker: Yonder
I would... but sadly my axe got damaged on my last trip to the woods
I'd need new material to patch it up first...
AND I need to assess the situation of the tree and the best way to move chop it down.

* "Help with material?"
-> HelpWithMaterial

-> HandOverMaterial
* {completable_GatherMaterial} {completable_BlockedBridge} "I gathered the material!"

=== HelpWithMaterial ===
#addQuest GatherMaterial
# speaker: Redd
Oh, if it's materials you need, I could help get them.

# speaker: Yonder
You'd do that for me? Thank you!
I need 5 sticks and 4 stones in total to repair it.
You can find them deeper in the woods."

# speaker: Redd
Alright! I'll be back soon!

-> END

=== HandOverMaterial ===
# removeQuest GatherMaterial
# speaker: Yonder
"Alright, I already assessed the situation as well, let me just take care of the axe and the tree is as good as gone!"
-> END