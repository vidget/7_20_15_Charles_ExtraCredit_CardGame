# 7_20_15_Charles_ExtraCredit_CardGame
MultiPlayer Card Deal


Added Cryptography Security to generate better random numbers. 
I noticed some patterning using the generic random class even when seeding with Date.Time.Tick 
Statistically a pair should be dealt about 6% of the time on first deal. 
When I ran it originally using only the Random class the stats were much lower.
