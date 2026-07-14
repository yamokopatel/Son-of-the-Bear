using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LangDictionary", menuName = "Scriptable Objects/LangDictionary")]
public class LangDictionary : ScriptableObject
{
    [System.Serializable]
    public struct LangWithCode
    {
        [SerializeField] private string code;
        [SerializeField] private string lang;

        public string GetCode() => code;
        public string GetLang() => lang;
    }

    [SerializeField] private LangWithCode[] languages;
    private Dictionary<string, string> langsByCodes = new Dictionary<string, string>();
    private Dictionary<string, string> codesByLangs = new Dictionary<string, string>();

    public void Initialize()
    {
        langsByCodes.Clear(); codesByLangs.Clear();
        foreach(LangWithCode language in languages)
        {
            string lang = language.GetLang(); string code = language.GetCode();
            if (string.IsNullOrEmpty(lang) || string.IsNullOrEmpty(code)) continue;
            langsByCodes[code] = lang;
            codesByLangs[lang] = code;
        }
    }
    public string GetLangByCode(string code)
    {
        if (code == null) return "English";
        return (langsByCodes.TryGetValue(code, out string lang) ? lang : "English");
    }
    public string GetCodeByLang(string lang)
    {
        if (lang == null) return "en";
        return (codesByLangs.TryGetValue(lang, out string code) ? code : "en");
    }
}
