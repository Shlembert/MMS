using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NickNameGenerator12 : MonoBehaviour
{
    [SerializeField] private GameObject shtora12;
    [SerializeField] private GameObject startPanel12;
    [SerializeField] private GameObject downloadNick12;
    [SerializeField] private GameObject hold12;
    [SerializeField] private Text nick12;
    private KeyStorage12 keys12;

    private void Start()
    {
        keys12 = new KeyStorage12();
    }
    public void GenerateNick12()
    {
        hold12.SetActive(false);
        shtora12.SetActive(true);
        startPanel12.SetActive(true);
        downloadNick12.SetActive(false);
        StartCoroutine(Genere12());
    }

    private IEnumerator Genere12()
    {
        
        yield return new WaitForSeconds(3f);
        SetNick12();
        startPanel12.SetActive(false);
        shtora12.SetActive(false);
        downloadNick12.SetActive(true);
        hold12.SetActive(false);
        yield break;
    }

    public List<NickName12> GetNicknameList12()
    {
        var nicknameObjectAsset12 = Resources.Load<TextAsset>("1");
        var nicknameObject12 =
            JsonConvert.DeserializeObject<NickNameJson12>(nicknameObjectAsset12.text);
        if (nicknameObject12 == null) return new List<NickName12>();
        var nicknameListMcm = nicknameObject12.NickNameList12.ToList();
        return nicknameListMcm;
    }

    private void SetNick12()
    {
        var list12 = GetNicknameList12();
        var random = new System.Random().Next(0, list12.Count - 1);
        nick12.text = list12[random].Name12;
    }

    public void GetAlert12()
    {
        GUIUtility.systemCopyBuffer = nick12.text;
        IOSBridge.IOStoUnityBridge.ShowAlert(keys12.Copy12, nick12.text);
        Debug.Log(nick12.text);
    }
}
