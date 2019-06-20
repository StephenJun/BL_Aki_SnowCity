using System.Collections.Generic;

//ID : 单句对话的ID(int)
//SpeakerName : 说话者名字(string)
//Content : 对话内容(string)
//SpeakerPortrait : 说话者头像路径(string)
//InRight : 头像在右边？(bool)
//BranchIDs : 下一句对话的分支(string)
//BranchText : 分支选项文本(string)
//CallBack : 回调(int)

public class DialogueData : Singleton<DialogueData>
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
    {
        {1001, new Dictionary<string, string>(){ {"SpeakerName", "Pig"}, {"Content", "爱上大师傅所发生的"}, {"SpeakerPortrait", "rrrr"}, {"InRight", "TRUE"}, {"BranchIDs", "1002"}, {"BranchText", "aaa"}, {"CallBack", "10001"}, } },
        {1002, new Dictionary<string, string>(){ {"SpeakerName", "Dog"}, {"Content", "苏打水法规"}, {"SpeakerPortrait", "sssss"}, {"InRight", "FALSE"}, {"BranchIDs", "1003"}, {"BranchText", "bbbb"}, {"CallBack", "10002"}, } },
        {1003, new Dictionary<string, string>(){ {"SpeakerName", "Pig"}, {"Content", "东方闪电"}, {"SpeakerPortrait", "bbbb"}, {"InRight", "TRUE"}, {"BranchIDs", "1004"}, {"BranchText", "4444"}, {"CallBack", "10003"}, } },
        {1004, new Dictionary<string, string>(){ {"SpeakerName", "Pig"}, {"Content", "共同体和"}, {"SpeakerPortrait", "ccccc"}, {"InRight", "TRUE"}, {"BranchIDs", "1001,1002"}, {"BranchText", "vvv,xxx"}, {"CallBack", "10004"}, } },
    };

}
