using System;
using System.Collections.Generic;
using System.Text;

namespace WhitespaceNET
{
	public enum ReaderInput
	{
		/// <summary> Count both tabs and spaces </summary>
		All = 0,
		/// <summary> Only count whichever was found first, tabs or spaces </summary>
		MatchFirst = 1,
		/// <summary> Only count spaces </summary>
		Spaces = 2,
		/// <summary> Only count tabs </summary>
		Tabs = 3,
	}

	public enum ReaderOutput
	{
		Spaces,
		Tabs,
	}

	public class Settings
	{
		public ReaderInput input = ReaderInput.All;
		public int tabSizeInSpaces = 4;
		public ReaderOutput output = ReaderOutput.Tabs;
	}
}
