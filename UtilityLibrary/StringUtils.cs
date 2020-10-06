using System;

namespace UtilityLibrary
{
	public static class StringUtils
	{
		public static int StringToInt(string str)
		{
			int ret;
			try {
				ret = Convert.ToInt32(str);
			}
			catch(Exception e) {
				throw new ArgumentException($"Invalid input caused by a {e.GetType().Name}.");
			}

			return ret;
		}
	}
}
