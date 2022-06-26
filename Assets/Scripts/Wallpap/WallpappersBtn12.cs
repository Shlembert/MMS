using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class WallpappersBtn12 : MonoBehaviour
{
    private KeyStorage12 keys12;
    [SerializeField] private Button _downloadButton12;
    public string fileName12;
    private Text text12;
    private void Start()
    {
        keys12 = new KeyStorage12();
        text12 = _downloadButton12.transform.GetChild(0).GetComponent<Text>();
    }
    public async void DownloadButtonOnClickWallpapers12()
    {
        _downloadButton12.interactable = false;
        text12.text = keys12.Downloading12;

        var path12 = Path.Combine(Application.persistentDataPath, keys12.Wallpap12) + "Files/";
        var path122 = Path.Combine(Application.persistentDataPath, keys12.Wallpap12);
        if (!Directory.Exists(path12))
            Directory.CreateDirectory(path12);
        
        // TODO: change paht to hdd
        string file12 = keys12.UrlContent12 + fileName12;

        //byte[] byte12 = File.ReadAllBytes(file12);
        byte[] byte12 = File.ReadAllBytes(path122+fileName12);
        Texture2D tex2Dmm12;
        byte[] widthByte12 = new byte[] { byte12[byte12.Length - 8], byte12[byte12.Length - 7], byte12[byte12.Length - 6], byte12[byte12.Length - 5] };
        byte[] heighthByte12 = new byte[] { byte12[byte12.Length - 4], byte12[byte12.Length - 3], byte12[byte12.Length - 2], byte12[byte12.Length - 1] };

        int width12 = BitConverter.ToInt32(widthByte12);
        int height12 = BitConverter.ToInt32(heighthByte12);
        var postfix12 = fileName12.Split('.').Last();
        
        if (postfix12 == "png")
            tex2Dmm12 = new Texture2D(width12, height12, TextureFormat.ETC2_RGBA8, false);
        else
            tex2Dmm12 = new Texture2D(width12, height12, TextureFormat.ETC2_RGB, false);
        tex2Dmm12.Compress(false);
        tex2Dmm12.LoadRawTextureData(byte12);
        tex2Dmm12.Apply(false, false);
        Texture2D decompressTex12 = DeCompress12(tex2Dmm12);
        var bytes12 = decompressTex12.EncodeToJPG();

        await File.WriteAllBytesAsync(path12 + fileName12, bytes12);

        IOSBridge.IOStoUnityBridge.SaveImageToAlbum(path12 + fileName12);
        text12.text = keys12.Download12;
    }
    private static Texture2D DeCompress12(Texture2D source12)
    {
        RenderTexture renderTex12 = RenderTexture.GetTemporary(
            source12.width,
            source12.height,
            0,
            RenderTextureFormat.Default,
            RenderTextureReadWrite.Linear);

        Graphics.Blit(source12, renderTex12);
        RenderTexture previous12 = RenderTexture.active;
        RenderTexture.active = renderTex12;
        Texture2D readableText12 = new Texture2D(source12.width, source12.height);
        readableText12.ReadPixels(new Rect(0, 0, renderTex12.width, renderTex12.height), 0, 0);
        readableText12.Apply();
        RenderTexture.active = previous12;
        RenderTexture.ReleaseTemporary(renderTex12);
        return readableText12;
    }

}
