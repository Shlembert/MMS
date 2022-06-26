using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ChangeColorSpriteButton : MonoBehaviour, IPointerEnterHandler, IPointerUpHandler, IPointerDownHandler
{
    [SerializeField] private Color _white12;
    [SerializeField] private Color _orange12;
    [SerializeField] private Sprite _upButton12;
    [SerializeField] private Sprite _downButton12;


    public void OnPointerUp(PointerEventData eventData12)
    {
        gameObject.GetComponent<Image>().sprite = _upButton12;
        transform.GetChild(0).GetComponent<Text>().color = _white12;
    }

    public void OnPointerEnter(PointerEventData eventData12)
    {
        //gameObject.GetComponent<Image>().sprite = _downButtonFur;
        //transform.GetChild(0).GetComponent<Text>().color = _orangeFur;
    }

    public void OnPointerDown(PointerEventData eventData12)
    {
        gameObject.GetComponent<Image>().sprite = _downButton12;
        transform.GetChild(0).GetComponent<Text>().color = _orange12;
    }
}
