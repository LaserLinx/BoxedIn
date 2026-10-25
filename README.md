# BoxedIn

BoxedIn is a keyboard-controlled, terminal puzzle game built with C# and .NET 10. Push boxes onto every target to complete a level, then move on to the next puzzle. The game includes 20 levels, with walls and layouts that become more involved as you progress.

## Features

- 20 built-in box-pushing levels
- Keyboard-controlled main menu and level selection
- Restart the current level at any time
- Console-rendered levels with distinct symbols for the player, boxes, targets, and walls
- Docker image build support

## Requirements

- .NET 10 SDK to build and run from source
- A terminal that supports interactive keyboard input and Unicode characters
- Docker, if running in a container

## Run Locally

From the project directory, run:

```sh
dotnet run
```

To create a Release build:

```sh
dotnet build -c Release
```

## How to Play

Choose **Play** to start or continue from the current level. Choose **Select Level** to pick a level directly, or **Exit** to close the game. Move around the board and push boxes onto all targets. Boxes can be pushed but not pulled.

| Action | Keys |
| --- | --- |
| Navigate menus and move | `W`, `A`, `S`, `D` or arrow keys |
| Confirm a menu selection | `Enter` |
| Restart the current level | `R` |
| Return to the menu from a level | `Esc` |
| Exit from the main menu | `Esc` |

The board uses these symbols:

| Symbol | Meaning |
| --- | --- |
| `◈` | Player |
| `■` | Box |
| `⬚` | Target |
| `░` | Wall |

## Run with Docker

Build the image from the project directory:

```sh
docker build -t boxed-in .
```

Run it with an interactive terminal so the game can receive key presses:

```sh
docker run --rm -it boxed-in
```

## Project Layout

- `Program.cs` contains the menu, game loop, movement, and rendering setup.
- `GameLevels.cs` defines the built-in level layouts.
- `models/` contains the screen, level, and game-element models.
- `types/` contains element symbols and level registration helpers.
- `Dockerfile` defines the multi-stage Docker build.