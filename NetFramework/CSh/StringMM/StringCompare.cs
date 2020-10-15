using System;
using System.Linq;

namespace MMNet.CSh.StringMM
{
	public static partial class StringCompare
	{
		/// <summary>
		/// Attempts to convert a string to a 32-bit integer. No internal exception handling.
		/// </summary>
		/// <returns>Returns a valid integer if no exceptions thrown.</returns>
		public static int StringToInt(string str)
		{
			try
			{
				int ret = Convert.ToInt32(str);
				return ret;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

		/// <summary>
		/// Attempts to convert a string to a 64-bit unsigned integer. No internal exception handling.
		/// </summary>
		/// <param name="str"></param>
		/// <returns>Returns a valid 64-bit unsigned integer if no exceptions thrown.</returns>
		public static ulong StringToULong(string str)
		{
			try
			{
				ulong ret = Convert.ToUInt64(str);
				return ret;
			}
			catch (Exception e)
			{
				throw e;
			}
		}

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

		/// <summary>
		/// Checks if a string is a palindrome, which reads the same forwards and backwards.
		/// </summary>
		/// <returns>True if it is, false if not.</returns>
		public static bool IsStringPalindrome(string str)
		{
			string rev = (string)str.Reverse();
			if (str == rev)
			{
				return true;
			}
			return false;
		}
	}
}
