using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Storage;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GenerateWallpap12 : MonoBehaviour
{
    [SerializeField] private GameObject _card12;
    [SerializeField] private Transform grid12;
    [SerializeField] private Texture2D _plag12;
    private DownloadController12 _downloadController12;
    private ContentWallpappers12 _content12;
    private KeyStorage12 keys12;
    public List<Transform> modsList12 = new List<Transform>();

    private FirebaseApp _firebaseApp;
    FirebaseStorage _storage;
    private StorageReference _gsReference;

    private void Awake()
    {
        keys12 = new KeyStorage12();
        _content12 = new ContentWallpappers12();
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
        string Url12 = await GetFirebaseStorageLink12(keys12.JsonWallp12);

        _content12 = await _downloadController12.DownloadWallpappersJson12(Url12, keys12.JsonWallp12);
        GeneratorCards12();
    }

    private async void GeneratorCards12()
    {
        var favoriteCardList12 = _downloadController12.furFavorite;

        foreach (var var4ik12 in _content12.Z51Eti5List)
        {
            string name12 = var4ik12.Z51Eti5T3;
            GameObject g12 = Instantiate(_card12, grid12);
            g12.name = name12;
            g12.GetComponent<Item12>().myFile12 = name12;
            g12.GetComponent<WallpapIconControll12>().imageURL12 = await GetFirebaseStorageLink12(keys12.WallpPath12 + name12);
            
            g12.GetComponent<WallpapIconControll12>().imageName12 = name12;

            foreach (var xFur in favoriteCardList12.Where(x => x.Name12 == g12.name))
            {
                g12.GetComponent<Item12>().favorite12 = true;
                g12.GetComponent<Item12>().Faforite12(true);
                _downloadController12.favotireListFur.Add(g12.transform);
            }
            modsList12.Add(g12.transform);

            g12.SetActive(true);
        }
    }
}
