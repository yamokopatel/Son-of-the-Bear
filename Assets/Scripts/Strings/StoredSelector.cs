using System.Collections.Generic;
using UnityEngine;

public class StoredSelector : StoredSentence
{
    private List<string> phraseIds { get; }
    private bool canEndDialog { get; }

    public StoredSelector(string id, List<string> phraseIds, bool canEndDialog) : base(id)
    {
        this.phraseIds = phraseIds;
        this.canEndDialog = canEndDialog;
    }

    public void ModifyPhraseStack(int action, string id)
    {
        if(action == -1)
        {
            phraseIds.Remove(id);
        }
        else if(action == 1)
        {
            phraseIds.Add(id);
        }
    }
    public bool GetCanDialogEnd()
    {
        return canEndDialog;
    }
}
