Author: Brian Summers - summers.brian.cs@gmail.com
Student ID: 110656609
Date: 4/6/15
CMSC425 Spring 2015
Programming Assignment 2

This assignment completes the requirements for programming
assignment 2. The player has an idle, walking, and sprinting
state, and both the walking and sprinting states use a blendtree
to blend animations between walking/sprinting and turning
animations. The robots move idependently of one another, changing
to random directions, and at random times. The player wins by
colliding with 4 robots (as in the demo) and loses if enough
robots die such that the player cannot reach the goal or all the
robots die. The player will also lose if they run off the
platform. The camera follows in a "third-person" style, and the
environment contains a platform, the player, and 12 robots. And
upon completion of the game, the player is prompted to quit or
restart.

Note: in the demo of the assignment, the robots become active if
the left mouse button is clicked, regardless of whether or not the
player is pressing the 'w' key or 'up arrow' key. My
implementation does not adhere to this, since technically, with
the mouse button pressed, the player is not active. Also, in the
demo, the player will continue sprinting if they continue to hold
down the left mouse button and left go of the 'w' or 'up arrow'
keys. Again, my implementation does not adhere to this, since
technically, the player should no longer be moving forward.

All resources used were from the standard assests and from the
"robot kyle" assest. No external sources were used in the
implementation of this assignment. 