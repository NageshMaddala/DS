using DSLib.DataStructures;
using System;

namespace BasicDS
{
    class Program
    {
        static void Main(string[] args)
        {
            SamplesRelatedToTrie();
        }

        public static void SamplesRelatedToTrie()
        {
            Trie trie = new Trie();

            Console.WriteLine("Inserting words: Striver, Striving, String and Strike");

            trie.Insert("striver");
            trie.Insert("striving");
            trie.Insert("string");
            trie.Insert("strike");

            Console.WriteLine($"Search if Strawberry exists in trie: {(trie.Search("strawberry") ? true : false)}");
            Console.WriteLine($"Search if Strike exists in trie: {(trie.Search("strike") ? true : false)}");
            Console.WriteLine($"Search if Stri starts with in trie: {(trie.StartsWith("stri") ? true : false)}");
        }
    }
}
