using System;
using System.IO;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class WallpapIconControll12 : MonoBehaviour
{
    public Texture2D texture12;
    [SerializeField] private string _pathToHDD12;
    private KeyStorage12 key12;
    public string imageName12;
    public string imageURL12;

    private void Awake()
    {
        key12 = new KeyStorage12();
    }
    private async void OnBecameVisible()
    {
        Texture2D tex12 = await DownloadIcon12(imageURL12, imageName12);

        if (tex12 == default)
        {
            tex12 = texture12;
        }

        gameObject.transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture = tex12;
    }

    public async Task<Texture2D> DownloadIcon12(string url12, string name12)
    {
        string pathToMods12 = Path.Combine(Application.persistentDataPath, _pathToHDD12);

        if (File.Exists(pathToMods12 + name12))
        {
            int lastIndexOfDot12 = name12.LastIndexOf(key12.Dot12, StringComparison.Ordinal);
            int prefixLength12 = name12.Length - lastIndexOfDot12;
            string postfix12 = name12.Substring(lastIndexOfDot12, prefixLength12);
            string filePath12 = Application.persistentDataPath + "/" + _pathToHDD12 + name12;

            var readingTask12 = File.ReadAllBytesAsync(filePath12);

            while (!readingTask12.IsCompleted)
            {
                await Task.Yield();
            }

            byte[] data12 = readingTask12.Result;

            byte[] widthByte12 = new byte[] { data12[data12.Length - 8], data12[data12.Length - 7], data12[data12.Length - 6], data12[data12.Length - 5] };
            byte[] heighthByte12 = new byte[] { data12[data12.Length - 4], data12[data12.Length - 3], data12[data12.Length - 2], data12[data12.Length - 1] };

            int width12 = BitConverter.ToInt32(widthByte12);
            int height12 = BitConverter.ToInt32(heighthByte12);

            Texture2D tex2Dmm12;

            if (postfix12 == key12.ExtPNG12)
                tex2Dmm12 = new Texture2D(width12, height12, TextureFormat.ETC2_RGBA8, false);
            else
                tex2Dmm12 = new Texture2D(width12, height12, TextureFormat.ETC2_RGB, false);

            tex2Dmm12.LoadRawTextureData(data12);
            tex2Dmm12.Apply(false, false);
            return tex2Dmm12;
        }
        else
        {
            using var request12 = UnityWebRequest.Get(url12 + name12);
            var operation12 = request12.SendWebRequest();

            while (!operation12.isDone)
            {
                await Task.Yield();
            }

            byte[] buffer12 = request12.downloadHandler.data;

            if (request12.result == UnityWebRequest.Result.Success)
            {
                if (!Directory.Exists(pathToMods12))
                {
                    Directory.CreateDirectory(pathToMods12);
                }

                if (!File.Exists(pathToMods12 + name12))
                {
                    await File.WriteAllBytesAsync(pathToMods12 + name12, buffer12);

                }

                int lastIndexOfDot12 = name12.LastIndexOf(key12.Dot12, StringComparison.Ordinal);
                int prefixLength12 = name12.Length - lastIndexOfDot12;
                string postfix12 = name12.Substring(lastIndexOfDot12, prefixLength12);
                string filePath12 = Application.persistentDataPath + "/" + _pathToHDD12 + name12;
                var readingTask12 = File.ReadAllBytesAsync(filePath12);

                while (!readingTask12.IsCompleted)
                {
                    await Task.Yield();
                }

                byte[] data12 = readingTask12.Result;

                byte[] widthByte12 = new byte[] { data12[data12.Length - 8], data12[data12.Length - 7], data12[data12.Length - 6], data12[data12.Length - 5] };
                byte[] heighthByte12 = new byte[] { data12[data12.Length - 4], data12[data12.Length - 3], data12[data12.Length - 2], data12[data12.Length - 1] };

                int width12 = BitConverter.ToInt32(widthByte12);
                int height12 = BitConverter.ToInt32(heighthByte12);

                Texture2D tex2Dmm12;

                if (postfix12 == key12.ExtPNG12)
                    tex2Dmm12 = new Texture2D(width12, height12, TextureFormat.ETC2_RGBA8, false);
                else
                    tex2Dmm12 = new Texture2D(width12, height12, TextureFormat.ETC2_RGB, false);

                tex2Dmm12.LoadRawTextureData(data12);
                tex2Dmm12.Apply(false, false);
                return tex2Dmm12;
            }
            else
            {
                // Debug.LogErrorFormat("error request [{0}, {1}]", url, request.error);
            }
        }

        return default;
    }
}
