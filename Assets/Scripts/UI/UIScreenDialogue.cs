using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class UIScreenDialogue : UIScreen {

    [Header("Components")]
    public Text txt_leftSpeakerName;
    public Text txt_rightSpeakerName;
    public Text txt_dialogueContent;
    public RawImage rImg_leftPortrait;
    public RawImage rImg_rightPortrait;

    private string currentDialogueContent;
    private int currentDialogueID;


    private bool allowInput;

    public override void OnInit(object[] datas)
    {
        base.OnInit(datas);
        currentDialogueID = ParseDataByIndex<int>(0);

    }

    public override void OnClose()
    {
        throw new System.NotImplementedException();
    }

    public override void OnHide()
    {
        throw new System.NotImplementedException();
    }

    public override void OnShow()
    {
        ShowNextDialogue();
    }

    public void ShowNextDialogue()
    {
        string content = DialogueModel.Instance.GetDialogueContent(currentDialogueID);
        string speakerName = DialogueModel.Instance.GetSpeakerName(currentDialogueID);
        bool inRight = DialogueModel.Instance.GetInRight(currentDialogueID);
        (inRight == true ? txt_rightSpeakerName : txt_leftSpeakerName).text = speakerName;  //三元表达式

        StartCoroutine(ShowDialogueProgress(content));
    }

    private IEnumerator ShowDialogueProgress(string content)
    {
        StringBuilder sb = new StringBuilder();
        char[] charArray = content.ToCharArray();
        for (int i = 0, c = charArray.Length; i < c; i++)
        {
            sb.Append(charArray[i]);
            txt_dialogueContent.text = sb.ToString();
            yield return new WaitForSeconds(0.05f);
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print(DialogueModel.Instance.GetBranchDialogueIDs(currentDialogueID).Count);
            int nextID = DialogueModel.Instance.GetBranchDialogueIDs(currentDialogueID)[0];
            //TODO:
            currentDialogueID = nextID;
            ShowNextDialogue();
        }
    }
}
