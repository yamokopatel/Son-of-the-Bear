using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StoredSelector : StoredSentence
{
    [SerializeField] private List<string> phraseIds;
    [SerializeField] private bool canEndDialog;

    public StoredSelector(string id, List<string> phraseIds, bool canEndDialog) : base(id)
    {
        this.phraseIds = phraseIds;
        this.canEndDialog = canEndDialog;
    }

    public bool GetCanDialogEnd()
    {
        return canEndDialog;
    }

    public List<string> GetPhraseIds()
    {
        return phraseIds;
    }
}
