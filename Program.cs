

class Program
{

	public static int currentLevel = 0;
	public static void Main()
	{
		

		Screen screen = new Screen(20,10,ElementTypes.BACKGROUND);

		GameLevels.registerGameLevels();

		while (true)
		{
			if (currentLevel >= Levels.levels.Count) break;
			Level level = Levels.getLevel(currentLevel);
			Element player = buildLevel(screen,level);
			game(screen,player,level);
			currentLevel += 1;
		}

		
		Console.Clear();
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

	public static void game(Screen screen, Element player, Level level)
	{
		while (true)
		{
			update(screen);
			ConsoleKeyInfo key = Console.ReadKey();

			if (key.Key == ConsoleKey.Escape) break;

			if (key.Key == ConsoleKey.R)
			{
				level = Levels.getLevel(currentLevel);
				player = buildLevel(screen,level);
				continue;
			}

			int futureX = player.x;
			int futureY = player.y;

			if (key.Key == ConsoleKey.D) futureX += 1;
			if (key.Key == ConsoleKey.A) futureX -= 1;
			if (key.Key == ConsoleKey.W) futureY -= 1;
			if (key.Key == ConsoleKey.S) futureY += 1;


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
						bool haveBoxElement = false;
						currentElements.ForEach((element) =>
						{
							if (element.charRep == ElementTypes.BOX) haveBoxElement = true;
						});
						if (!haveBoxElement)
						{
							break;
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
