INCLUDE uehiu.ink
VAR completable_missingbracelet = false
-> DialogStart
=== DialogStart===
Hmh? #speaker Redd Happy
    *[Continue]
        Huh?! #speaker Redd Happy
        **[Continue]
            Where's my bracelet, did I forget to put it back? #speaker Redd Happy
            ***[Continue]
                ... #speaker Redd Happy
                ****[Continue]
                    Actually, if I remember correctly, I had a picnic on top of the mountain yesterday. #speaker Redd Happy
                        *****[Continue]
                        Maybe I forgot it there... #speaker Redd Happy
                            ******[Continue]
                            #addQuest missingbracelet
                            Silly me, I should look for it then! #speaker Redd Happy
-> END