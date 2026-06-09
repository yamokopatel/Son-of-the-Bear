using System;
using UnityEngine;

public class StoredPhrase : StoredSentence
{
    private string answerId { get; }

    private bool isChangingSelector { get; }
    private string[] selectorIds;
    private int[] actions;
    private string[] phraseIds;

    private bool isModifyingGlobal { get; }
    private string globalId;
    private int modifyingValue;

    public StoredPhrase(string id, string answerId) : base(id)
    {
        this.answerId = answerId;
    }
    public StoredPhrase(string id, string answerId, 
        bool isChangingSelector, string[] selectorIds, int[] actions, string[] phraseIds) : base(id)
    {
        this.answerId = answerId;

        this.isChangingSelector = isChangingSelector;
        this.selectorIds = selectorIds;
        this.actions = actions;
        this.phraseIds = phraseIds;
    }
    public StoredPhrase(string id, string answerId, 
        bool isModifyingGlobal, string globalId, int modifyingValue) : base(id)
    {
        this.answerId = answerId;

        this.isModifyingGlobal = isModifyingGlobal;
        this.globalId = globalId;
        this.modifyingValue = modifyingValue;
    }
    public StoredPhrase(string id, string answerId,
        bool isChangingSelector, string[] selectorIds, int[] actions, string[] phraseIds,
        bool isModifyingGlobal, string globalId, int modifyingValue) : base(id)
    {
        this.answerId = answerId;

        this.isChangingSelector = isChangingSelector;
        this.selectorIds = selectorIds;
        this.actions = actions;
        this.phraseIds = phraseIds;

        this.isModifyingGlobal = isModifyingGlobal;
        this.globalId = globalId;
        this.modifyingValue = modifyingValue;
    }

    public string[] GetSelectorIds()
    {
        if (isChangingSelector)
        {
            return selectorIds;
        }
        return Array.Empty<string>();
    }
    public int[] GetActions()
    {
        if (isChangingSelector)
        {
            return actions;
        }
        return Array.Empty<int>();
    }
    public string[] GetPhraseIds()
    {
        if (isChangingSelector)
        {
            return phraseIds;
        }
        return Array.Empty<string>();
    }

    public string GetGlobalId()
    {
        if (isModifyingGlobal)
        {
            return globalId;
        }
        return default;
    }
    public int GetMofifyingValue()
    {
        if (isModifyingGlobal)
        {
            return modifyingValue;
        }
        return default;
    }
}
