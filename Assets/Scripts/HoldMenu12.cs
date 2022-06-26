using UnityEngine;
using UnityEngine.EventSystems;

public class HoldMenu12 : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private GameObject hold12;

    public void OnPointerDown(PointerEventData eventData12)
    {
        hold12.SetActive(true);
    }

    public void OnPointerUp(PointerEventData eventData12)
    {
        hold12.SetActive(false);
    }
}
