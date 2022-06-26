using Cysharp.Threading.Tasks;
using Firebase;
using Firebase.Storage;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GenerateSeed : MonoBehaviour
{
    [SerializeField] private GameObject _card12;
    [SerializeField] private Transform grid12;
    [SerializeField] private Texture2D _plag12;
    private DownloadController12 _downloadController12;
    private Content12 _content12;
    private KeyStorage12 keys12;
    public List<Transform> newCardList12 = new List<Transform>();
    private int _newCard = 2;
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

    private async void GeneratorCards12()
    {
        var favoriteCardList12 = _downloadController12.furFavorite;

        foreach (var var4ik12 in _content12.SjoxI9Qs1.Seeds.Reverse())
        {
            string name12 = var4ik12.Value[keys12.SeedNameKey12].Split('/')[0];
            string desct12 = var4ik12.Value[keys12.SeedDescription12];
            GameObject g12 = Instantiate(_card12, grid12);

            g12.transform.GetChild(1).GetComponent<Text>().text = name12.Length > 11 ? name12[..10] + keys12.DotThree12 : name12;
            g12.transform.GetChild(2).GetComponent<Text>().text = desct12.Length > 45 ? desct12[..40] + keys12.DotThree12 : desct12;
            g12.name = var4ik12.Value[keys12.SeedNameKey12].Split('/')[0];
            g12.GetComponent<Item12>().category12 = keys12.SeedPathToBak12;
            g12.GetComponent<Item12>().myNameFile12 = var4ik12.Value[keys12.SeedFile12];
            g12.GetComponent<Item12>().myDecription12 = var4ik12.Value[keys12.SeedDescription12];
            string fileNameIcon12 = var4ik12.Value[keys12.SeedtIconKey12].Split('/')[1];

            g12.GetComponent<IconController12>().imageName12 = fileNameIcon12;
            g12.GetComponent<IconController12>().imageURL12 = await GetFirebaseStorageLink12(keys12.SeedPathToBak12 + fileNameIcon12);

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
                g12.transform.GetChild(4).gameObject.SetActive(true);
                newCardList12.Add(g12.transform);
            }
        }
    }  
}
