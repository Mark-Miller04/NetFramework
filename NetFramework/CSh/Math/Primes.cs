using System;
using System.Collections;
using System.Collections.Generic;

namespace MMNet.Net.CSh.Math
{
	public static partial class Primes
	{
		/// <summary>
		/// A Eratosthenes implementation of a prime number generator. 
		/// </summary>
		/// <param name="limit">The limit to generate up to.</param>
		/// <returns>An array of all prime integers below the limit value.</returns>
		public static int[] Generate(int limit)
		{
			List<int> primes = new List<int>();
			BitArray list = new BitArray(limit + 1, true);

			for (int i = 2; i * i <= limit; i++) {
				for (int j = i * i; j <= limit; j += i) {
					list[j] = false;
				}
			}

			for (int i = 2; i <= limit; i++) {
				if (list[i]) {
					primes.Add(i);
				}
			}

			return primes.ToArray();
		}
	}
}
