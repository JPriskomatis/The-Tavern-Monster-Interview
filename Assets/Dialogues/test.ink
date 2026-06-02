-> Main

VAR choice = 0

=== Main ===
    +[Why do you want to enter the tavern?]
        ~ choice = 1
        -> Chosen("I just want a drink")

    +[How do you go along with humans?]
        ~ choice = 2
        -> Chosen("I don't mind them")

    +[What are you good at?]
        ~ choice = 3
        -> Chosen("I can sing!")

=== Chosen(name) ===
{name}

//This is an if statement
{choice == 3:
    -> END
- else:
    -> Main
}