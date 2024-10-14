using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DS_Lib.DataStructures
{
    public class NodeII
    {
        NodeII[] _links = new NodeII[26];
        bool flag = false;
        int _counterEndWith = 0;
        int _counterPrefix = 0;

        public void Put(char ch, NodeII node)
        {
            _links[ch - 'a'] = node;
            //node._counterPrefix++;
        }

        public int GetPrefix()
        {
            return _counterPrefix;
        }

        public void IncreasePrefix()
        {
            _counterPrefix++;
        }

        public void DecreasePrefix()
        {
            _counterPrefix--;
        }

        public int GetEndWith()
        {
            return _counterEndWith;
        }

        public void IncreaseEnd()
        {
            _counterEndWith++;
        }

        public void DecreaseEnd()
        {
            _counterEndWith--;
        }

        public bool ContainsKey(char ch)
        {
            return _links[ch - 'a'] != null;
        }

        public NodeII Get(char ch)
        {
            return _links[ch - 'a'];
        }
    }

    public interface ITrieII
    {
        public void InsertWord(string word);

        public int GetExactMatchingWordCount(string word);

        public int GetStartsWithWordCount(string word);

        public void EraseWord(string word);
    }

    public class TrieII : ITrieII
    {
        private NodeII _root;

        public TrieII()
        {
            _root = new NodeII();
        }

        public void EraseWord(string word)
        {
            NodeII node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    return;

                node = node.Get(word[i]);
                node.DecreasePrefix();
            }
            node.DecreaseEnd();
        }

        public int GetExactMatchingWordCount(string word)
        {
            NodeII node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    return 0;

                node = node.Get(word[i]);
            }

            return node.GetEndWith();
        }

        public int GetStartsWithWordCount(string word)
        {
            NodeII node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    return 0;

                node = node.Get(word[i]);
            }
            return node.GetPrefix();
        }

        public void InsertWord(string word)
        {
            NodeII node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    node.Put(word[i], new NodeII());

                node = node.Get(word[i]);
                node.IncreasePrefix();
            }

            node.IncreaseEnd();
        }


    }
}
