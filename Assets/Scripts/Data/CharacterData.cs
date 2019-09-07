using System.Collections.Generic;

//ID : 编号(int)
//SpeakerName : 角色名(string)
//PortraitPath : 头像路径(string)

public class CharacterData : Singleton<CharacterData>
{
    public Dictionary<int, Dictionary<string, string>> data = new Dictionary<int, Dictionary<string, string>>()
    {
        {10001, new Dictionary<string, string>(){ {"SpeakerName", "雪人A"}, {"PortraitPath", "PortraitPath/SnowmanA"}, } },
        {10002, new Dictionary<string, string>(){ {"SpeakerName", "雪人B"}, {"PortraitPath", "PortraitPath/SnowmanB"}, } },
        {10003, new Dictionary<string, string>(){ {"SpeakerName", "雪人C"}, {"PortraitPath", "PortraitPath/SnowmanC"}, } },
        {10004, new Dictionary<string, string>(){ {"SpeakerName", "雪人D"}, {"PortraitPath", "PortraitPath/SnowmanD"}, } },
    };

}
