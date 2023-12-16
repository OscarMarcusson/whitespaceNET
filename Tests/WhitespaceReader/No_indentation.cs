using WhitespaceNET;

namespace WhitespaceReader
{
	[TestClass]
	public class No_indentation
	{
		[TestMethod]
		public void Empty()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("");
			Assert.AreEqual(0, result);
		}

		[TestMethod]
		public void None()
		{
			var result = WhitespaceNET.WhitespaceReader.IndentationOf("Hello World");
			Assert.AreEqual(0, result);
		}
	}
}