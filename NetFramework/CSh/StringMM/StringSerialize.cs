using System;

namespace MMNet.CSh.StringMM
{
	public static partial class StringSerialize
	{
		/// <summary>
		/// Builds a comma deliniated list from an array of integers.
		/// </summary>
		/// <returns>A string representation of a comma deliniated list.</returns>
		public static string StringListFromInts(int[] input)
		{
			string ret = "";
			for (int i = 0; i < input.Length; i++)
			{
				ret += input[i];
				if (i < input.Length - 1)
				{
					ret += ", ";
				}
			}

			return ret + ".";
		}
	}
}
