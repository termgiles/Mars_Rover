# Mars_Rover

## A C# console app-game where users collect coins.

Users define a grid layout and a starting position for the rover. The grid is quasi-randomly populated with features each implementing the IGridElement interface. The user can move the 'rover' using a series of string commands entered in the terminal or using the arrow keys with the terminal executing arrow key inputs recieved between each screen refresh. The game and it's varaious pages are rendered in ASCII art:

============================================================

           _ _  _ _       ___    _____   _____              
          // \\// \\     // \\   ||  \\ ||                  
         //   \/   \\   //===\\  ||===/ \\==\\              
        //          \\ //     \\ ||  \\  ___|/              
         _____    ___  _    _ _____ _____                   
         ||  \\  // \\ \\  // ||    ||  \\                  
         ||===/ ||   || \\//  ||=== ||===/                  
         ||  \\  \\_//   \/   ||___ ||  \\                  
                                                            
 ========================================================== 



### Roadmap

Randomly moving enemy: add randomisation so that enemy elements drift towards the user rover. An extension would be to add statefulness to attempt to recover the enemy if it becomes entrapped by solid grid elements.<br/>

User input: An input mode of the game which uses a task which awaits user input for a specified interval then moves the enemy regardless of if input is recieved. Trial async and synchronous versions.
