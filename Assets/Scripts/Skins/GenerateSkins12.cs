using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Storage;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateSkins12 : MonoBehaviour
{
    [SerializeField] private GameObject _card12;
    [SerializeField] private Transform _grid12;
    [SerializeField] private Texture2D _plag12;
    DownloadController12 _downloadController12;
    private KeyStorage12 keys12;
    private Content12 _content12;
    public List<Transform> newCardList12 = new List<Transform>();
    private int _newCard = 8;
    public List<Transform> modsList12 = new List<Transform>();

    private FirebaseApp _firebaseApp;
    FirebaseStorage _storage;
    private StorageReference _gsReference;

    private void Awake()
    {
        keys12 = new KeyStorage12();
        _content12 = new Content12();
        _downloadController12 = gameObject.AddComponent<DownloadController12>();
        _firebaseApp = FirebaseApp.Create();
        _storage = FirebaseStorage.DefaultInstance;
        _gsReference = _storage.GetReferenceFromUrl(keys12.UrlContent12);
    }

    public async UniTask<string> GetFirebaseStorageLink12(string pathToURL12)
    {
        StorageReference storageFileReference12 = _gsReference.Child(pathToURL12);
        var url12 = await storageFileReference12.GetDownloadUrlAsync();
        return url12.ToString();
    }

    private async void Start()
    {
        string Url12 = await GetFirebaseStorageLink12(keys12.JsonName12);
        _content12 = await _downloadController12.DownloadJson12(Url12, keys12.JsonName12);
        GeneratorCards12();
    }

    private async void SetParamCard12(Dictionary<string, Dictionary<string, string>> keyValues12, string categry12)
    {
        var favoriteCardList12 = _downloadController12.furFavorite;

        foreach (var var4ik12 in keyValues12.Reverse())
        {
            GameObject g12 = Instantiate(_card12, _grid12);
            g12.name = var4ik12.Value[keys12.SkinNameKey12].Split('/')[2];
            g12.GetComponent<Item12>().category12 = categry12;
            string fileNameFile = var4ik12.Value[keys12.SkinFile12].Split('/')[2];
            g12.GetComponent<Item12>().myNameFile12 = fileNameFile;
            g12.GetComponent<Item12>().myDecription12 = await GetFirebaseStorageLink12(keys12.SkinPathToBakSkn12 + fileNameFile);
            string fileNameIcon12 = var4ik12.Value[keys12.SkinIconconKey12].Split('/')[2];
            g12.GetComponent<IconController12>().imageName12 = fileNameIcon12;
             g12.GetComponent<IconController12>().imageURL12 = await GetFirebaseStorageLink12(keys12.SkinPathToBakImg12 + fileNameIcon12);

            foreach (var x12 in favoriteCardList12.Where(x => x.Name12 == g12.name))
            {
                g12.GetComponent<Item12>().favorite12 = true;
                g12.GetComponent<Item12>().Faforite12(true);
                _downloadController12.favotireListFur.Add(g12.transform);
            }
            modsList12.Add(g12.transform);
            g12.SetActive(true);

            if (_newCard > 0)
            {
                _newCard--;
                g12.transform.GetChild(2).gameObject.SetActive(true);
                newCardList12.Add(g12.transform);
            }
        }
    }

    private void GeneratorCards12()
    {
        SetParamCard12(_content12.Mlkw1Cn.MommyLongLegs, keys12.SkinCategory_112);
        SetParamCard12(_content12.Mlkw1Cn.Princess, keys12.SkinCategory_212);
        SetParamCard12(_content12.Mlkw1Cn.Mermaid, keys12.SkinCategory_312);
        SetParamCard12(_content12.Mlkw1Cn.Cute, keys12.SkinCategory_412);
        SetParamCard12(_content12.Mlkw1Cn.Anime, keys12.SkinCategory_512);
        SetParamCard12(_content12.Mlkw1Cn.Pink, keys12.SkinCategory_612);
        SetParamCard12(_content12.Mlkw1Cn.Superheroes, keys12.SkinCategory_712);
        SetParamCard12(_content12.Mlkw1Cn.Girls, keys12.SkinCategory_812);
    } 
}
