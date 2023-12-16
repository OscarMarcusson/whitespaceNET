using System;

namespace whitespaceNET
{
	public static class WhitespaceReader
	{
		public static int defaultIndentSize = 4;

		public static int IndentationOf(string text, int? indentSize = null)
		{
			if (!indentSize.HasValue)
				indentSize = Math.Max(1, defaultIndentSize);


			var indent = 0;
			for (int i = 0; i < text.Length; i++)
			{
				switch (text[i])
				{
					case '\t': indent += indentSize.Value; break;
					case ' ': indent++; break;
					default:
						return indent / indentSize.Value;
				}
			}
			return indent / indentSize.Value;
		}
	}
}
