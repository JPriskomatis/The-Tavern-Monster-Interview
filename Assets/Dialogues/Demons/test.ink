-> Main

VAR choice = 0

=== Main ===

+[Why do you want to enter the tavern?]
    ~ choice = 1
    -> Chosen("I just want a drink")

+[How do you get along with humans?]
    ~ choice = 2
    -> Chosen("I don't mind them")

+[What are you good at?]
    ~ choice = 3
    -> Chosen("I can sing!")

+[Have you ever caused trouble before?]
    ~ choice = 4
    -> Chosen("Only when provoked.")

+[Why should I trust you?]
    ~ choice = 5
    -> Chosen("Because I have no reason to lie.")


=== Chosen(name) ===


{choice == 1:
    -> AfterDrink
}

{choice == 2:
    -> AfterHumans
}

{choice == 3:
    -> AfterSkill
}

{choice == 4:
    -> AfterTrouble
}

{choice == 5:
    -> AfterTrust
}


=== AfterDrink ===

A drink is all I need. Nothing more.

-> Main


=== AfterHumans ===

Humans and I... we coexist, carefully.

-> Main


=== AfterSkill ===

I can sing songs older than your tavern.

-> Main


=== AfterTrouble ===

Trouble finds me more than I find it.

-> Main


=== AfterTrust ===

Trust is earned. I am willing to try.

-> Main