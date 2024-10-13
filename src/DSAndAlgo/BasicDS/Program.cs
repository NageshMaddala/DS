using DS_Lib;
using DSLib.DataStructures;
using System;

namespace BasicDS
{
    class Program
    {
        static void Main(string[] args)
        {
            //SamplesRelatedToTrie();
            SamplesRelatedToTrieII();
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
