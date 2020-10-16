using System;

namespace MMNet.CSh.ConsoleApp
{
	/// <summary>
	/// Tools for handling console input from the user.
	/// </summary>
	public static partial class Input
	{
		#region Integer Requests
		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static int RequestInt(string msg)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue) 
			{
				ret = TryInt(msg);
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="limit">A positive or negative limit on input. Sets the upper or lower bounds. 0 is treated as an upper bound.</param>
		public static int RequestInt(string msg, int limit)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue)
			{
				ret = TryInt(msg);
				if (ret == int.MinValue) { continue; }
				if (limit >= 0 && ret >= limit) {
					Console.WriteLine($"Input was higher than acceptable limit. Please enter a value below {limit}.");
					ret = int.MinValue;
				}
				else if (limit < 0 && ret <= limit) {
					Console.WriteLine($"Input was lower than acceptable limit. Please enter a value above {limit}.");
					ret = int.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="low">The lower bounds on a range of acceptable values, inclusive.</param>
		/// <param name="high">The upper bounds on a range of acceptable values, inclusive.</param>
		public static int RequestInt(string msg, int low, int high)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue)
			{
				ret = TryInt(msg);
				if (ret == int.MinValue) { continue; }
				if (ret < low || ret > high) {
					Console.WriteLine($"Input was outside the acceptable range of {low} to {high}.");
					ret = int.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="set">A set of acceptable values to compare user input against.</param>
		public static int RequestInt(string msg, int[] set)
		{
			int ret = int.MinValue;
			while (ret == int.MinValue)
			{
				ret = TryInt(msg);
				if (ret == int.MinValue) { continue; }
				bool accept = false;
				foreach(int i in set) {
					if (ret == i) {
						accept = true;
						break;
					}
				}

				if (!accept) {
					Console.WriteLine("Input did not match any acceptable values.");
					ret = int.MinValue;
				}
			}

			return ret;
		}

		private static int TryInt(string msg)
		{
			Console.WriteLine(msg);
			try {
				int ret = Convert.ToInt32(Console.ReadLine());
				if (ret == int.MinValue) {
					throw new OverflowException();
				}
				return ret;
			}
			catch (OverflowException){
				Console.WriteLine("Input was out of integer range. Please enter a positive or negative value below 2,147,483,648");
			}
			catch(FormatException) {
				Console.WriteLine("Input contained characters other than digits. Please enter only a number.");
			}

			return default;
		}
		#endregion

		#region Unsigned Integer Requests
		/// <summary>
		/// Request a console input from the user and convert to a valid unsigned integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static uint RequestUInt(string msg)
		{
			uint ret = uint.MaxValue;
			while (ret == uint.MaxValue)
			{
				ret = TryUInt(msg);
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid unsigned integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="limit">A positive limit on input. Sets the upper bounds.</param>
		public static uint RequestUInt(string msg, uint limit)
		{
			uint ret = uint.MaxValue;
			while (ret == uint.MaxValue)
			{
				ret = TryUInt(msg);
				if (ret == uint.MaxValue) { continue; }
				if (ret > limit) {
					Console.WriteLine($"Input was higher than acceptable limit. Please enter a value below {limit}.");
					ret = uint.MaxValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid unsigned integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="low">The lower bounds on a range of acceptable values, inclusive.</param>
		/// <param name="high">The upper bounds on a range of acceptable values, inclusive.</param>
		public static uint RequestUInt(string msg, uint low, uint high)
		{
			uint ret = uint.MaxValue;
			while (ret == uint.MaxValue)
			{
				ret = TryUInt(msg);
				if (ret == uint.MaxValue) { continue; }
				if (ret < low || ret > high) {
					Console.WriteLine($"Input was outside the acceptable range of {low} to {high}.");
					ret = uint.MaxValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid unsigned integer.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="set">A set of acceptable values to compare user input against.</param>
		public static uint RequestUInt(string msg, uint[] set)
		{
			uint ret = uint.MaxValue;
			while (ret == uint.MaxValue)
			{
				ret = TryUInt(msg);
				if (ret == uint.MaxValue) { continue; }
				bool accept = false;
				foreach (uint i in set) {
					if (ret == i) {
						accept = true;
						break;
					}
				}

				if (!accept) {
					Console.WriteLine("Input did not match any acceptable values.");
					ret = uint.MaxValue;
				}
			}

			return ret;
		}

		private static uint TryUInt(string msg)
		{
			Console.WriteLine(msg);
			try {
				uint ret = Convert.ToUInt32(Console.ReadLine());
				if (ret == uint.MaxValue) {
					throw new OverflowException();
				}
				return ret;
			}
			catch (OverflowException) {
				Console.WriteLine("Input was out of unsigned integer range. Please enter a positive value below 4,294,967,925");
			}
			catch (FormatException) {
				Console.WriteLine("Input contained characters other than digits. Please enter only a number.");
			}

			return default;
		}
		#endregion

		#region Double Requests
		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static double RequestDouble(string msg)
		{
			double ret = double.MinValue;
			while(ret == double.MinValue)
			{
				ret = TryDouble(msg);
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="limit">A positive or negative limit on input. Sets the upper or lower bounds. 0 is treated as an upper bound.</param>
		public static double RequestDouble(string msg, double limit)
		{
			double ret = double.MinValue;
			while (ret == double.MinValue)
			{
				ret = TryDouble(msg);
				if (ret == double.MinValue) { continue; }
				if (limit >= 0 && ret >= limit) {
					Console.WriteLine($"Input was higher than acceptable limit. Please enter a value below {limit}.");
					ret = double.MinValue;
				}
				else if (limit < 0 && ret <= limit) {
					Console.WriteLine($"Input was lower than acceptable limit. Please enter a value above {limit}.");
					ret = double.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="low">The lower bounds on a range of acceptable values, inclusive.</param>
		/// <param name="high">The upper bounds on a range of acceptable values, inclusive.</param>
		public static double RequestDouble(string msg, double low, double high)
		{
			double ret = double.MinValue;
			while (ret == double.MinValue)
			{
				ret = TryDouble(msg);
				if (ret == double.MinValue) { continue; }
				if (ret < low || ret > high) {
					Console.WriteLine($"Input was outside the acceptable range of {low} to {high}.");
					ret = double.MinValue;
				}
			}

			return ret;
		}

		/// <summary>
		/// Request a console input from the user and convert to a valid double.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="set">A set of acceptable values to compare user input against.</param>
		/// <param name="prec">A range to consider equivalency between user input and values in the set.</param>
		/// <returns>The value in the set that the user input was within an acceptable range of.</returns>
		public static double RequestDouble(string msg, double[] set, double prec)
		{
			double ret = double.MinValue;
			prec = Math.Abs(prec);
			while (ret == double.MinValue)
			{
				ret = TryDouble(msg);
				if (ret == double.MinValue) { continue; }
				bool accept = false;
				foreach(double d in set) {
					if (ret <= d + prec && ret >= d - prec) {
						accept = true;
						ret = d;
						break;
					}
				}

				if (!accept) {
					Console.WriteLine($"Input did not match any acceptable values.");
					ret = double.MinValue;
				}
			}

			return ret;
		}

		private static double TryDouble(string msg)
		{
			Console.WriteLine(msg);
			try {
				double ret = Convert.ToDouble(Console.ReadLine());
				if (ret == double.MinValue) {
					throw new OverflowException();
				}
				return ret;
			}
			catch(OverflowException) {
				Console.WriteLine("Input was out of floating point precision range.");
			}
			catch(FormatException) {
				Console.WriteLine("Input contained characters other than digits. Please enter only a number. It can contain one decimal point.");
			}

			return default;
		}
		#endregion

		#region String Requests
		/// <summary>
		/// Prompt the user to enter a string.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static string RequestString(string msg)
		{
			Console.WriteLine(msg);
			return Console.ReadLine();
		}

		/// <summary>
		/// Prompt the user to enter a string.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="limit">An acceptable character length limit on the user input.</param>
		public static string RequestString(string msg, uint limit)
		{
			while (true)
			{
				string ret = RequestString(msg);
				if (ret.Length > limit) {
					Console.WriteLine("The input was longer than the acceptable limit.");
					continue;
				}

				return ret;
			}
		}

		/// <summary>
		/// Prompt the user to enter a string.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="low">A lower bound on input character length, inclusive.</param>
		/// <param name="high">An upper bound on input character length, inclusive.</param>
		public static string RequestString(string msg, int low, int high)
		{
			while (true)
			{
				string ret = RequestString(msg);
				if (ret.Length < low || ret.Length > high) {
					Console.WriteLine("The input was outside the acceptable character length range.");
					continue;
				}

				return ret;
			}
		}

		/// <summary>
		/// Prompt the user to enter a string.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		/// <param name="set">A set of acceptable strings to compare against. Only returns once the user input matches an item in the set.</param>
		public static string RequestString(string msg, string[] set)
		{
			while(true)
			{
				string ret = RequestString(msg);
				foreach(string s in set) {
					if (ret == s) {
						return s;
					}
				}

				Console.WriteLine("Input did not match any acceptable values.");
			}
		}
		#endregion

		#region Boolean Requests
		/// <summary>
		/// Prompt the user to answer a yes or no quetion.
		/// </summary>
		/// <param name="msg">A concise prompt for the user to follow when entering input.</param>
		public static bool RequestYN(string msg)
		{
			while (true)
			{
				Console.WriteLine(msg);
				string str = Console.ReadLine();
				str.ToLower();
				if (str == "yes" || str == "y" || str == "(y)es") {
					return true;
				}
				else if (str == "no" || str == "n" || str == "(n)o") {
					return false;
				}
				else {
					Console.WriteLine("Input could not be read. Please enter (y)es or (n)o.");
				}
			}
		}
		#endregion
	}
}
