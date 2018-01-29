# Asp.net-MVC-solution-to-game-of-life

## Rules:

The behaviour of each cell is dependent only on the state of its eight immediate
neighbours, according to the following rules:
Live cells:
1. a live cell with zero or one live neighbours will die.
2. a live cell with two or three live neighbours will remain alive
3. a live cell with four or more live neighbours will die.

Dead cells:
1. a dead cell with exactly three live neighbours becomes alive
2. in all other cases a dead cell will stay dead.

NB: All births and deaths occur simultaneously
