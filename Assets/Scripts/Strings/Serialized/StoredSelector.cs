using System.Collections.Generic;
using UnityEngine;

public class StoredSelector : StoredSentence
{
    private List<string> phraseIds;
    private bool canEndDialog;

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
