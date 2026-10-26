class Level
{
	public Element player;
	public List<Element> targets;
	public List<Element> boxes;
	public List<Element> walls = new List<Element>();
	public List<Element> lavas = new List<Element>();

	public int width = 20;
	public int height = 10;

	public Level(Element _player, List<Element> _targets, List<Element> _boxes, List<Element>? _walls = null, List<Element>? _lavas = null, int _width = 20, int _height = 10)
	{
		player = _player;
		targets = _targets;
		boxes = _boxes;
		if (_walls != null) walls = _walls;
		if (_lavas != null) lavas = _lavas;
		width = _width;
		height = _height;
	}
}