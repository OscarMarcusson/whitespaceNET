using whitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class All
	{
		[TestMethod]
		public void Spaces()
		{
			var indentSize = 4;
			for (int i = 1; i < 100; i++)
			{
				var whitespace = new string(' ', i * indentSize);
				var result = whitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World");
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Tabs()
		{
			for (int i = 1; i < 100; i++)
			{
				var whitespace = new string('\t', i);
				var result = whitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World");
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Mixed()
		{
			var result = whitespaceNET.WhitespaceReader.IndentationOf("    \t    Hello World");
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void Custom_indent_size()
		{
			var result = whitespaceNET.WhitespaceReader.IndentationOf("      \tHello World", new Settings { tabSizeInSpaces = 2 });
			Assert.AreEqual(4, result);
		}
	}
}