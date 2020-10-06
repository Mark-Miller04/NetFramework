using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

namespace UtilityLibrary
{
	public static class MathUtils
	{
		/// <summary>
		/// A Eratosthenes implementation of a prime number generator. 
		/// </summary>
		/// <param name="limit">A valid integer value.</param>
		/// <returns>An array of prime integers up to the input limit.</returns>
		public static int[] PrimeGeneratorLight(int limit)
		{
			List<int> primes = new List<int>();
			BitArray list = new BitArray(limit + 1, true);
			
			for(int i = 0; i * i <= limit; i++) {
				for(int j = i * i; j <= limit; j+=i) {
					list[j] = false;
				}
			}

			for (int i = 0; i <= limit; i++) {
				if(list[i]) {
					primes.Add(i);
				}
			}

			return primes.ToArray();
		}


		/// <summary>
		/// Find the set of prime numbers that exist beneath a given limit. A heavyweight function to handle very large inputs.
		/// Use for inputs above the limit of a 32-bit integer: 2,147,483,647.
		/// </summary>
		/// <param name="limit">The limit to generate up to.</param>
		/// <returns>A collection of big integers within the limit provided.</returns>
		public static BigInteger[] PrimeGeneratorHeavy(BigInteger limit)
		{
			// Translate big integer into two integers: (x) the multiple of int.MaxValue's, and (y) the remainder.
			// Make a list of bit arrays to hold all of the values. There will be as many arrays as value x + 1.
			// Iterate over the bit arrays to flip values false.
			// Iterate over the bit arrays to collect all true values. Reassemble big ints out of x and y values and add to list.
			// Return an array of big prime ints.

			// (x * int.MaxValue) + y = limit;
			int x = (int)(limit / int.MaxValue);
			int y = (int)(limit % int.MaxValue);

			// Make required bit arrays.
			List<BigInteger> primes = new List<BigInteger>();
			List<BitArray> bitArrays = new List<BitArray>(); 
			for(int i = 0; i <= x; i++) {
				bitArrays.Add(new BitArray(int.MaxValue, true));
			}

			// Iterate every integer up to the square root of the limit.
			// for(int i = 0; i * i <= limit; i++)
			// {
			//		Iterate every multiple of i up to the limit and flip them false.
			//		(int j = i * i; j <= limit; j+=i)


			// The big integers handle 
			BigInteger k = 0;
			for (int i = 0, bit1 = 0; k * k <= limit; i++)
			{
				k = (bit1 * int.MaxValue) + i;
				BigInteger l = k;
				for(int j = i, bit2 = bit1; l <= limit; j=j)
				{
					bitArrays[bit2][j] = false;
					l = (bit2 * int.MaxValue) + j + i;
					if (l > int.MaxValue) {
						j = (int)(l % int.MaxValue);
						bit2++;
					}
					else {
						j = (int)l;
					}
				}
			}

			for(int i = 0; i < bitArrays.Count; i++)
			{
				k = int.MaxValue * i;
				for(int j = 0; j <= int.MaxValue; j++)
				{
					BigInteger l = k + j;
					if (bitArrays[i][j]) {
						primes.Add(l);
					}

					if (l > limit) { break; }
				}
			}
			
			return primes.ToArray();
		}
	}
}
