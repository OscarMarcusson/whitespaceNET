using WhitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class Space
	{
		Settings settings = new Settings { input = ReaderInput.Spaces };

		[TestMethod]
		public void Spaces()
		{
			var indentSize = 4;
			for (int i = 1; i < 100; i++)
			{
				var whitespace = new string(' ', i * indentSize);
				var result = WhitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World", settings);
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Tabs()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("\t\tHello World", settings);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Custom_indent_size()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("      Hello World", new Settings
			{
				input = settings.input,
				tabSizeInSpaces = 2
			});
			Assert.AreEqual(3, result);
		}
	}
}