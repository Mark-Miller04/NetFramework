using System;

namespace UtilityLibrary
{
	public static class StringUtils
	{
		/// <summary>
		/// Attempts to convert a string to an integer. No internal exception handling.
		/// </summary>
		/// <returns>Returns a valid integer if no exceptions thrown.</returns>
		public static int StringToInt(string str)
		{
			int ret;
			try {
				ret = Convert.ToInt32(str);
			}
			catch(Exception e) {
				throw e;
			}

			return ret;
		}

		/// <summary>
		/// Builds a comma deliniated list from an array of integers.
		/// </summary>
		/// <returns>A string representation of a comma deliniated list.</returns>
		public static string StringListFromInts(int[] input)
		{
			string ret = "";
			for(int i = 0; i < input.Length; i++) {
				ret += input[i];
				if(i < input.Length - 1) {
					ret += ", ";
				}
			}

			return ret + ".";
		}
	}
}
