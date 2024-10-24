using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Lib.DataStructures.DP
{
    public static class Fib
    {
        /// <summary>
        /// Memoization approach
        /// </summary>
        /// <param name="n"></param>
        /// <param name="dp"></param>
        /// <returns></returns>
        public static int FindNthFibNUmber(int n, int[] dp)
        {
            if(n == 0 || n == 1)
                return n;

            if (dp[n] != -1)
                return dp[n];

            dp[n] = FindNthFibNUmber(n - 1, dp) + FindNthFibNUmber(n - 2, dp);

            return dp[n];
        }

        public static int FindFibNumberUsingTab(int m)
        {
            int n = m;
            int[] dp = new int[n + 1];

            for (int i = 0; i < dp.Length-1; i++)
            {
                dp[n] = -1;
            }

            dp[0] = 0;
            dp[1] = 1;

            for (int i = 2; i <=n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }
            return dp[n];
        }
    }
}
