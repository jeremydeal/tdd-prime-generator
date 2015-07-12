# tdd-prime-generator

Learning about unit tests AND Git this weekend. Exciting times, eh?

This program uses an algorithm called the Sieve of Eratosthenes to find all the primes below a given integer. I am using this project to simultaneously dabble in test-driven-development and to familiarize myself with Git and GitHub in the command line.

The plan HAD been to work on TDD first and then watch some Git tutorials on Sunday. However, I made a horrific design decision in this program, setting up the Generator.cs class to handle a string input and return a concatenated string of the primes. Given that I had to rewrite the test suite and the interface for Generator.cs before the next time I could expect tests to pass, I was worried that I would code myself into a dead end.

Git to the rescue!

Turns out, I didn't need to roll anything back, but holy crap, I felt so much freer to experiment knowing that I had a working version in my repo. Kudos, Mr. Torvalds, and kudos to GitHub.
