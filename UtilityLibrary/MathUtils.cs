using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace UtilityLibrary
{
	public static class MathUtils
	{
		/// <summary>
		/// Find the set of prime numbers that exist beneath a given limit. A heavyweight function to handle very large inputs.
		/// Use for inputs above the limit of a 32-bit integer: 2,147,483,647.
		/// </summary>
		/// <param name="limit">The limit to generate up to.</param>
		/// <returns>A collection of big integers within the limit provided.</returns>
		public static BigInteger[] PrimeGeneratorHeavy(BigInteger limit)
		{
			int safetyCap = 10;
			if (limit > int.MaxValue * safetyCap) {
				throw new ArgumentException("The input is extremely large, surpassing the safety cap of the method.");
			}
			else if (limit < int.MaxValue) {
				throw new ArgumentException("This input is small enough to use the lightweight prime generator. Use it for performance.");
			}

			List<BigInteger> primes = new List<BigInteger>();
			Dictionary<BigInteger, bool> dict = new Dictionary<BigInteger, bool>();
			dict.Add(2, false);
			dict.Add(3, false);
			dict.Add(5, false);
			dict.Add(7, false);
			dict.Add(11, false);

			// Build a dictionary of pairs to test against.
			for(int i = 0; i < safetyCap; i++)
			{
				for(int j = 0; j < int.MaxValue; j++)
				{
					BigInteger x = (i * int.MaxValue) + j;
					if (x % 2 == 0 || x % 3 == 0 || x % 5 == 0 || x % 7 == 0 || x % 11 == 0) { continue; }
					dict.Add(x, true);
				}

				if (limit < (i * int.MaxValue) + int.MaxValue) { break; }
			}
			
			// Generate the primes up to the limit.
			

			return primes.ToArray();
		}
	}
}
