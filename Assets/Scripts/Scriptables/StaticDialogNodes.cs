using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "StaticDialogNodes", menuName = "Scriptable Objects/StaticDialogNodes")]
public class StaticDialogNodes : ScriptableObject
{
    [SerializeField] private TextAsset phraseJson;
    [SerializeField] private TextAsset selectorJson;
    [SerializeField] private List<string> sentenceIds = new List<string>();

    private Dictionary<string, StoredSentence> sentenceNodes = new Dictionary<string, StoredSentence>();

    public void Initialize()
    {
        sentenceNodes.Clear();
        sentenceIds.Clear();
        LoadNodesFromJson();
        
    }
    private void LoadNodesFromJson()
    {
        DeserializeNodes<StoredPhrase>(phraseJson);
        DeserializeNodes<StoredSelector>(selectorJson);
    }
    private void DeserializeNodes<T>(TextAsset jsonFile) where T : StoredSentence
    {
        if (!IsJsonNull(jsonFile))
        {
            JsonShaverma<T> sentenceShaverma = JsonUtility.FromJson<JsonShaverma<T>>("{\"items\":" + jsonFile.text + "}");
            if (sentenceShaverma != null && !sentenceShaverma.IsShavermaEmpty())
            {
                List<T> sSentences = sentenceShaverma.items;
                foreach(T sentence in sSentences)
                {
                    string id = sentence.GetId();
                    if (sentenceNodes.ContainsKey(id) == false)
                    {
                        sentenceIds.Add(id);
                        sentenceNodes.Add(id, sentence);
                    }
                    else
                    {
                        Debug.LogError($"Дубликат ID обнаружен в JSON: {id}! Фраза пропущена во избежание краша.");
                    }
                }
            }
            else
            {
                Debug.LogError("Не удалось распарсить JSON или список элементов пуст.");
            }
        }
        else
        {
            Debug.LogWarning("Файл селекторов пуст или отсутствует!");
        }
    }
    private bool IsJsonNull(TextAsset json)
    {
        if(json != null || !string.IsNullOrEmpty(json.text))
        {
            return false;
        }
        return true;
    }
    [System.Serializable]
    private class JsonShaverma<T>
    {
        public List<T> items;

        public bool IsShavermaEmpty()
        {
            if(items != null && items.Count > 0)
            {
                return false;
            }
            return true;
        }
    }
}
