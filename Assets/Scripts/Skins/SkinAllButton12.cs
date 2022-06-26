using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SkinAllButton12 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GenerateSkins12 _generator12;
    [SerializeField] private Button _buttonAll12;
    [SerializeField] private FavoriteButton12 _favoriteButton12;

    public void OnPointerClick(PointerEventData eventData12)
    {
        _favoriteButton12.press12 = false;
        for (int i = 0; i < _generator12.modsList12.Count; i++)
        {
            _generator12.modsList12[i].gameObject.SetActive(true);
        }
    }
}
