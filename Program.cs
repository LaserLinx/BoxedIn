

class Program
{

	
	public static void Main()
	{
		Screen screen = new Screen(20,10,ElementTypes.BACKGROUND);

		GameLevels.registerGameLevels();
		Game.menu(screen);
		Console.Clear();
	}

}
