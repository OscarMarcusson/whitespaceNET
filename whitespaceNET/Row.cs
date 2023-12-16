using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace whitespaceNET
{
	public class Row
	{
		public int row;
		public int indent;
		public string text;
		public List<Row> content = new List<Row>();

		internal Row(int row, int indent, string text)
		{
			this.row = row;
			this.indent = indent;
			this.text = text;
		}

		internal void AddContent(Row row)
		{
			if (content.Count > 0 && content.Last().indent < row.indent)
			{
				content.Last().AddContent(row);
			}
			else
			{
				content.Add(row);
			}
		}

		public override string ToString() => text;
	}
}
