using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TopMenuCategory12 : MonoBehaviour
{
    [SerializeField] private Sprite[] _sprites12;
    [Space]
    [SerializeField] private Font _down12;
    [SerializeField] private Font _up12;
    [Space]
    [SerializeField] private Color _downColor12;
    [SerializeField] private Color _upColor12;
    [Space]
    [SerializeField] private ScrollRect scroll12;
    [SerializeField] private List<Button> buttons12;
    [SerializeField] private GameObject data12;
    [SerializeField] private GameObject dataPad12;
    
    public string _subcategoryName12;

    private void Start()
    {
        _subcategoryName12 = "All";
    }

    public void ChangeColor12(Button button12)
    {
        _subcategoryName12 = button12.transform.GetChild(0).GetComponent<Text>().text;
        
        foreach (var but12 in buttons12)
        {
            but12.transform.GetChild(0).GetComponent<Text>().color = _upColor12;
            but12.transform.GetChild(0).GetComponent<Text>().font = _up12;
            but12.GetComponent<Image>().sprite = _sprites12[1];
        }

        button12.transform.GetChild(0).GetComponent<Text>().color = _downColor12;
        button12.transform.GetChild(0).GetComponent<Text>().font = _down12;
        button12.GetComponent<Image>().sprite = _sprites12[0];

        scroll12.verticalNormalizedPosition = 10f;
    }

    public string GetSubcategoryName12()
    {
        return _subcategoryName12;
    }
}
