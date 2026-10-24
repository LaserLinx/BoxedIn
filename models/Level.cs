class Level
{
	public Element player;
	public List<Element> targets;
	public List<Element> boxes;
	public List<Element> walls = new List<Element>();

	public Level(Element _player, List<Element> _targets, List<Element> _boxes, List<Element>? _walls = null)
	{
		player = _player;
		targets = _targets;
		boxes = _boxes;
		if (_walls != null) walls = _walls;
	}
}