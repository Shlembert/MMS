using System.Collections;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonDownload12 : MonoBehaviour
{
    [SerializeField] private Button _button12;
    [SerializeField] private Button _install12;
    [SerializeField] private Favorite12 favorite12;
    [SerializeField] private string _category12;
    private KeyStorage12 keys12;
    private string _fileURL12;
    private string _fileName12;
    private string _filePath12;
    private Text _text12;
    
    private void Awake()
    {
        keys12 = new KeyStorage12();
        _button12.onClick.AddListener(TaskOnClick12);
        _install12.onClick.AddListener(InstallClick12);
        _text12 = _button12.transform.GetChild(0).GetComponent<Text>();
    }

    public void TextButtonChange12()
    {
        _text12.text = keys12.Download12;
    }

    private void TaskOnClick12()
    {
        _text12.text = keys12.Downloading12;
        _fileURL12 = favorite12.file12;
        _fileName12 = favorite12.nameFile12;
        StartCoroutine(DownloadUVSkin12());
    }

    private IEnumerator DownloadUVSkin12()
    {
        UnityWebRequest request12 = new UnityWebRequest(_fileURL12)
        {
            downloadHandler = new DownloadHandlerBuffer()
        };

        string pathToSkins12 = Path.Combine(Application.persistentDataPath, "Data/Temp/");
       
        yield return request12.SendWebRequest();

        if (request12.result == UnityWebRequest.Result.Success)
        {
            if (!Directory.Exists(pathToSkins12))
            {
                Directory.CreateDirectory(pathToSkins12);
            }

            byte[] buffer12 = request12.downloadHandler.data;

            if (!File.Exists(pathToSkins12 + _fileName12))
            {
                File.WriteAllBytes(pathToSkins12 + _fileName12, buffer12);
            }
        }

        _filePath12 = pathToSkins12 + _fileName12;

        if (request12.isDone)
        {
            _button12.gameObject.SetActive(false);
            _install12.gameObject.SetActive(true);
        }
            request12.Dispose();
    }

    private void InstallClick12()
    {
        IOSBridge.IOStoUnityBridge.InitWithActivity(_filePath12);
    }
}
