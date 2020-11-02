using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace MMNet.CSh.StringMM
{
	public static partial class StringManip
	{
		/// <summary>
		/// Returns a reversed string, honoring unicode surrogates.
		/// </summary>
		public static string Reverse(string str)
		{
			List<string> li = new List<string>();
			TextElementEnumerator charEnum = StringInfo.GetTextElementEnumerator(str);
			while (charEnum.MoveNext())
			{
				li.Add(charEnum.GetTextElement());
			}
			li.Reverse();

			StringBuilder ret = new StringBuilder();
			foreach (string s in li)
			{
				ret.Append(s);
			}

			return ret.ToString();
		}
	}
}
