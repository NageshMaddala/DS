using DS_Lib.DataStructures;
using DS_Lib.DataStructures.DP;
using DSLib.DataStructures;
using System;

namespace BasicDS
{
    class Program
    {
        static void Main(string[] args)
        {
            //SamplesRelatedToTrie();
            //SamplesRelatedToTrieII();
            //SamplesRelatedToTrieIII();
            //SamplesRelatedToTrieIV();
            DynamicProgrammingSamples();
        }

        private static void DynamicProgrammingSamples()
        {
            // find nth fib number

            int n = 5;

            var dp = new int[n + 1];

            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = -1;
            }

            var t = Fib.FindNthFibNUmber(n, dp);
            Console.WriteLine($"Fib number at {n}th position is {t}");

            t = Fib.FindFibNumberUsingTab(n);
            Console.WriteLine($"Fib number at {n}th position is {t}");
        }


        private static void SamplesRelatedToTrieIV()
        {
            var str = "abab";
            var trie = new TrieIV();
            var distinctWordCount = trie.CountDistinctSubString(str);
            Console.WriteLine($"Count of distinct words that can be formed used {str} including is {distinctWordCount}");

            trie = new TrieIV();
            str = "bob";
            distinctWordCount = trie.CountDistinctSubString(str);
            Console.WriteLine($"Count of distinct words that can be formed used {str} including is {distinctWordCount}");
        }

        private static void SamplesRelatedToTrieIII()
        {
            string[] arr = new string[] { "n", "nin", "ninj", "ninga", "ni", "ninija" };
            //string[] arr = new string[] { "n", "nin"};

            var trie = new TrieIII();

            string longest = "";

            foreach (var word in arr)
            {
                trie.InsertWord(word);
            }

            foreach (var word in arr)
            {
                if (trie.CheckIfCompletePrefixExists(word))
                {
                    if (word.Length > longest.Length)
                        longest = word;
                }
            }

            if (longest == "")
                Console.WriteLine("None");
            else
                Console.WriteLine(longest);

        }


        public static void SamplesRelatedToTrie()
        {
            TrieI trie = new TrieI();

            Console.WriteLine("Inserting words: Striver, Striving, String and Strike");

            trie.Insert("striver");
            trie.Insert("striving");
            trie.Insert("string");
            trie.Insert("strike");

            Console.WriteLine($"Search if Strawberry exists in trie: {(trie.Search("strawberry") ? true : false)}");
            Console.WriteLine($"Search if Strike exists in trie: {(trie.Search("strike") ? true : false)}");
            Console.WriteLine($"Search if Stri starts with in trie: {(trie.StartsWith("stri") ? true : false)}");
        }

        public static void SamplesRelatedToTrieII()
        {
            TrieII trieII = new TrieII();

            trieII.InsertWord("apple");
            trieII.InsertWord("apple");
            trieII.InsertWord("apps");
            trieII.InsertWord("apxl");
            trieII.InsertWord("apxl");

            var count = trieII.GetExactMatchingWordCount("apps"); //1
            var count0 = trieII.GetExactMatchingWordCount("apxl"); //2
            var count1 = trieII.GetStartsWithWordCount("apx"); //2
            var count3 = trieII.GetStartsWithWordCount("ap"); //5
            var count4 = trieII.GetExactMatchingWordCount("apple"); // 2

            trieII.EraseWord("apple");
            var count5 = trieII.GetExactMatchingWordCount("apple");
        }
    }
}
