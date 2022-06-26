using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

using UnityEngine;

public static class ConfigFileUtils12
{
    private static readonly string _filePath = Path.Combine(Application.persistentDataPath, @"Data\Json\favoriteConfigFile12.json");

    public static  void FavoriteToFile12(List<FavoriteCard12> favoriteList12)
    {
        var favoriteJsonToFile12 = new FavoriteJson12
        {
            FavoriteCards12 = favoriteList12
        };

        var js12 = JsonConvert.SerializeObject(favoriteJsonToFile12, Formatting.Indented);
        
        File.WriteAllText(_filePath, js12);
    }

    public static List<FavoriteCard12> GetFavoriteCardsList12()
    {
        var favoriteJsonObjectFur12 = ReadAllFavoritesFromFile12();
        if (favoriteJsonObjectFur12 == null) return new List<FavoriteCard12>();

        var favoriteCardList12 = favoriteJsonObjectFur12.FavoriteCards12.ToList();

        return favoriteCardList12;
    }

    private static FavoriteJson12 ReadAllFavoritesFromFile12()
    {
        return File.Exists(_filePath)
            ? JsonConvert.DeserializeObject<FavoriteJson12>(File.ReadAllText(_filePath))
            : default;
    }
}

