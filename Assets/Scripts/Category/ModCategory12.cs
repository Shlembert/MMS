using UnityEngine;
using UnityEngine.EventSystems;

public class ModCategory12 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private string _category12;
    [SerializeField] private GenerateMods12 _modCategory12;
    [SerializeField] private FavoriteButton12 _favoriteButton12;

    public void OnPointerClick(PointerEventData eventData12)
    {
        _favoriteButton12.press12 = false;

        for (int i = 0; i < _modCategory12.modsList12.Count; i++)
        {
            if (_modCategory12.modsList12[i].GetComponent<Item12>().category12 == _category12)
            {
                _modCategory12.modsList12[i].gameObject.SetActive(true);
            }
            else
            {
                _modCategory12.modsList12[i].gameObject.SetActive(false);
            }
        }
    }
}
