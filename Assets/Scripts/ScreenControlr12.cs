using UnityEngine;

public class ScreenControlr12 : MonoBehaviour
{
    [SerializeField] private GameObject _phone12;
    [SerializeField] private GameObject _pad12;

    void Start()
    {
        if (Screen.width > 1500)
        {
            _phone12.SetActive(false);
            _pad12.SetActive(true);
        }
        else
        {
            _phone12.SetActive(true);
            _pad12.SetActive(false);
        }
    }
}
