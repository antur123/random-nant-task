random-nant-task
================

This is an implementation of a Random task for NAnt.  By calling this task from NAnt a random number is obtained.  
Its usage is quite simple.  This example generates a non-numeric 6 characters long random string, stored in "myProperty" NAnt property:

<random property="myProperty" numeric="false" length="6"/>