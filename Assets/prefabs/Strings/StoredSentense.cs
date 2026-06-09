using UnityEngine;

public class StoredSentence
{
    private string id;

    public StoredSentence(string id)
    {
        this.id = id;
    }

    public string GetId()
    {
        return id;
    }
}
