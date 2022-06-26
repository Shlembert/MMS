using UnityEngine;
using UnityEngine.EventSystems;

public class SkinCategory12 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _category12;
    [SerializeField] private GenerateSkins12 _skinGenegator12;
    [SerializeField] private FavoriteButton12 _favoriteButton12;

    public void OnPointerClick(PointerEventData eventData12)
    {
        for (int i = 0; i < _skinGenegator12.modsList12.Count; i++)
        {
            _favoriteButton12.press12 = false;

            if (_skinGenegator12.modsList12[i].GetComponent<Item12>().category12 == _category12)
            {
                _skinGenegator12.modsList12[i].gameObject.SetActive(true);
            }
            else
            {
                _skinGenegator12.modsList12[i].gameObject.SetActive(false);
            }
        }
    }
}
