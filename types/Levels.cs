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
		List<Element> copy(List<Element> elements)
		{
			return elements
			.Select(element => new Element(element.charRep,element.x,element.y))
			.ToList();
		}
		
		Level level = new Level(
			new Element(levelInfo.player.charRep,levelInfo.player.x,levelInfo.player.y),
			copy(levelInfo.targets),
			copy(levelInfo.boxes),
			copy(levelInfo.walls),
			copy(levelInfo.lavas),
			levelInfo.width,
			levelInfo.height
		);
		return level;
	}

	public static void addLevel(int playerX, int playerY, (int x, int y)[] targets, (int x, int y)[] boxes, (int x, int y)[]? walls = null, (int x, int y)[]? lavas = null)
		{
			registerLevel(new Level(
				new Element(ElementTypes.PLAYER, playerX, playerY),
				targets.Select(position => new Element(ElementTypes.TARGET, position.x, position.y)).ToList(),
				boxes.Select(position => new Element(ElementTypes.BOX, position.x, position.y)).ToList(),
				walls?.Select(position => new Element(ElementTypes.WALL, position.x, position.y)).ToList(),
				lavas?.Select(position => new Element(ElementTypes.LAVA, position.x, position.y)).ToList()
			));
		}
}