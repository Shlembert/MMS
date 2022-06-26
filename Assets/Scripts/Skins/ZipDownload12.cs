using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ZipDownload12 : MonoBehaviour
{
    [SerializeField] private Button _button12;
    [SerializeField] private Favorite12 favorite12;
    [SerializeField] private Button install12;
    private KeyStorage12 keys12;
    public string fileURL12;
    public string fileName12;
    private string pathToSkins12;
    private Text _text12;
   
    Utility.FileZipCreator zipCreator12 = new Utility.FileZipCreator();

    private void Awake()
    {
        keys12 = new KeyStorage12();
        _button12.onClick.AddListener(TaskOnClick12);
        install12.onClick.AddListener(TaskOnClickInstall12);
        _text12 = _button12.transform.GetChild(0).GetComponent<Text>();
    }

    public void TextButtonChange12()
    {
        _text12.text = keys12.Download12;
    }

    public void TaskOnClick12()
    {
        fileURL12 = GetComponent<Favorite12>().description12;
        fileName12 = GetComponent<Favorite12>().nameFile12;
        _text12.text = keys12.Downloading12;
        StartCoroutine(DownloadUVSkin12());
    }

    private IEnumerator DownloadUVSkin12()
    {
        UnityWebRequest request12 = new UnityWebRequest(fileURL12)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        pathToSkins12 = Path.Combine(Application.persistentDataPath, keys12.UV12);

        yield return request12.SendWebRequest();

        if (request12.result == UnityWebRequest.Result.Success)
        {
            if (!Directory.Exists(pathToSkins12))
            {
                Directory.CreateDirectory(pathToSkins12);
            }

            byte[] buffer12 = request12.downloadHandler.data;

            if (!File.Exists(pathToSkins12 + fileName12))
            {
                File.WriteAllBytes(pathToSkins12 + fileName12, buffer12);
            }
        }

        fileName12 = Path.GetFileNameWithoutExtension(fileName12);

        if (request12.isDone)
        {
            _button12.gameObject.SetActive(false);
            install12.gameObject.SetActive(true);
        }

        request12.Dispose();
    }

    private void TaskOnClickInstall12()
    {
        IOSBridge.IOStoUnityBridge.InitWithActivity(
            zipCreator12.CreateSkinFile(pathToSkins12 + fileName12 + keys12.ExtPNG12, fileName12, fileName12));
        IOSBridge.IOStoUnityBridge.ShowAlert(keys12.Download12, "");
    }
}
