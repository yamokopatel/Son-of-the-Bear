using System;
using UnityEngine;

[Serializable]
public class StoredPhrase : StoredSentence
{
    [SerializeField] private string selectorId;
    //для проверки глобалов
    [SerializeField] private bool isDependedOnGlobal;
    [SerializeField] private string[] globalIdsForC;
    [SerializeField] private int[] compareActions;
    [SerializeField] private int[] compareValues;
    //для изменения глобалов
    [SerializeField] private bool isModifyingGlobal;
    [SerializeField] private string[] globalIdsForM;
    [SerializeField] private int[] modifyingValues;

    public StoredPhrase(string id, string selectorId,
        bool isDependedOnGlobal = false, string[] globalIdsForC = null, int[] compareActions = null, int[] compareValues = null,
        bool isModifyingGlobal = false, string[] globalIdsForM = null, int[] modifyingValues = null) : base(id)
    {
        this.selectorId = selectorId;
        //селекторы
        this.isDependedOnGlobal = isDependedOnGlobal;
        this.globalIdsForC = globalIdsForC;
        this.compareActions = compareActions;
        this.compareValues = compareValues;
        //глобалы
        this.isModifyingGlobal = isModifyingGlobal;
        this.globalIdsForM = globalIdsForM;
        this.modifyingValues = modifyingValues;
    }

    //методы для возвращения данных об изменении селекторов
    //дженерик
    private T[] GetSelectorData<T>(T[] data)
    {
        if (isDependedOnGlobal)
        {
            return data;
        }
        return Array.Empty<T>();
    }
    //методы
    public string[] GetGlobalIdsForC() 
    { 
        return GetSelectorData<string>(globalIdsForC);
    }
    public int[] GetCompareActions() 
    { 
        return GetSelectorData<int>(compareActions);
    }
    public int[] GetCompareValues()
    {
        return GetSelectorData<int>(compareValues);
    }

    //методы для измеления глобалов
    //дженерик
    private T[] GetGlobalData<T>(T[] data)
    {
        if (isModifyingGlobal)
        {
            return data;
        }
        return default;
    }
    //методы
    public string[] GetGlobalIds()
    {
        return GetGlobalData<string>(globalIdsForM);
    }
    public int[] GetModifyingValues()
    {
        return GetGlobalData<int>(modifyingValues);
    }

    //базовые геттеры
    public string GetSelectorId()
    {
        return selectorId;
    }
    public bool GetDependedOnGlobal()
    {
        return isDependedOnGlobal;
    }
    public bool GetModifyingGlobal()
    {
        return isModifyingGlobal;
    }
}
