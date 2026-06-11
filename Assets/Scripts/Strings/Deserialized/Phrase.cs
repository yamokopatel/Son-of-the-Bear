using System;
using UnityEngine;

public class Phrase : Sentence
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

    public Phrase(StoredPhrase storedPhrase) : base()
    {
        this.selectorId = storedPhrase.GetSelectorId();
        //селекторы
        this.isChangingSelector = storedPhrase.GetChangingSelector();
        this.selectorIds = storedPhrase.GetSelectorIds();
        this.actions = storedPhrase.GetActions();
        this.phraseIds = storedPhrase.GetPhraseIds();
        //глобалы
        this.isModifyingGlobal = storedPhrase.GetModifyingGlobal();
        this.globalId = storedPhrase.GetGlobalId();
        this.modifyingValue = storedPhrase.GetModifyingValue();
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

    //базовые геттеры
    public string GetSelectorId()
    {
        return selectorId;
    }
    public bool GetChangingSelector()
    {
        return isChangingSelector;
    }
    public bool GetModifyingGlobal()
    {
        return isModifyingGlobal;
    }
}
