

class Program
{

	public static int currentLevel = 0;
	public static void Main()
	{
		

		Screen screen = new Screen(20,10,ElementTypes.BACKGROUND);

		GameLevels.registerGameLevels();

		menu(screen);
		
		Console.Clear();
	}

	private static void menu(Screen screen)
	{
		int selection = 0;
		List<string> menuOptions = ["Play","Select Level","Exit"];

		while (true)
		{
			Console.Clear();
			if (currentLevel == 0) menuOptions[0] = "Play";
			else menuOptions[0] = "Continue";
			for (int i=0; i < menuOptions.Count; i++)
			{
				if (selection == i) Console.WriteLine($" > {menuOptions[i]}");
				else Console.WriteLine($"  {menuOptions[i]}");
			}

			ConsoleKeyInfo key = Console.ReadKey();
			if (key.Key == ConsoleKey.Escape) break;
			if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow) selection +=1;
			if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow) selection -=1;
			if (selection >= menuOptions.Count) selection = 0;
			if (selection < 0 ) selection = menuOptions.Count-1;

			void play()
			{
				Level level = Levels.getLevel(currentLevel);
				Element player = buildLevel(screen,level);
				bool finished = game(screen,player,level);
				if (finished) currentLevel += 1;
				if (currentLevel >= Levels.levels.Count)
				{
					currentLevel = 0;
					Console.Clear();
					Console.WriteLine("Congratulations you completed all levels.");
					Console.ReadKey();
				}
			}

			if (key.Key == ConsoleKey.Enter)
			{
				if (selection == 0)
				{
					play();
				} else if (selection == 1)
				{
					int? selectedLevel = selectLevel();
					currentLevel = selectedLevel ?? currentLevel;
					if (selectedLevel != null) play();
				} else
				{
					break;
				}
			}
		}
	}


	private static int? selectLevel()
	{
		int selectedLevel = 0;
		while (true)
		{
			Console.Clear();
			for (int i=0; i < Levels.levels.Count; i++)
			{
				if (selectedLevel == i) Console.WriteLine($" > Level {i}");
				else Console.WriteLine($"  Level {i}");
			}
			
			ConsoleKeyInfo key = Console.ReadKey();
			if (key.Key == ConsoleKey.Escape) break;

			if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow) selectedLevel +=1;
			if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow) selectedLevel -=1;
			if (selectedLevel >= Levels.levels.Count) selectedLevel = 0;
			if (selectedLevel < 0 ) selectedLevel = Levels.levels.Count-1;

			if (key.Key == ConsoleKey.Enter) return selectedLevel;

		}
		return null;
	}
	private static void update(Screen screen)
	{
		Console.Clear();
		Console.WriteLine($"Level: {currentLevel+1}/{Levels.levels.Count}  Restart (R)");
		Console.Write(screen.getString());
	}

	private static Element buildLevel(Screen screen, Level level)
	{
		screen.clearScreen();

		Element player = level.player;

		screen.addElement(player);
		
		level.targets.ForEach(screen.addElement);
		level.boxes.ForEach(screen.addElement);
		level.walls.ForEach(screen.addElement);

		for (int y=0; y<=screen.height; y++)
		{
			for (int x=0; x<=screen.width; x++)
			{
				if (y == 0 || y == screen.height || x == 0 || x == screen.width)
				{
					Element wall = new Element(ElementTypes.WALL,x,y);
					screen.addElement(wall);
				}
			}
		}

		return player;
	}

	public static bool game(Screen screen, Element player, Level level)
	{
		while (true)
		{
			update(screen);
			ConsoleKeyInfo key = Console.ReadKey();

			if (key.Key == ConsoleKey.Escape) return false;

			if (key.Key == ConsoleKey.R)
			{
				level = Levels.getLevel(currentLevel);
				player = buildLevel(screen,level);
				continue;
			}

			int futureX = player.x;
			int futureY = player.y;

			if (key.Key == ConsoleKey.D || key.Key == ConsoleKey.RightArrow) futureX += 1;
			if (key.Key == ConsoleKey.A || key.Key == ConsoleKey.LeftArrow) futureX -= 1;
			if (key.Key == ConsoleKey.W || key.Key == ConsoleKey.UpArrow) futureY -= 1;
			if (key.Key == ConsoleKey.S || key.Key == ConsoleKey.DownArrow) futureY += 1;


			Element? steppedElement = screen.getElement(futureX,futureY);
			if (steppedElement != null)
			{
				if (steppedElement.charRep == ElementTypes.WALL)
				{
					futureX = player.x;
					futureY = player.y;
				}
				
				if (steppedElement.charRep == ElementTypes.BOX)
				{
					int futureElementX = steppedElement.x;
					int futureElementY = steppedElement.y;

					futureElementX += futureX - player.x;
					futureElementY += futureY - player.y;
					Element? elementSteppedElement = screen.getElement(futureElementX,futureElementY);
					if (elementSteppedElement != null && elementSteppedElement.charRep != ElementTypes.TARGET)
					{
						futureElementX = steppedElement.x;
						futureElementY = steppedElement.y;
						futureX = player.x;
						futureY = player.y;
					} else if (elementSteppedElement?.charRep == ElementTypes.TARGET)
					{
						screen.deleteElement(steppedElement);

						List<Element> currentElements = screen.getAllElements();
						if (!currentElements.Any(element => element.charRep == ElementTypes.BOX))
						{
							return true;
						}
					}

					steppedElement.x = futureElementX;
					steppedElement.y = futureElementY;

				}
			}

			player.x = futureX;
			player.y = futureY;
		}
	}
}
