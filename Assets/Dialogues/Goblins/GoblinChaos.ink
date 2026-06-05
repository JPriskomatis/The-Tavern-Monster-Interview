-> Main

VAR choice = 0

=== Main ===

+[Where were you during the market incident?]
~ choice = 1
-> Chosen("I was nowhere near those stalls.")

+[What do you think about the accusations against goblins?]
~ choice = 2
-> Chosen("People blame goblins for everything.")

+[Do you know anything about the goblins who fled into the sewers?]
~ choice = 3
-> Chosen("I've heard rumors, nothing more.")

+[What do you usually do for work?]
~ choice = 4
-> Chosen("I gather mushrooms and herbs.")

+[How would you describe yourself?]
~ choice = 5
-> Chosen("Careful. Most of the time.")

=== Chosen(name) ===

{choice == 1:
-> AfterAlibi
}

{choice == 2:
-> AfterAccusations
}

{choice == 3:
-> AfterSewers
}

{choice == 4:
-> AfterWork
}

{choice == 5:
-> AfterPersonality
}

=== AfterAlibi ===

I was collecting mushrooms outside the city walls. Ask anyone from the northern farms.

-> Main

=== AfterAccusations ===

One goblin causes trouble and suddenly every goblin is a criminal. It gets tiring.

-> Main

=== AfterSewers ===

Some goblins use the sewers as hiding places. That doesn't mean I know which ones did it.

-> Main

=== AfterWork ===

I gather mushrooms, herbs, and anything else people are willing to buy. It's not glamorous, but it pays.

-> Main

=== AfterPersonality ===

Careful. The world isn't kind to goblins who aren't paying attention.

-> Main
