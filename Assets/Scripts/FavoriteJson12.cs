using Newtonsoft.Json;
using System.Collections.Generic;

public class FavoriteJson12
{
    [JsonProperty("favorite_card12")]
    public List<FavoriteCard12> FavoriteCards12 { get; set; }
}
public class FavoriteCard12
{
    [JsonProperty("name12")] public string Name12 { get; set; }
}
