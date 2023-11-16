namespace Library;

public class Tree(Map map)
{
    private readonly Dictionary<byte, TreeNode> _root = new();

    public void Add(string word)
    {
        TreeNode? node = null;
        for (int index = 0; index < word.Length; index++)
        {
            if (!map.TryGetKey(word[index], out var key)) { continue; }

            Add
            (
                key,
                index is not 0 ? node : null,
                index == word.Length - 1,
                out node
            );
        }
    }

    private void Add(byte key, TreeNode? parent, bool isWord, out TreeNode? current)
    {
        var children = parent is null ? _root : parent.Children ??= new();

        if (children.TryGetValue(key, out current))
        {
            if (isWord)
            {
                current.IsWord = isWord;
            }
            current.Children ??= new();
        }
        else
        {
            current = new TreeNode(key, isWord, parent);
            children.Add(key, current);
        }
    }

    public void SearchByPrefix(string prefix, out IEnumerable<byte[]> postfixes)
    {
        postfixes = [];
        TreeNode? node = null;
        var current = _root;

        for (int index = 0; index < prefix.Length; index++)
        {
            if (!map.TryGetKey(prefix[index], out var key)) { return; }

            if (!current.TryGetValue(key, out node) || node.Children is null)
            {
                if (index != prefix.Length - 1) { return; }
                break;
            }

            if (index != prefix.Length - 1) { current = node.Children; }
        }

        if (node is null) { return; }

        postfixes = node.GetByPrefix();
    }
}