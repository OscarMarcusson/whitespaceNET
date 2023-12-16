using WhitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class First
	{
		Settings settings = new Settings { input = ReaderInput.MatchFirst };

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
			for (int i = 1; i < 100; i++)
			{
				var whitespace = new string('\t', i);
				var result = WhitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World", settings);
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Mixed_with_spaces_first()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("    \t    Hello World", settings);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Mixed_with_tabs_first()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("\t        Hello World", settings);
			Assert.AreEqual(1, result);
		}

		[TestMethod]
		public void Custom_indent_size()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("      \tHello World", new Settings
			{
				input = settings.input,
				tabSizeInSpaces = 2
			});
			Assert.AreEqual(3, result);
		}
	}
}