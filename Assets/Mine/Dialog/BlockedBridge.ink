VAR finished_blockedbridge = false
# speaker Yonder

Hey Redd, you look troubled.
Redd: Yonder, I'm glad you're home. 
Yes, I was looking for you actually.
The bridge into the forest is blocked by a fallen tree, could you help me remove it?
Yonder: Oh, I'd love to help but...
sadly my axe broke last time I used it.
* Give me the quest
 -> GiveQuest
 * {finished_blockedbridge} I finished
    -> FinishQuest
 
 === GiveQuest
 # addQuest BlockedBridge
 Bring me 2 Branches and 4 rocks
 -> END
 
 
 === FinishQuest
 # removeQuest BlockedBridge
 Thank you! Now I can repair my axe.
-> END
 