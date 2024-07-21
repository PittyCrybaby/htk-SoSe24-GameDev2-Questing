VAR completable_hungryforfish = false
-> Dialog_Start_Dante
=== Dialog_Start_Dante ===
Sorrrrry, Redd~ #speaker Dante Smug
*[Continue]
        You'd need to pay a fee to get through here~ #speaker Dante Smug
        **[Continue]
            Dante! I don't have time for your games, I need to get my bracelet back. #speaker Redd Annoyed
            ***[Continue]
                    Hey, I'm not making the rules... #speaker Dante NotListening
                    ****[Continue]
                        (Although, I do.) #speaker Dante Smug
                        *****[Continue]
                        Pay the fee or no pass~ #speaker Dante Smug
                            ****** [Fee?]
                            -> CollectFish
                            
                            ******[I got what you need.]
                            -> HandOverFish
                            {completable_hungryforfish}
-> END

=== CollectFish ===
#addQuest hungryforfish
Urgh- What is the fee? #speaker Redd Annoyed
*[Continue]
    Well, I'm quite hungry but I don't want to get my paws dirty. #speaker Dante Smug
    **[Continue]
        I could go for a nice fish, I saw Mango leaving a bucket full of them near the lake earlier.
            ***[Continue]
                Maybe you could help yourself there~ #speaker Dante Smug
                    ****[Continue]
                        You're unbelievable... #speaker Redd Annoyed
                        *****[Look for the fish]
                            -> END

=== HandOverFish ===
#completeQuest hungryforfish
I got the fish you asked for. # speaker Redd Annoyed
*[Continue]
    Ohhhh! Wonderful~ # speaker Dante Smug
    **[Continue]
        You should tell Mango that you took one of his fish. # speaker Redd Annoyed
        ***[Continue]
            Ah... yes, you're right. I'll invite him for dinner. # speaker Dante Surprised
            ****[Continue]
                Sushi? # speaker Redd Curious
                *****[Continue]
                    Sushi. # speaker Dante Smug
                    ******[Continue]
                        Well, can I pass then? # speaker Redd Curious
                        *******[Continue]
                            Hmmmh... # speaker Dante NotListening
                            ********[Continue]
                                Dante! # speaker Redd Annoyed
                                *********[Continue]
                                    Alright, yes! # speaker Dante Smug
                                    **********[Continue]
                                        You're allowed to pass, don't get your fur in a twist!~ # speaker Dante Smug
                                            ***********[Continue]
                                                Thanks, I'll see you around. # speaker Redd Happy
                                                ************[Climb the mountain]
                                                    -> END