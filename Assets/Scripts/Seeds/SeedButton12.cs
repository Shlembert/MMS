 using UnityEngine;
using UnityEngine.UI;

public class SeedButton12 : MonoBehaviour
{
    [SerializeField] private Button _getURL12;
    [SerializeField] private Favorite12 card12;

    private void Awake()
    {
        _getURL12.onClick.AddListener(GetStringURL12);
    }

    private void GetStringURL12()
    {
        GUIUtility.systemCopyBuffer = card12.nameFile12;
        Debug.Log(card12.nameFile12);
        IOSBridge.IOStoUnityBridge.ShowAlert(card12.nameFile12, "");
    }
}
