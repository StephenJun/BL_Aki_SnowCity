using System;
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
    public Button[] optionsBtn;

    private string currentDialogueContent;
    private int currentDialogueID;


    private bool allowInput;

    public override void OnInit(object[] datas)
    {
        base.OnInit(datas);
        currentDialogueID = ParseDataByIndex<int>(0);
        EventDispatcher.Inner.AddEventListener(EventConst.EVENT_PRINT, PrintAAA);
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
        SetBtnEnability(false);
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

        //对话字幕显示完毕后显示选项按钮
        List<int> branches = DialogueModel.Instance.GetBranchDialogueIDs(currentDialogueID);
        for (int i = 0, c = branches.Count; i < c; i++)
        {
            optionsBtn[i].gameObject.SetActive(true);
            optionsBtn[i].GetComponentInChildren<Text>().text = DialogueModel.Instance.GetBranchText(currentDialogueID)[i];
            int id = i;
            optionsBtn[i].onClick.AddListener(() => {
                CallBackModel.Instance.InvokeMethod(DialogueModel.Instance.GetBranchCallBackIDs(currentDialogueID)[id]);
                ShowNextDialogue();
            });
        }
    }


    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //print(DialogueModel.Instance.GetBranchDialogueIDs(currentDialogueID).Count);
            List<int> nextID = DialogueModel.Instance.GetBranchDialogueIDs(currentDialogueID);
            if(nextID.Count > 1)
            {

            }
            else
            {
                int cbID = DialogueModel.Instance.GetBranchCallBackIDs(currentDialogueID)[0];
                CallBackModel.Instance.InvokeMethod(cbID);
                currentDialogueID = nextID[0];
                ShowNextDialogue();
            }
        }
    }

    private void SetBtnEnability(bool enable)
    {
        for (int i = 0, c = optionsBtn.Length; i < c; i++)
        {
            optionsBtn[i].gameObject.SetActive(enable);
            optionsBtn[i].onClick.RemoveAllListeners();
        }
    }

    private void PrintAAA(object[] a)
    {
        print(a[0].ToString() + a[1].ToString());
    }
}
