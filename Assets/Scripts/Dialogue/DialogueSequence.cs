using LitJson;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueSequence{

    public int FirstDialogueID;
    public List<DialogueData> dialogueDatas;

    public void Asdas()
    {

    }

}

public class DialogueSData
{
    public int ID;
    public string speaker;
    public string content;
    public string speakerPortrait;
    public List<int> branchIDs;
    public Action<object[]> callback;

    public DialogueSData(int _ID, string _speaker, string _content, string _speakerPortrait, List<int> _branchIDs, Action<object[]> _callback)
    {
        ID = _ID;
        speaker = _speaker;
        content = _content;
        speakerPortrait = _speakerPortrait;
        branchIDs = _branchIDs;
        callback = _callback;
    }
}
