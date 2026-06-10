using System;
using UnityEngine;

public class StoredPhrase : StoredSentence
{
    private string selectorId { get; }
    //для изменения селекторов
    private bool isChangingSelector { get; }
    private string[] selectorIds;
    private int[] actions;
    private string[] phraseIds;
    //для изменения глобалов
    private bool isModifyingGlobal { get; }
    private string globalId;
    private int modifyingValue;

    public StoredPhrase(string id, string selectorId,
        bool isChangingSelector = false, string[] selectorIds = null, int[] actions = null, string[] phraseIds = null,
        bool isModifyingGlobal = false, string globalId = null, int modifyingValue = 0) : base(id)
    {
        this.selectorId = selectorId;
        //селекторы
        this.isChangingSelector = isChangingSelector;
        this.selectorIds = selectorIds ?? Array.Empty<string>();
        this.actions = actions ?? Array.Empty<int>();
        this.phraseIds = phraseIds ?? Array.Empty<string>();
        //глобалы
        this.isModifyingGlobal = isModifyingGlobal;
        this.globalId = globalId ?? string.Empty;
        this.modifyingValue = modifyingValue;
    }

    //методы для возвращения данных об изменении селекторов
    //дженерик
    private T[] GetSelectorData<T>(T[] data)
    {
        if (isChangingSelector)
        {
            return data;
        }
        return Array.Empty<T>();
    }
    //методы
    public string[] GetSelectorIds() 
    { 
        return GetSelectorData<string>(selectorIds);
    }
    public int[] GetActions() 
    { 
        return GetSelectorData<int>(actions);
    }
    public string[] GetPhraseIds()
    {
        return GetSelectorData<string>(phraseIds);
    }

    //методы для измеления глобалов
    //дженерик
    private T GetGlobalData<T>(T data)
    {
        if (isModifyingGlobal)
        {
            return data;
        }
        return default;
    }
    //методы
    public string GetGlobalId()
    {
        return GetGlobalData<string>(globalId);
    }
    public int GetModifyingValue()
    {
        return GetGlobalData<int>(modifyingValue);
    }
}
