
# Project Center from Ami Ezra in WPF .NET

Welcome to our comprehensive Project Center on Windows Presentation Foundation (WPF)! This project comprises nine various mini-projects.

## Home Page
- Welcome to my comprehensive Project Center on Windows Presentation Foundation (WPF)! This project comprises nine various mini-projects.
- By clicking an icons you'll enter the mini-project's presentation page which contains a simple explanation of how to use it.


## Installation

- Install my project

For Painter project:
```bash
Install-Package Extended.Wpf.Toolkit

```
    
## The Mini-Programs

### Chess
- This Program allows you to play a full game of chess with all the standard rules.
- The technologies I used in this project: C# based on WPF Interface, .NET.
- You can move pieces by clicking and dragging, and the game will validate your moves.
- It supports player vs player.

### Inventory System
 - This is an Inventory Management Program.
 - The save data in json file.
 - This Program allows you to manage inventory efficiently with features for adding, editing, and deleting items.
 - You can view  through the inventory, track stock levels.
 - To Start using the system, click the 'Start' button on the main screen.
 - To Return to the Home Page, click the home icon at the top-left corner of the window.

 ### Painter
- This is a simple painting application.
- The program allows you to draw on a canvas with different pen colors and sizes.
- You can choose pen colors from a dropdown menu and adjust the pen size.
- To start drawing, select a color from the 'Pen Colour' dropdown and adjust the size as needed.
- To clear the canvas, use an eraser.
- To exit the Painter, click the 'Exit' button located at the top-right corner of the window.

### PacMan Game
- This is a Pac-Man game application.
- The game allows you to control Pac-Man and navigate through the maze while avoiding ghosts.
- Collect dots and power-ups to earn points and defeat the ghosts.
- To start the game, click the 'Start' button on the main menu.
- Use the arrow keys on your keyboard to control Pac-Man's movement.
- To quit the game, click the 'Exit' button located at the top-right corner of the window.

### TicTacToe Game
- This is a Tic-Tac-Toe game application.
- The game allows a player to compete against the computer on a 3x3 grid.
- The player and the computer take turns placing 'X' or 'O' on the grid to try and form a line.
- To start a new game, click the 'New Game' button on the main screen.
- The player can click on an empty cell to place their mark.
- The first to form a horizontal, vertical, or diagonal line wins.
- To reset the game, click the 'Reset' button.
- To exit the game, click the 'Exit' button located at the bottom-right corner of the window.
### Snake Game
- This is a Snake game application.
- The game allows the player to control a snake, navigating a grid to eat food and grow longer.
- The goal is to grow the snake as long as possible without hitting the walls or itself.
- To start the game, click the 'Start' button on the main menu.
- Use the arrow keys to control the snake's movement.
- The game ends if the snake hits a wall or its own body.
- To restart the game, click the 'Restart' button.
- To exit the game, click the 'Exit' button located at the bottom-right corner of the window.

### Tetris Game
 - This is a Tetris game application.
 - The technologies I used in this project: C# based on WPF Interface, and .NET.
- The game allows the player to control falling blocks (tetrominoes) and fit them together to clear rows.
- The goal is to clear as many rows as possible by completing full lines without gaps.
- To start the game, click the 'Start' button on the main menu.
- Use the arrow keys to move and rotate the blocks as they fall.
- The game ends if the blocks stack to the top of the screen.
- To restart the game, click the 'Restart' button.
- To exit the game, click the 'Exit' button located at the bottom-right corner of the window.

### Countries Project
- This is a country information application.
- The technologies I used in this project: C# based on WPF Interface, .NET and API.
- The application provides detailed information about different countries around the world.
- You can view data such as population, capital and more.
- To start, select a country from the dropdown list on the main screen.
- The selected country’s details will be displayed in the information section.
- To search for a country, use the search bar at the top of the window.
- To exit the application, click the 'Exit' button located at the top-right corner of the window.

### Fifteen Puzzle Game
- This is a Fifteen Puzzle game application.
- The technologies I used in this project: C# based on WPF Interface, .NET.
- The game consists of a 4x4 grid with numbered tiles that are randomly shuffled.
- The goal is to arrange the tiles in numerical order by sliding them into the empty space.
- To start a new game, click the 'New Game' button on the main screen.
  "- Click on a tile adjacent to the empty space to slide it.
  "- The game ends when all the tiles are arranged in the correct order.
  "- To reset the game, click the 'Reset' button.
  "- To exit the game, click the 'Exit' button located at the top-right corner of the window.



## 🛠 Skills
C#, .NET, WPF, API, Working with files(JSON), OOP, ChatGPT


## API Reference

#### API for Countries Project

```http
  GET https://restcountries.com/v3.1/all


#### private async Task LoadCountriesDataAsync()

client.GetStringAsync("https://restcountries.com/v3.1/all") fetches the data from the API.
JsonSerializer.Deserialize<ObservableCollection<Country>>(json, options) deserializes the JSON data into an ObservableCollection<Country>.
The CountriesDataGrid.ItemsSource = Countries; sets the data grid's item source to the list of countries.

