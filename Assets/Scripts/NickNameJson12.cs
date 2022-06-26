using Newtonsoft.Json;
using System.Collections.Generic;

public class NickNameJson12
{
    [JsonProperty("nickname12_List")]
    public List<NickName12> NickNameList12 { get; set; }
}
public class NickName12
{
    [JsonProperty("nickname12")] public string Name12 { get; set; }
}