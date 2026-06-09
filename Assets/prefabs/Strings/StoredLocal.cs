using UnityEngine;

public class StoredLocal
{
    private string id;
    private string line;

    public StoredLocal(string id, string line)
    {
        this.id = id;
        this.line = line;
    }

    public string GetId()
    {
        return id;
    }
    public string GetLine()
    {
        return line;
    }
}
