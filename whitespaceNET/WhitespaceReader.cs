using System;
using System.Runtime;

namespace whitespaceNET
{
	public static class WhitespaceReader
	{
		public static Settings defaultSettings = new Settings();

		public static int IndentationOf(string text, Settings settings = null)
		{
			if (text.Length == 0 || (text[0] != ' ' && text[0] != '\t'))
				return 0;

			if (settings is null)
				settings = defaultSettings;


			// Spaces only
			if (settings.input == ReaderInput.Spaces || settings.input == ReaderInput.MatchFirst && text[0] == ' ')
			{
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i] != ' ')
						return TransformSpacesResult(i, settings);
				}
				return TransformSpacesResult(text.Length, settings);
			}

			// Tabs only
			if (settings.input == ReaderInput.Tabs || settings.input == ReaderInput.MatchFirst && text[0] == '\t')
			{
				for (int i = 0; i < text.Length; i++)
				{
					if (text[i] != '\t')
						return TransformTabsResult(i, settings);
				}
				return TransformTabsResult(text.Length, settings);
			}

			// Spaces and tabs
			var indent = 0;
			var tabSize = Math.Max(1, settings.tabSizeInSpaces);
			for (int i = 0; i < text.Length; i++)
			{
				switch (text[i])
				{
					case '\t': indent += tabSize; break;
					case ' ':  indent++;          break;
					default:
						return TransformSpacesResult(indent, settings);
				}
			}
			return TransformSpacesResult(indent, settings);
		}


		static int TransformTabsResult(int tabs, Settings settings)
		{
			return settings.output == ReaderOutput.Spaces
				? tabs * Math.Max(1, settings.tabSizeInSpaces)
				: tabs
				;
		}

		static int TransformSpacesResult(int spaces, Settings settings)
		{
			return settings.output == ReaderOutput.Tabs
				? spaces / Math.Max(1, settings.tabSizeInSpaces)
				: spaces
				;
		}
	}
}
