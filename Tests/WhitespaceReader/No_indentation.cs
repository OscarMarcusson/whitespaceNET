using whitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class No_indentation
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
	}
}