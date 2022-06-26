using UnityEngine;
using UnityEngine.UI;

public class Item12 : MonoBehaviour
{
    [SerializeField] private Sprite[] _favoriteSprite12;
    [SerializeField] private Image _favoriteIcon12;
    [SerializeField] private GameObject _card12;
    [SerializeField] private Text _description12;
    [SerializeField] private Text _name12;
    [SerializeField] private ScrollRect _scrollRect12;
    [SerializeField] private DownloadController12 _downloadController12;

    public string myName12;
    public string myFile12;
    public string myNameFile12;
    public string myIcon12;
    public string category12;
    public string myDecription12;
    public bool favorite12;

    private Button button12;

    private void Awake()
    {
        button12 = GetComponent<Button>();
        myName12 = gameObject.name;
        button12.onClick.AddListener(TaskOnClick12);
    }

    public bool Faforite12(bool value12)
    {
        if (value12)
        {
            _favoriteIcon12.sprite = _favoriteSprite12[0];
            _downloadController12.favotireListFur.Add(gameObject.transform);
        }
        else
        {
            _favoriteIcon12.sprite = _favoriteSprite12[1];
            _downloadController12.favotireListFur.Remove(gameObject.transform);
        }
        return value12;
    }

    private void TaskOnClick12()
    {
        _card12.GetComponent<Favorite12>().name12 = myName12;
        _card12.GetComponent<Favorite12>().file12 = myFile12;
        _card12.GetComponent<Favorite12>().nameFile12 = myNameFile12;

        if (_card12.transform.GetChild(1).transform.GetChild(3).GetComponent<WallpappersBtn12>() != null)
        {
            _card12.transform.GetChild(1).transform.GetChild(3).GetComponent<WallpappersBtn12>().fileName12 = myFile12;
        }

        _card12.GetComponent<Favorite12>().icon12 = myIcon12;
        _card12.GetComponent<Favorite12>().description12 = myDecription12;

        if (_scrollRect12 != null) _scrollRect12.verticalNormalizedPosition = 10f;

        if (_name12)
        {
            _name12.text = myName12;
        }

        if (_card12.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>())
        {
            _card12.transform.GetChild(1).transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture =
                transform.GetChild(0).transform.GetChild(0).GetComponent<RawImage>().texture;
        }

        if (_card12.transform.GetChild(1).transform.GetChild(4).GetComponent<Text>()!=null)
        {
            _card12.transform.GetChild(1).transform.GetChild(4).GetComponent<Text>().text = 
                transform.GetChild(1).GetComponent<Text>().text;
        }

        if (_description12 != null)
        {
            _description12.text = myDecription12;
        }

        if (favorite12)
        {
            _card12.GetComponent<Favorite12>()._favorite12 = true;
            _card12.GetComponent<Favorite12>().favoriteIcon12.sprite = 
                _card12.GetComponent<Favorite12>().favoriteSprite12[0];
        }
        else
        {
            _card12.GetComponent<Favorite12>()._favorite12 = false;
            _card12.GetComponent<Favorite12>().favoriteIcon12.sprite = 
                _card12.GetComponent<Favorite12>().favoriteSprite12[1];
        }

        _card12.SetActive(true);
    }
}
