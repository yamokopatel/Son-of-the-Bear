using UnityEngine;

public class StoredAnswer : StoredSentence
{
    private string selectorId { get; }

    public StoredAnswer(string id, string selectorId) : base(id)
    {
        this.selectorId;
    }
}
