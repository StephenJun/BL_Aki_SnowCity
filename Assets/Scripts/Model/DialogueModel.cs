using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueModel : Singleton<DialogueModel>
{
    public Dictionary<int, Dictionary<string, string>> data;
    public DialogueModel()
    {
        data = DialogueData.Instance.data;
    }

    public int GetConditionID(int id)
    {
        int res = -1;
        if (data.ContainsKey(id))
        {
            res = int.Parse(data[id]["ConditionID"]);
        }
        return res;
    }

    public string GetSpeakerName(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            int characterID = int.Parse(data[id]["SpeakerID"]);
            res = CharacterModel.Instance.GetCharacterName(characterID);
        }
        return res;
    }

    public string GetSpeakerPortraitPath(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            int characterID = int.Parse(data[id]["SpeakerID"]);
            res = CharacterModel.Instance.GetPortraitPath(characterID);
        }
        return res;
    }

    public string GetContent(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["Content"];
        }
        return res;
    }

    public bool IsLast(int id)
    {
        return string.IsNullOrEmpty(GetBranchContent(id));
    }

    public bool HasBranch(int id)
    {
        string[] branches = GetBranchContent(id).Split('|');
        return branches.Length > 1;
    }

    public List<DialogueBranchData> GetBranch(int id)
    {
        List<DialogueBranchData> res = new List<DialogueBranchData>();
        string[] branches = GetBranchContent(id).Split('|');
        for (int i = 0; i < branches.Length; i++)
        {
            string[] branchData = branches[i].Split('-');
            res.Add(new DialogueBranchData(branchData[0], branchData[1], int.Parse(branchData[2])));
        }
        return res;
    }

    public string GetLastWord(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["LastWord"];
        }
        return res;
    }

    private string GetBranchContent(int id)
    {
        string res = "";
        if (data.ContainsKey(id))
        {
            res = data[id]["Branch"];
        }
        return res;
    }
}

public struct DialogueBranchData
{
    public string content;
    public string eventName;
    public int nextID;

    public DialogueBranchData(string _content, string _eventName, int _nextId)
    {
        content = _content;
        eventName = _eventName;
        nextID = _nextId;
    }
}
