xAPI Readme

There are two xAPI files, a .cs and a .dll. The .dll is a library
file with the desired xApi configuration. It uses a single function
to gather and output all of the data for an event in the simulation.
The .dll file cannot be opened under normal circumstances, however
it can be accessed just like a .h file in c++.
The .cs file is the raw, non-compiled code of the .dll so it can
be viewed easier and the code can be modified as needed. There 
are additional notes in the .cs file that detail what each part
of the code does and how to breakdown the code into separate functions
should the user want to use them indivitually. 

In the .cs and .dll files, they are currently set to send output
to a server I have setup, the address is in the prompt to connect
to the server. This can be changed to a different server for grading,
however, the output might not display correctly if the server is 
not setup to handle TinCan. 