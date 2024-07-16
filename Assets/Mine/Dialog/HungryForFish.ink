#addQuest HungryForFish
VAR completable_HungryForFish = false
VAR completable_CollectFish = false

# speaker: Dante
Sorrrrry, Redd~
You'd need to pay a fee to get through here~

# speaker: Redd
Dante! I don't have time for your games, I need to get my braclet back.

# speaker: Dante
Hey, I'm not making the rules...
(Although, I do.)
Pay the fee or no pass~

# speaker Redd
* "Fee?"
-> CollectFish

*"I have the fish."
-> HungryForFish
{completable_CollectFish}
{completable_HungryForFish}

=== CollectFish===
#addQuest CollectFish
Urgh- What is the fee?

# speaker Dante
Well, I'm quite hungry but I don't want to get my paws dirty.
I could go for a nice fish, I saw Mango leaving a bucket full of them near the lake earlier, maybe you could help yourself there~

# speaker Redd
You're unbelievable...
-> END

=== HungryForFish ===
#removeQuest HungryForFish
removeQuest HungryForFish

# speaker Redd
I got the fish you asked for.

# speaker Dante
Ohhhh! Wonderful~

# speaker Redd
You should tell Mango that you took one of his fish.

# speaker Dante
Yes, you're right.
I'll invite him for dinner.

# speaker Redd
Sushi?

# speaker Dante
Sushi.

# speaker Redd
Well, can I pass then?

# speaker Dante
Hmmmh...

# speaker Redd
Dante!

# speaker Dante
Alright, yes!
You're allowed to pass~
Don't get your fur twisted!~

# speaker Redd
Thanks, I'll see you around.
-> END


