using whitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class Tab
	{
		Settings settings = new Settings { input = ReaderInput.Tabs };

		[TestMethod]
		public void Spaces()
		{
			var result = whitespaceNET.WhitespaceReader.IndentationOf("    Hello World", settings);
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Tabs()
		{
			for (int i = 1; i < 100; i++)
			{
				var whitespace = new string('\t', i);
				var result = whitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World", settings);
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Custom_indent_size()
		{
			var result = whitespaceNET.WhitespaceReader.IndentationOf("\t\t\tHello World", new Settings
			{
				input = settings.input,
				tabSizeInSpaces = 2
			});
			Assert.AreEqual(3, result);
		}
	}
}