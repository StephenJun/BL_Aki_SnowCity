using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueModel : Singleton<DialogueModel> {

    public Dictionary<int, Dictionary<string, string>> data;
    public DialogueModel()
    {
        data = DialogueData.Instance.data;
    }

    public string GetDialogueContent(int id)
    {
        string res = string.Empty;
        if (data.ContainsKey(id))
        {
            res = data[id]["Content"];
        }
        return res;
    }

    public string GetSpeakerName(int id)
    {
        string res = string.Empty;
        if (data.ContainsKey(id))
        {
            res = data[id]["SpeakerName"];
        }
        return res;
    }

    public bool GetInRight(int id)
    {
        bool res = false;
        if (data.ContainsKey(id))
        {
            bool.TryParse(data[id]["InRight"], out res);
        }
        return res;
    }

    public List<int> GetBranchDialogueIDs(int id)
    {
        List<int> res = new List<int>();
        if (data.ContainsKey(id))
        {
            if(data[id]["BranchIDs"] == "")
            {
                return res;
            }
            string[] dataValue = data[id]["BranchIDs"].Split(',');
            for (int i = 0, c= dataValue.Length; i < c; i++)
            {
                res.Add(int.Parse(dataValue[i]));
            }
        }
        return res;
    }
}
