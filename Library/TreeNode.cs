namespace Library;

public class TreeNode(byte key, bool isWord, TreeNode? parent)
{
    public byte Key => key;
    public TreeNode? Parent { get; set; } = parent;
    public bool IsWord { get; set; } = isWord;
    public Dictionary<byte, TreeNode>? Children { get; set; } = null;

    public IEnumerable<byte[]> GetByPrefix()
    {
        if (IsWord) { yield return GetBytes(); }
        if (Children == null) yield break;

        foreach (var childKeyVal in Children)
        {
            foreach (var bytes in childKeyVal.Value.GetByPrefix())
            {
                yield return bytes;
            }
        }
    }

    public override bool Equals(object? obj) => obj is TreeNode treeNode && Key == treeNode.Key;

    public override int GetHashCode() => HashCode.Combine(key);

    private byte[] GetBytes()
    {
        var current = this;
        var stackBytes = new Stack<byte>();
        while (current.Parent is not null)
        {
            stackBytes.Push(current.Key);
            current = current.Parent;
        }
        stackBytes.Push(current.Key);
        return stackBytes.ToArray();
    }
}