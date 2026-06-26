using System;
using UnityEngine;

//дебил, не удаляй, тебе нужны классы-сиблинги (автор пишет себе)
[Serializable]
public class StoredSentence
{
    [SerializeField] private string id;

    public StoredSentence(string id)
    {
        this.id = id;
    }
    public string GetId() => id;
}
