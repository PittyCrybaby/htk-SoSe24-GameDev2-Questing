INCLUDE uehiu.ink
VAR completable_missingbracelet = false
-> Dialog_Start_Monolog_Part1
=== Dialog_Start_Monolog_Part1===
Hmh? #speaker Redd Happy
    *[Continue]
        Huh?! #speaker Redd Curious
        **[Continue]
            Where's my bracelet, did I forget to put it back? #speaker Redd Curious
            ***[Continue]
                ... #speaker Redd Annoyed
                ****[Continue]
                    Actually, if I remember correctly, I had a picnic on top of the mountain yesterday. #speaker Redd Curious
                        *****[Continue]
                        Maybe I forgot it there... #speaker Redd Happy
                            ******[Continue]
                                Silly me, I should look for it then! #speaker Redd Happy #addQuest missingbracelet
                                *******[Go Outside]
                                    -> END