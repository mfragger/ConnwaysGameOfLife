# ConnwaysGameOfLife

Go [here to play the webgl version](https://mfragger.github.io/ConnwaysGameOfLife/)

## Rules:
The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells, each of which is in one of two possible states, live or dead, (or populated and unpopulated, respectively). Every cell interacts with its eight neighbours, which are the cells that are horizontally, vertically, or diagonally adjacent. At each step in time, the following transitions occur:

  - Any live cell with fewer than two live neighbours dies, as if by underpopulation.
  
  - Any live cell with two or three live neighbours lives on to the next generation.
  
  - Any live cell with more than three live neighbours dies, as if by overpopulation.
  
  - Any dead cell with exactly three live neighbours becomes a live cell, as if by reproduction.

## Pattern
The code is written in MVC Pattern. With `ManagerController.cs` acting as the Controller 

Models are : `CellGridModel.cs` and `CellModel.cs`

Views are : `CellChangeView.cs` and `UICellGenerationView.cs`
