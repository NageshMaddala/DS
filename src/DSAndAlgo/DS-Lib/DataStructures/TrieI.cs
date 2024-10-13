namespace DSLib.DataStructures
{
    public interface ITrieI
    {
        public void Insert(string word);
        public bool Search(string word);
        public bool StartsWith(string prefix);
    }


    public class TrieI : ITrieI
    {
        public class NodeI
        {
            NodeI[] links = new NodeI[26];
            bool flag = false;

            public bool ContainsKey(char ch)
            {
                return links[ch - 'a'] != null;
            }

            public void Put(char ch, NodeI node)
            {
                links[ch - 'a'] = node;
            }

            public NodeI Get(char ch)
            {
                return links[ch - 'a'];
            }

            public void SetEnd()
            {
                flag = true;
            }

            public bool IsEnd()
            {
                return flag;
            }
        }

        private NodeI _root;

        public TrieI()
        {
            _root = new NodeI();
        }

        public void Insert(string word)
        {
            NodeI node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    node.Put(word[i], new NodeI());

                node = node.Get(word[i]);
            }

            node.SetEnd();
        }

        public bool Search(string word)
        {
            NodeI node = _root;

            for (int i = 0; i < word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    return false;

                node = node.Get(word[i]);
            }
            return node.IsEnd();
        }

        public bool StartsWith(string prefix)
        {
            NodeI node = _root;

            for (int i = 0; i < prefix.Length; i++)
            {
                if (!node.ContainsKey(prefix[i]))
                    return false;

                node = node.Get(prefix[i]);
            }
            return true;
        }
    }
}
