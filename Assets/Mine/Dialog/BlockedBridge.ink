# removeQuest TalkToYonder
VAR completable_BlockedBridge = false
VAR completable_GatherMaterial = false
->Hello
===Hello
Hello Yonder!# speaker: Redd Happy
    *[Continue]
        Oh, hey there lil' Redd! How are you? You look a little distraught.# speaker: Yonder Happy
        **[Continue]
            Well, I kind of am...
            ***[Continue]
                I think I forgot my bracelet in the mountains but I can't get there!# speaker: Redd Annoyed
                ****[Continue]
                    Oh? How come?# speaker: Yonder Happy
                    *****[Continue]
                        There's a big tree in the way of the bridge, I thought you could help me remove it?# speaker: Redd Happy
                        ******[Continue]
                            I would... but sadly my axe got damaged on my last trip to the woods# speaker: Yonder Happy
                            *******[Continue]
                                I'd need new material to patch it up first...# speaker: Yonder Happy
                                ********[Continue]
                                    I'd also need to assess the situation of the tree and the best way to chop it down.# speaker: Yonder Happy
                                    ********* "Help with material?"
                                            -> HelpWithMaterial
                            
                            
                                    ********* "I gathered the material!"
                                            -> HandOverMaterial
                                            {completable_GatherMaterial} {completable_BlockedBridge}

=== HelpWithMaterial
#addQuest GatherMaterial
# speaker: Redd Happy
Oh, if it's materials you need, I could help get them.

# speaker: Yonder Happy
You'd do that for me? Thank you!
I need 5 sticks and 4 stones in total to repair it.
You can find them deeper in the woods."

# speaker: Redd Happy
Alright! I'll be back soon!

-> END

=== HandOverMaterial
# removeQuest GatherMaterial
Alright, I already assessed the situation as well, let me just take care of the axe and the tree is as good as gone!# speaker: Yonder Happy

-> END