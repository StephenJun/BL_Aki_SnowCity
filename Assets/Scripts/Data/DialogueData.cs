using System.Collections.Generic;

//ID : 编号(int)
//ConditionID : 条件对话ID(int)
//SpeakerID : 说话的角色ID(int)
//Content : 对话内容(string)
//Branch : 分支(string)
//LastWord : 重复对话(string)

public class DialogueData : Singleton<DialogueData>
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
    {
        {10001, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10001"}, {"Content", "你终于醒了！我从雪崩里面把你救了出来，欢迎来到雪之城！"}, {"Branch", "这里是哪里？-aaa-10002|你是谁？-bbb-10003"}, {"LastWord", ""}, } },
        {10002, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10001"}, {"Content", "这里是雪之城，一位悲伤的神创造的奇迹。"}, {"Branch", ""}, {"LastWord", "欢迎来到雪之城！"}, } },
        {10003, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10001"}, {"Content", "我是雪人啊！"}, {"Branch", ""}, {"LastWord", "欢迎来到雪之城！"}, } },
        {10004, new Dictionary<string, string>(){ {"ConditionID", "10001"}, {"SpeakerID", "10001"}, {"Content", "在雪之城呆了一段时间，你感觉怎么样？"}, {"Branch", "虽然这里天气很冷，但是我能感受到你们雪人温暖的心-ccc-10005|这该死的天气！冷死了-ddd-10006"}, {"LastWord", ""}, } },
        {10005, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10001"}, {"Content", "正是因为这里这么寒冷，雪人们才必须依靠彼此的温度生存下去！"}, {"Branch", ""}, {"LastWord", "你觉得冷吗？"}, } },
        {10006, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10001"}, {"Content", "雪人可感觉不到温度哦！"}, {"Branch", ""}, {"LastWord", "你觉得冷吗？"}, } },
        {10007, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10002"}, {"Content", "你是新来的同学吗？欢迎来参加我对雪之心最新研究的汇报讲座！"}, {"Branch", "愿闻其详-eee-10008|（扭头就走）-fff-10009"}, {"LastWord", ""}, } },
        {10008, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10002"}, {"Content", "*&……#&￥"}, {"Branch", ""}, {"LastWord", "雪之心*&……#&￥"}, } },
        {10009, new Dictionary<string, string>(){ {"ConditionID", ""}, {"SpeakerID", "10002"}, {"Content", "*&……#&￥"}, {"Branch", ""}, {"LastWord", "雪之心*&……#&￥"}, } },
    };

}
