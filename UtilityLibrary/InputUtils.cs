using System;
using System.Collections.Generic;
using System.Text;

namespace UtilityLibrary
{
	public static class InputUtils
	{
		public static int RequestInt(string msg)
		{
			Console.WriteLine(msg);
			int ret;
			while(true)
			{
				string str = Console.ReadLine();
				try {
					ret = StringUtils.StringToInt(str);
				}
				catch (FormatException){
					Console.WriteLine("Read failed due to characters other than digits. " + msg);
					continue;
				}
				catch (OverflowException) {
					Console.WriteLine("Value is too large, exceeding max integer size of 2,147,483,647. " + msg);
					continue;
				}
				catch (Exception e) {
					Console.WriteLine(e.GetType() + e.Message);
					continue;
				}

				break;
			}

			return ret;
		}

	}
}
