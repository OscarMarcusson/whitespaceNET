using System.Diagnostics.Metrics;
using whitespaceNET;

namespace SignificantWhitespaceHierarchy
{
	[TestClass]
	public class FromFile
	{
		const string fileName = "testfile.txt";
		const string filePath = "some/dir/testfile.txt";

		[TestMethod]
		public void Empty()
		{
			var result = Hierarchy.FromInMemoryFile(filePath, "");
			Assert.AreEqual(0, result.Length);
		}

		[TestMethod]
		public void Single_line()
		{
			var result = Hierarchy.FromInMemoryFile(filePath, "test");
			Assert.AreEqual(1, result.Length);
			Assert.AreEqual(1, result[0].row);
			Assert.AreEqual(0, result[0].indent);
			Assert.AreEqual("test", result[0].text);
		}

		[TestMethod]
		public void Flat()
		{
			var result = Hierarchy.FromInMemoryFile(filePath, @"
				test
				test 123
				""A string test""
				");

			Assert.AreEqual(3, result.Length, $"Expected 3 rows");
			AssertRowIsEqualTo(result[0], row: 2, indent: 4, "test");
			AssertRowIsEqualTo(result[1], row: 3, indent: 4, "test 123");
			AssertRowIsEqualTo(result[2], row: 4, indent: 4, "\"A string test\"");
		}

		[TestMethod]
		public void Depth()
		{
			var result = Hierarchy.FromInMemoryFile(filePath, @"
				test
					test
					123

				test 123
					child1
						child2
							child3
							child4
							child5
						child6

				""A string test""
				");

			Assert.AreEqual(3, result.Length, $"Expected 3 rows");
			AssertRowIsEqualTo(result[0], row: 2, indent: 4, "test");
			AssertRowIsEqualTo(result[1], row: 6, indent: 4, "test 123");
			AssertRowIsEqualTo(result[2], row: 14, indent: 4, "\"A string test\"");

			Assert.AreEqual(2, result[0].content.Count, "First row should have 2 subrows");
			Assert.AreEqual(1, result[1].content.Count, "Second row should have 1 subrow");
			Assert.AreEqual(0, result[2].content.Count, "Third row should not have any subrows");

			// First row subrows
			Assert.AreEqual("test", result[0].content[0].text);
			Assert.AreEqual("123", result[0].content[1].text);

			// Second row subrows
			Assert.AreEqual("child1", result[1].content[0].text);
			Assert.AreEqual(2, result[1].content[0].content.Count);
			Assert.AreEqual("child2", result[1].content[0].content[0].text);
			Assert.AreEqual("child6", result[1].content[0].content[1].text);
			Assert.AreEqual(3, result[1].content[0].content[0].content.Count);
			Assert.AreEqual("child3", result[1].content[0].content[0].content[0].text);
			Assert.AreEqual("child4", result[1].content[0].content[0].content[1].text);
			Assert.AreEqual("child5", result[1].content[0].content[0].content[2].text);
		}


		void AssertRowIsEqualTo(FileRow rowToTest, int row, int indent, string text)
		{
			Assert.AreEqual(row, rowToTest.row, "Row number");
			Assert.AreEqual(indent, rowToTest.indent, "Indentation");
			Assert.AreEqual(text, rowToTest.text, "Text");
			Assert.AreEqual(filePath, rowToTest.filePath);
			Assert.AreEqual(fileName, rowToTest.fileName);
		}
	}
}