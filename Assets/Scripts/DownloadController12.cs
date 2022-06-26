using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class DownloadController12 : MonoBehaviour
{
    public List<Transform> favotireListFur = new List<Transform>();
    public List<FavoriteCard12> furFavorite = new List<FavoriteCard12>();
    private void Start()
    {
        furFavorite = ConfigFileUtils12.GetFavoriteCardsList12();
    }

    public async Task<Content12> DownloadJson12(string url12, string name12)
    {
        using var request12 = UnityWebRequest.Get(url12);

        var operation12 = request12.SendWebRequest();
        
        while (!operation12.isDone)
        {
            await Task.Yield();
        }
        
        byte[] buffer12 = request12.downloadHandler.data;

        if (request12.result ==UnityWebRequest.Result.Success)
        {
            string pathToJson12 = Path.Combine(Application.persistentDataPath, "Data/Json/");

            if (!Directory.Exists(pathToJson12))
            {
                Directory.CreateDirectory(pathToJson12);
            }
          
                File.WriteAllBytes(pathToJson12 + name12, buffer12);

            var _jsonContent12 = File.ReadAllText(pathToJson12 + name12);

            return JsonConvert.DeserializeObject<Content12>(_jsonContent12);
        }
        else
        {
            Debug.LogErrorFormat("error12 request [{0}, {1}]", url12, request12.error);
        }
        return default;
    }


    public async Task<ContentWallpappers12> DownloadWallpappersJson12(string url12, string name12)
    {
        using var request12 = UnityWebRequest.Get(url12);

        var operation12 = request12.SendWebRequest();

        while (!operation12.isDone)
        {
            await Task.Yield();
        }

        byte[] buffer12 = request12.downloadHandler.data;

        if (request12.result == UnityWebRequest.Result.Success)
        {
            string pathToJson12 = Path.Combine(Application.persistentDataPath, "Data/Wallpappers/Json/");

            if (!Directory.Exists(pathToJson12))
            {
                Directory.CreateDirectory(pathToJson12);
            }

             File.WriteAllBytes(pathToJson12 + name12, buffer12);
           
            var _jsonContent12 = File.ReadAllText(pathToJson12 + name12);

            return JsonConvert.DeserializeObject<ContentWallpappers12>(_jsonContent12);
        }
        else
        {
            Debug.LogErrorFormat("error12 request [{0}, {1}]", url12, request12.error);
        }
        return default;
    }
}
