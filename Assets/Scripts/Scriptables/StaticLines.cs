using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

[CreateAssetMenu(fileName = "StaticLines", menuName = "Scriptable Objects/StaticLines")]
public class StaticLines : ScriptableObject
{
    [SerializeField] private List<string> localLines = new List<string>();

    public Dictionary<string, string> lineMap = new Dictionary<string, string>();

    public void LoadLocalLines(string langCode)
    {
        localLines.Clear();
        lineMap.Clear();

        string localizationPath = $"Localization/{langCode}.json";
        string fullPath = Path.Combine(Application.streamingAssetsPath, localizationPath);

        if (File.Exists(fullPath))
        {
            string jsonText = File.ReadAllText(fullPath);
            JsonShaverma<StoredLocal> localsShaverma = JsonUtility.FromJson<JsonShaverma<StoredLocal>>("{\"items\":" + jsonText + "}");
            if(localsShaverma != null && !localsShaverma.IsShavermaEmpty())
            {
                StoredLocal[] sLocals = localsShaverma.items;
                foreach(StoredLocal local in sLocals)
                {
                    string id = local.GetId();
                    if (!lineMap.ContainsKey(id))
                    {
                        localLines.Add(id);
                        string line = local.GetLine();
                        lineMap.Add(id, line);
                    }
                    else
                    {
                        Debug.LogError($"Дубликат ID обнаружен в JSON: {id}! Строка пропущена во избежание краша.");
                    }
                }
            }
        }
        else
        {
            Debug.LogWarning("Файл локализации пуст или отсутствует!");
        }
    }
    

    [System.Serializable]
    private class JsonShaverma<T>
    {
        public T[] items;

        public bool IsShavermaEmpty()
        {
            if (items != null && items.Length > 0)
            {
                return false;
            }
            return true;
        }
    }
}
