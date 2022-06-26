using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class MiniFavorite12 : MonoBehaviour
{
    private Button _button12;
    [SerializeField] private Item12 _item12;
    [SerializeField] private FavoriteButton12 _favoriteButton12;
    [SerializeField] private DownloadController12 _controller12;
    public Image favoriteIcon12;
    public Sprite[] favoriteSprite12;

    private void Awake()
    {
        _button12 = GetComponent<Button>();
        _button12.onClick.AddListener(TaskOnClick12);
    }

    private void TaskOnClick12()
    {
        _item12.favorite12 = !_item12.favorite12;

        if (!_item12.favorite12)
        {
            favoriteIcon12.sprite = favoriteSprite12[1];

            if (_favoriteButton12.press12)
            {
                _item12.gameObject.SetActive(false);
            }

            FavoriteCard12 favoriteCard12 = new FavoriteCard12()
            {
                Name12 = _item12.name
            };
           
            foreach (var item12 in _controller12.furFavorite.Where(x => x.Name12 == favoriteCard12.Name12))
            {
                _controller12.furFavorite.Remove(item12);
                _controller12.favotireListFur.Remove(_item12.transform);
                break;
            }
        }
        else
        {
            favoriteIcon12.sprite = favoriteSprite12[0];
            _controller12.favotireListFur.Add(_item12.transform);
            _controller12.furFavorite.Add(new FavoriteCard12()
            {
                Name12 = _item12.name
            });
           
        }

        ConfigFileUtils12.FavoriteToFile12(_controller12.furFavorite);
    }
}
