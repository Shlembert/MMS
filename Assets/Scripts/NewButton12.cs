using UnityEngine;
using UnityEngine.EventSystems;

public class NewButton12 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GenerateMods12 _generator12;
    [SerializeField] private FavoriteButton12 favoriteButton12;
    public bool p12 = false;

    public void OnPointerClick(PointerEventData eventData12)
    {
        favoriteButton12.press12 = false;

        var result12 = _generator12.newCardList12;

        foreach (var item12 in _generator12.modsList12)
        {
            item12.gameObject.SetActive(false);
        }

        foreach (var item12 in result12)
        {
            item12.gameObject.SetActive(true);
        }
    }
}
