class GameLevels
{
	public static void registerGameLevels()
	{
		Levels.registerLevel(new Level(
			new Element(ElementTypes.PLAYER,1,1),
			[new Element(ElementTypes.TARGET,5,5)],
			[new Element(ElementTypes.BOX,4,4)]
		));

		Levels.registerLevel(new Level(
			new Element(ElementTypes.PLAYER,1,1),
			[new Element(ElementTypes.TARGET,19,5)],
			[new Element(ElementTypes.BOX,4,4)],
			[new Element(ElementTypes.WALL,18,5),
			new Element(ElementTypes.WALL,18,4),
			new Element(ElementTypes.WALL,18,3),
			new Element(ElementTypes.WALL,18,6),
			new Element(ElementTypes.WALL,18,7),
			new Element(ElementTypes.WALL,18,8)]
		));
	}
}