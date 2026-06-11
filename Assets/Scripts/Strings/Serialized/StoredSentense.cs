using UnityEngine;

//дебил, не удаляй, тебе нужны классы-сиблинги (автор пишет себе)
public class StoredSentence
{
    private string id;

    public StoredSentence(string id)
    {
        this.id = id;
    }
    public string GetId() => id;
}
