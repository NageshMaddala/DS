using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Lib.DataStructures
{
    public class Node
    {
        Node[] _links = new Node[26];
        bool _flag = false;

        public Node()
        {

        }

        public bool ContainsKey(char ch)
        {
            return _links[ch - 'a'] != null;
        }

        public void PutNode(char ch, Node node)
        {
            _links[ch - 'a'] = node;
        }

        public Node GetNode(char ch)
        {
            return _links[ch - 'a'];
        }

        public void SetEnd()
        {
            _flag = true;
        }

        public bool GetEnd()
        {
            return _flag;
        }
    }

    public interface ITrieIII
    {
        public void InsertWord(string word);
        public bool CheckIfCompletePrefixExists(string word);
    }


    public class TrieIII : ITrieIII
    {
        Node _root;

        public TrieIII()
        {
            _root = new Node();
        }

        public bool CheckIfCompletePrefixExists(string word)
        {
            Node node = _root;
            bool flag = true;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    return false;

                node = node.GetNode(word[i]);

                flag = flag & node.GetEnd();
            }

            return flag;
        }

        public void InsertWord(string word)
        {
            Node node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    node.PutNode(word[i], new Node());

                node = node.GetNode(word[i]);
            }

            node.SetEnd();
        }
    }


    public interface ITrieIV
    {
        public int CountDistinctSubString(string word);
    }

    public class TrieIV : ITrieIV
    {
        private Node _root;

        public TrieIV()
        {
            _root = new Node();
        }


        int counter = 0;

        public int CountDistinctSubString(string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                // This is the catch here
                // A new root is formed from every shifted character
                Node node = _root;
                for (int j = i; j < word.Length; j++)
                {
                    if (!node.ContainsKey(word[i]))
                    {
                        node.PutNode(word[i], new Node());
                        counter++;
                    }

                    node = node.GetNode(word[i]);
                }
            }
            return counter + 1;
        }
    }
}
