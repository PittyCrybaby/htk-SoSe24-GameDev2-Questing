# removeQuest TalkToYonder
VAR completable_BlockedBridge = false
VAR completable_GatherMaterial = false
->Hello
===Hello
Hello Yonder!# speaker: Redd Sad
    *[Continue]
        Oh, hey there lil' Redd! How are you? You look a little distraught.# speaker: Yonder
        **[Continue]
            Well, I kind of am...
            I think I forgot my bracelet in the mountains but I can't get there!# speaker: Redd
            ***[Continue]
                Oh? How come?# speaker: Yonder
                ****[Continue]
                    There's a big tree in the way of the bridge, I thought you could help me remove it?# speaker: Redd
                    *****[Continue]
                        I would... but sadly my axe got damaged on my last trip to the woods
                        I'd need new material to patch it up first...
                        AND I need to assess the situation of the tree and the best way to move chop it down.# speaker: Yonder
                            ****** "Help with material?"
                                -> HelpWithMaterial
                            
                            
                            ****** {completable_GatherMaterial} {completable_BlockedBridge} "I gathered the material!"
                                -> HandOverMaterial

=== HelpWithMaterial
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

=== HandOverMaterial
# removeQuest GatherMaterial
# speaker: Yonder
"Alright, I already assessed the situation as well, let me just take care of the axe and the tree is as good as gone!"
-> END