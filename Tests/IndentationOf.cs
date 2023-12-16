using whitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class IndentationOf
	{
		[TestMethod]
		public void Empty()
		{
			var result = whitespaceNET.WhitespaceReader.IndentationOf("");
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void None()
		{
			var result = whitespaceNET.WhitespaceReader.IndentationOf("Hello World");
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void Spaces()
		{
			var indentSize = 4;
			for(int i = 1; i < 10; i++)
			{
				var whitespace = new string(' ', i * indentSize);
				var result = whitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World", indentSize);
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Tabs()
		{
			var indentSize = 4;
			for (int i = 1; i < 100; i++)
			{
				var whitespace = new string('\t', i);
				var result = whitespaceNET.WhitespaceReader.IndentationOf($"{whitespace}Hello World", indentSize);
				Assert.AreEqual(i, result);
			}
		}

		[TestMethod]
		public void Mixed()
		{
			var indentSize = 4;
			var result = whitespaceNET.WhitespaceReader.IndentationOf($"    \t    Hello World", indentSize);
			Assert.AreEqual(3, result);
		}

		[TestMethod]
		public void Custom_indent_size()
		{
			var indentSize = 2;
			var result = whitespaceNET.WhitespaceReader.IndentationOf($"      Hello World", indentSize);
			Assert.AreEqual(3, result);
		}
	}
}