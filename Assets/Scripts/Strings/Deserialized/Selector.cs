using System.Collections.Generic;
using UnityEngine;

public class Selector : Sentence
{
    private List<string> phraseIds;
    private bool canEndDialog;

    public Selector(StoredSelector storedSelector)
    {
        this.phraseIds = storedSelector.GetPhraseIds();
        this.canEndDialog = storedSelector.GetCanDialogEnd();
    }

    public void ModifyPhraseStack(int action, string id)
    {
        if (action == -1)
        {
            phraseIds.Remove(id);
        }
        else if (action == 1)
        {
            phraseIds.Add(id);
        }
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
