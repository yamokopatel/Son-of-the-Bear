using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "StaticDialogNodes", menuName = "Scriptable Objects/StaticDialogNodes")]
public class StaticDialogNodes : ScriptableObject
{
    [SerializeField] private TextAsset nodeJson;
    [SerializeField] private List<string> sentenceIds = new List<string>();

    private Dictionary<string, Sentence> sentenceNodes = new Dictionary<string, Sentence>();

    public void Initialize()
    {
        sentenceNodes.Clear();
        sentenceIds.Clear();
        if(nodeJson == null || string.IsNullOrEmpty(nodeJson.text))
        {
            /*List<StoredSentence> storedSentences = JsonUtility.FromJson<List<StoredSentence>>(nodeJson.text);
            if(storedSentences != null)
            {
                foreach(StoredSentence sSentence in storedSentences)
                {
                    if (string.IsNullOrEmpty(sSentence.GetId())) continue;
                    if (!sentenceNodes.ContainsKey(sSentence.GetId()))
                    {
                        sentenceIds.Add(sSentence.GetId());
                        //sentenceNodes.Add(sSentence.GetId(), new Sentence(sSentence));
                        if(sSentence is StoredPhrase)
                        {
                            sentenceNodes.Add(sSentence.GetId(), new Phrase(sSentence));
                        }
                    }
                    else
                    {
                        Debug.LogWarning($"Дубликат ключа '{sSentence.GetId()}' в файле JSON!");
                    }
                }
            }*/
        }
    }
}
