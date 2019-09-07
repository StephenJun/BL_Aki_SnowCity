using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModel : Singleton<PlayerModel>
{

    public void SaveDialogueData(int DialogueID)
    {
        string res = PlayerPrefs.GetString("PastDialogue", "");
        res = res + "," + DialogueID.ToString();
        PlayerPrefs.SetString("PastDialogue", res);
    }

    public bool CheckDialogueIsPast(int DialogueID)
    {
        string[] res = PlayerPrefs.GetString("PastDialogue", "").Substring(1).Split(',');
        for (int i = 0; i < res.Length; i++)
        {
            if (res[i].Equals(DialogueID.ToString()))
                return true;
        }

        return false;
    }

    public void SavePlayerTransform(Transform transform)
    {
        PlayerPrefs.SetString("PlayerPosition", transform.position.ToString());
        PlayerPrefs.SetString("PlayerRotation", transform.localEulerAngles.ToString());
        PlayerPrefs.SetString("PlayerScale", transform.localScale.ToString());
    }

    //public Transform GetPlayerTransform()
    //{
    //    return ne
    //}
}
