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
			copy(levelInfo.walls)

		);
		return level;
	}

}