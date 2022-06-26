using UnityEngine;
using UnityEngine.EventSystems;

public class MapsCategory12 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _category12;
    [SerializeField] private GenerateMap12 _mapGenerator12;
    [SerializeField] private FavoriteButton12 favoriteButton12;

    public void OnPointerClick(PointerEventData eventData12)
    {
        favoriteButton12.press12 = false;

        for (int i = 0; i < _mapGenerator12.modsList12.Count; i++)
        {
            if (_mapGenerator12.modsList12[i].GetComponent<Item12>().category12 == _category12)
            {
                _mapGenerator12.modsList12[i].gameObject.SetActive(true);
            }
            else
            {
                _mapGenerator12.modsList12[i].gameObject.SetActive(false);
            }
        }
    }
}
