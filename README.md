random-nant-task
================

This is an implementation of a Random task for NAnt.  By calling this task from NAnt a random string is obtained.  

Usage
-----
This example generates a non-numeric 6 characters long random string, stored in "myProperty" NAnt property:

    <random property="myProperty" numeric="false" length="6"/>
    
These are the task attributes:
* **property**: Name of the property in which value will be stored (*required*).
* **numeric**: Indicates whether value has to contain just numbers or letters and numbers (*required*).
* **length**: Length of the generated string (*required*).