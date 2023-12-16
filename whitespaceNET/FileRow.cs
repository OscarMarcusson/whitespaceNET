using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WhitespaceNET
{
	public class FileRow : Row
	{
		public string filePath;
		public string fileName;

		internal FileRow(int row, int indent, string text, string filePath) : base(row, indent, text)
		{
			this.filePath = filePath;
			fileName = Path.GetFileName(filePath);
		}
	}
}
