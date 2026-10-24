class Levels
{
	public static List<Level> levels = new List<Level>();

	public static void registerLevel(Level level)
	{
		levels.Add(level);
	}

	public static Level getLevel(int index)
	{
		Level levelInfo = levels[index];
		Element playerInfo = new Element(ElementTypes.PLAYER,levelInfo.player.x,levelInfo.player.y);
		List<Element> targetsInfo = new List<Element>();
		levelInfo.targets.ForEach((element) =>
		{
			targetsInfo.Add(new Element(ElementTypes.TARGET,element.x,element.y));
		});
		List<Element> boxesInfo = new List<Element>();
		levelInfo.boxes.ForEach((element) =>
		{
			boxesInfo.Add(new Element(ElementTypes.BOX,element.x,element.y));
		});
		List<Element> wallsInfo = new List<Element>();
		levelInfo.walls.ForEach((element) =>
		{
			wallsInfo.Add(new Element(ElementTypes.WALL,element.x,element.y));
		});
		Level level = new Level(
			playerInfo,
			targetsInfo,
			boxesInfo,
			wallsInfo

		);
		return level;
	}

}