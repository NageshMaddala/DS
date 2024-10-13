namespace DSLib.DataStructures
{
    public class Node
    {
        Node[] links = new Node[26];
        bool flag = false;

        public bool ContainsKey(char ch)
        {
            return links[ch - 'a'] != null;
        }

        public void Put(char ch, Node node)
        {
            links[ch - 'a'] = node;
        }

        public Node Get(char ch)
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

    public interface ITrie
    {
        public void Insert(string word);
        public bool Search(string word);
        public bool StartsWith(string prefix);
    }


    public class Trie : ITrie
    {
        private Node _root;

        public Trie()
        {
            _root = new Node();
        }

        public void Insert(string word)
        {
            Node node = _root;

            for(int i =0; i<word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    node.Put(word[i], new Node());

                node = node.Get(word[i]);
            }

            node.SetEnd();
        }

        public bool Search(string word)
        {
            Node node = _root;

            for(int i =0; i<word.Length; i++)
            {
                if (!node.ContainsKey(word[i]))
                    return false;

                node = node.Get(word[i]);
            }
            return node.IsEnd();
        }

        public bool StartsWith(string prefix)
        {
            Node node = _root;

            for(int i =0; i< prefix.Length; i++)
            {
                if (!node.ContainsKey(prefix[i]))
                    return false;

                node = node.Get(prefix[i]);
            }
            return true;
        }
    }
}
