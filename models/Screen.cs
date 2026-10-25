

class Screen
{

	private List<Element> elements = new List<Element>();
	public int width;
	public int height;

	public string background;


	public Screen(int _width, int _height, string _background = " ")
	{
		width = _width;
		height = _height;
		background = _background;

	}

	public string getString()
	{
		string screen = "";

		for (int y=0; y<=height; y++)
		
		{
			string screenRow = "";
			for (int x=0; x<=width; x++)
			{
				Element? selectedElement = null;
				elements.ForEach((Element element) =>
				{
					if (element.x == x && element.y == y)
					{
						selectedElement = element;
					}
				});
				if (selectedElement == null)
				{
					screenRow += background;
				} else
				{
					screenRow += selectedElement.charRep;
				}

			}
			screen += $"{screenRow}\n";
		}
		return screen;
	}

	

	public void addElement(Element element)
	{
		elements.Insert(0,element);
	}

	public void deleteElement(Element element)
	{
		elements.Remove(element);
	}

	public void clearScreen()
	{
		elements.Clear();
	}

	public List<Element> getAllElements()
	{
		return elements;
	}

	public Element? getElement(int x, int y)
	{
		Element? selectedElement = null;
		elements.ForEach((Element element) =>
		{
			if (element.x == x && element.y == y)
			{
				selectedElement = element;
			}
		});
		return selectedElement;
	}
}