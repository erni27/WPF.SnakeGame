# Snake Game
A simple windows game created for recruitment purposes. 

## Introduction
The snake game created in WPF (Windows Presentation Foundation). 
This was my first encounter with WPF technology. There are many already exist Snake Game implementations in WPF so I was trying do it in a slightly different way. Obviously, my implementation is far away from the optimalized one but It wasn't its purpose.

## Features 
Each time while a user scores a point it randomly downloads a picture from the Internet and assign it as a background. URLs for the images are stored in a config file.
Moreover, each time while the user scores a point, it randomly loads the picture of food from project directory. Pictures are downloaded and loaded during the runtime, not at the beginning. 
### Game Manual 
* `Spacebar` - start a game or restart it
* `Up` - change a snake direction to up
* `Down` - to down
* `Right` - to right 
* `Left` - to left
### Game Rules
After starting the game, press the space bar. The user starts with a snake of one field length. The task is to collect as many points as possible by collecting food placed on the board. With each point the snake's length increases by one field and its speed increases. Falling into one of the walls or part of the snake ends the game. Remember, if you change the direction of the snake to the opposite direction you also lose. 

## Technologies
Project is created with:
* Microsoft Visual Studio Community 2019 (Version 16.3.10)
* .NET Framework 4.7.2
* WPF (Windows Presentation Foundation)

## Sources 
The whole application was inspired by:
* https://www.wpf-tutorial.com/creating-game-snakewpf/introduction/
* https://github.com/YasinIbrahim/Snake-Game-WPF
* https://stackoverflow.com/questions/13374270/dynamic-data-display-wpf-need-to-add-text-to-canvas-c-sharp
* https://stackoverflow.com/questions/2031824/what-is-the-best-way-to-check-for-internet-connectivity-using-net
* https://stackoverflow.com/questions/24797485/how-to-download-image-from-url
* https://docs.microsoft.com/en-us/dotnet/framework/wpf/controls/how-to-use-the-image-element
* https://docs.microsoft.com/pl-pl/dotnet/framework/wpf/controls/how-to-convert-an-image-to-greyscale
* https://stackoverflow.com/questions/94456/load-a-wpf-bitmapimage-from-a-system-drawing-bitmap
* https://docs.microsoft.com/pl-pl/dotnet/framework/wpf/graphics-multimedia/how-to-use-a-bitmapimage