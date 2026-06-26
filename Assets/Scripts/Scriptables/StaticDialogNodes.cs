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
        if (!IsJsonNull(phraseJson))
        {
            JsonShaverma<StoredPhrase> phraseShaverma = JsonUtility.FromJson<JsonShaverma<StoredPhrase>>("{\"items\":" + phraseJson.text + "}");
            if (phraseShaverma != null && !phraseShaverma.IsShavermaEmpty())
            {
                List<StoredPhrase> sPhrases = phraseShaverma.items;
                foreach(StoredPhrase phrase in sPhrases)
                {
                    string id = phrase.GetId();
                    if (sentenceNodes.ContainsKey(id) == false)
                    {
                        sentenceIds.Add(id);
                        sentenceNodes.Add(id, phrase);
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
            Debug.LogWarning("Файл фраз пуст или отсутствует!");
        }
        if (!IsJsonNull(selectorJson))
        {
            JsonShaverma<StoredSelector> selectorShaverma = JsonUtility.FromJson<JsonShaverma<StoredSelector>>("{\"items\":" + selectorJson.text + "}");
            if(selectorShaverma != null && !selectorShaverma.IsShavermaEmpty())
            {
                List<StoredSelector> sSelectors = selectorShaverma.items;
                foreach(StoredSelector selector in sSelectors)
                {
                    string id = selector.GetId();
                    if (sentenceNodes.ContainsKey(id) == false)
                    {
                        sentenceIds.Add(id);
                        sentenceNodes.Add(id, selector);
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
