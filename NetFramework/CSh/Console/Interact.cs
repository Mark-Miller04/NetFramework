using System;

namespace MMNet.CSh.ConsoleApp
{
	public static partial class Interact
	{
		/// <summary>
		/// Requests a valid integer from the user.
		/// </summary>
		/// <param name="msg">The question to prompt the user.</param>
		/// <returns>A valid integer value.</returns>
		public static int RequestInt(string msg)
		{
			while (true)
			{
				Console.WriteLine(msg);
				string str = Console.ReadLine();
				int ret = ConvertStringToInt(str);
				if (ret != -1)
				{
					return ret;
				}
			}
		}

		/// <summary>
		/// Request an integer from the user. Only returns if the integer is in the acceptable set.
		/// </summary>
		/// <param name="acceptable">An array of acceptable integer inputs.</param>
		/// <param name="msg">The question to prompt the user.</param>
		/// <returns>An integer value that exists within the expected integer array.</returns>
		public static int RequestSpecificInt(int[] acceptable, string msg)
		{
			Console.WriteLine(msg);
			while (true)
			{
				string str = Console.ReadLine();


				try
				{
					int ret = StringUtils.StringToInt(str);
					for (int i = 0; i < acceptable.Length; i++)
					{
						if (ret == acceptable[i])
						{
							return ret;
						}
					}
					Console.WriteLine("That integer is not a valid value, please try again.");
				}
				catch (FormatException)
				{
					Console.WriteLine("Read failed due to characters other than digits. " + msg);
					continue;
				}
				catch (OverflowException)
				{
					Console.WriteLine("Value is too large, exceeding max integer size of 2,147,483,647. " + msg);
					continue;
				}
				catch (Exception e)
				{
					Console.WriteLine(e.GetType() + e.Message);
					continue;
				}
			}
		}

		/// <summary>
		/// Return a boolean value from the user's input based on a yes or no question.
		/// </summary>
		/// <param name="que">The question to prompt the user.</param>
		/// <returns>True if answered yes, False if answered no.</returns>
		public static bool RequestYN(string que)
		{
			Console.WriteLine(que);
			Console.WriteLine("Answer (y)es or (n)o: ");

			while (true)
			{
				string str = Console.ReadLine().ToUpper();
				if (str == "YES" || str == "Y")
				{
					return true;
				}
				else if (str == "NO" || str == "N")
				{
					return false;
				}
				else
				{
					Console.WriteLine("Input not understood, please answer with yes or no.");
				}
			}

		}

		private static int ConvertStringToInt(string str)
		{
			int ret = -1;
			try
			{
				ret = StringUtils.StringToInt(str);
			}
			catch (FormatException)
			{
				Console.WriteLine("Read failed due to characters other than digits.");
			}
			catch (OverflowException)
			{
				Console.WriteLine("Value is too large, exceeding max integer size of 2,147,483,647.");
			}
			catch (Exception e)
			{
				Console.WriteLine($"{e.GetType()}: {e.Message}");
			}

			return ret;
		}
	}
}
