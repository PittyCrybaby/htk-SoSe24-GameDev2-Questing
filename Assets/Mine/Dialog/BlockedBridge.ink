INCLUDE logsintheway.ink
VAR completable_gathermaterial = false
->Dialog_Start_Yonder
===Dialog_Start_Yonder
Hello Yonder! #speaker Redd Happy
    *[Continue]
        Oh, hey there lil' Redd! How are you? You look a little distraught. #speaker Yonder Happy
        **[Continue]
            Well, I kind of am... #speaker Redd Annoyed
            ***[Continue]
                I think I forgot my bracelet in the mountains but I can't get there! #speaker Redd Annoyed
                ****[Continue]
                    Oh? How come?# speaker Yonder Happy
                    *****[Continue]
                        There's a big tree in the way of the bridge, I thought you could help me remove it?# speaker Redd Happy
                        ******[Continue]
                            I would... but sadly my axe got damaged on my last trip to the woods# speaker Yonder Happy
                            *******[Continue]
                                I'd need new material to patch it up first...# speaker Yonder Happy
                                ********[Continue]
                                    I could lend you the axe afterwards.# speaker Yonder Happy
                                    ********* "Help with material?"
                                            -> HelpWithMaterial
                            
                                    ********* "I gathered the material!"
                                            -> HandOverMaterial
                                            {completable_gathermaterial}
-> END

=== HelpWithMaterial
#addQuest gathermaterial
Oh, if it's materials you need, I could help get them. #speaker Redd Happy
    *[Continue]
        You'd do that for me? Thank you! #speaker Yonder Happy
            **[Continue]
                I need 4 sticks and 5 stones in total to repair it. You can find them around the area. #speaker Yonder Happy
                    ***[Continue]
                        Alright! I'll be back soon! #speaker Redd Happy
                        -> END

=== HandOverMaterial
#removeQuest gathermaterial
Thank you so much! #speaker Yonder Happy
    *[Continue]
        I actually found a spare axe in my shed, take it! #speaker Yonder Happy
            **[Continue]
                Don't hurt yourself. #speaker Yonder Happy
                    ***[Continue]
                        Thank you, Yonder! #speaker Redd Happy
                        -> END