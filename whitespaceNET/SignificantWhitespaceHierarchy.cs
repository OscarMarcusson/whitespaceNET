using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static whitespaceNET.SignificantWhitespaceHierarchy;

namespace whitespaceNET
{
	public static class SignificantWhitespaceHierarchy
	{
		public static FileRow[] FromFile(string file, int? indentation = null)
		{
			var text = System.IO.File.ReadAllText(file);
			return FromInMemoryFile(text, text, indentation);
		}


		public static FileRow[] FromInMemoryFile(string file, string text, int? indentation = null)
		{
			return FromStringToCustomType(text, (r, i, t) => new FileRow(r, i, t, file), indentation);
		}


		public static Row[] FromString(string text, int? indentation = null)
		{
			return FromStringToCustomType(text, (r, i, t) => new Row(r, i, t), indentation);
		}


		public delegate T CreateRowOfType<T>(int rowNumber, int rowIndentation, string text);
		public static T[] FromStringToCustomType<T>(string code, CreateRowOfType<T> instanceCreator, int? indentation = null) where T : Row
		{
			var lines = code
				.Replace("\r", "")
				.Split('\n')
				.Select(x => x.TrimEnd())
				.ToArray();

			var output = new List<T>(lines.Length);

			// Raw parse
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Length == 0)
					continue;

				var indent = WhitespaceReader.IndentationOf(lines[i], indentation);
				var row = instanceCreator(i + 1, indent, lines[i].Trim());
				output.Add(row);
			}

			// Group by indent
			for (int i = 1; i < output.Count; i++)
			{
				var previous = output[i - 1];
				var current = output[i];
				if (current.indent > previous.indent)
				{
					previous.AddContent(current);
					output.RemoveAt(i);
					i--;
				}
			}

			return output.ToArray();
		}
	}
}
