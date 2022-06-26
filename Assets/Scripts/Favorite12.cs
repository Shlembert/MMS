using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Favorite12 : MonoBehaviour
{
    [SerializeField] private Button _favoriteButton12;
    [SerializeField] private GameObject _content12;
    [SerializeField] private FavoriteButton12 favoriteButton12;
    [SerializeField] private DownloadController12 _controllerQw12;
    public bool _favorite12 = false;
    public string name12;
    public string file12;
    public string nameFile12;
    public string icon12;
    public string description12;
    public Image favoriteIcon12;
    public Sprite[] favoriteSprite12;

    private void Awake()
    {
        _favoriteButton12.onClick.AddListener(TaskOnClick12);
    }

    private void TaskOnClick12()
    {
        _favorite12 = !_favorite12;

        if (!_favorite12)
        {
            favoriteIcon12.sprite = favoriteSprite12[1];
            FavoriteCard12 favoriteCard12 = new FavoriteCard12()
            {
                Name12 = name12
            };
            foreach (var item12 in _controllerQw12.furFavorite.Where(item12 => item12.Name12 == favoriteCard12.Name12))
            {
                _controllerQw12.furFavorite.Remove(item12);
                break;
            }
        }
        else
        {
            favoriteIcon12.sprite = favoriteSprite12[0];
            _controllerQw12.furFavorite.Add(new FavoriteCard12()
            {
                Name12 = name12
            }) ;
        }

        foreach (Item12 item12 in _content12.GetComponentsInChildren<Item12>())
        {
            if (item12.name == name12)
            {
                item12.favorite12 = _favorite12;
                item12.Faforite12(_favorite12);

                if (favoriteButton12.press12 && !_favorite12)
                {
                    item12.gameObject.SetActive(false);
                }
            }
            ConfigFileUtils12.FavoriteToFile12(_controllerQw12.furFavorite);
        }
    }
}
