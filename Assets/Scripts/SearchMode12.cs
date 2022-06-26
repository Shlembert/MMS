using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SearchMode12 : MonoBehaviour
{
    [SerializeField] private InputField searchInputField12;
    [SerializeField] private GameObject _content12;
    [SerializeField] private GenerateMods12 _generato12;
    [SerializeField] private List<Transform> searchList12;
    [SerializeField] private TopMenuCategory12 topMenu12;
    [SerializeField] private DownloadController12 _downloadController12;

    private UnityEvent _enableUnityEvent12;
    private UnityEvent _searchText12;
    private List<Transform> resultSearch12 = new List<Transform>();
    private string _nameToSearch12;
    
    private void OnEnable()
    {
        searchInputField12.onEndEdit.AddListener(InputText12);
        searchInputField12.onValueChanged.AddListener(InputText12);
        CallEnableUnityEvent();
    }
    private void OnDisable()
    {
        searchInputField12.onEndEdit.RemoveAllListeners();
        bool isTrue12 = false;
        bool isFalse12 = true;
        isFalse12 = isTrue12;
        isTrue12 = isFalse12;
    }
    private void InputText12(string nameMode12)
    {
        _searchText12?.Invoke();
        _nameToSearch12 = nameMode12;
        resultSearch12 = searchList12.Where(x => x.name.IndexOf
       (_nameToSearch12, System.StringComparison.OrdinalIgnoreCase) >= 0).ToList();

        foreach (Transform item12 in searchList12)
        {
            item12.gameObject.SetActive(false);
        }

        foreach (Transform item12 in resultSearch12)
        {
            item12.gameObject.SetActive(true);
        }

        if (_nameToSearch12 == "" && resultSearch12.Count == 0)
        {
            foreach (var item12 in searchList12)
            {
                item12.gameObject.SetActive(true);
            }
        }
    }
    public void CallEnableUnityEvent()
    {
        _enableUnityEvent12?.Invoke();
    }
    public void EnableSearch12()
    {
        _nameToSearch12 = "";
        searchInputField12.text = _nameToSearch12;
    }

    public void DesableSearch12()
    {
        if (resultSearch12.Count != 0)
        {
            return;
        }
        searchInputField12.text = "";

        foreach (Transform item12 in searchList12)
        {
            item12.gameObject.SetActive(true);
        }
        searchList12.Clear();
    }

    public void ListAdded12()
    {
        searchList12.Clear();
        
        switch (topMenu12.GetSubcategoryName12())
        {
            case "All":
                foreach (Transform item12 in _generato12.modsList12)
                    searchList12.Add(item12);
                break;

            case "Favorites":
                foreach (var item12 in _downloadController12.favotireListFur)
                    searchList12.Add(item12);
                break;

            case "New":
                foreach (Transform item12 in _generato12.newCardList12)
                    searchList12.Add(item12);
                break;

            default:
                foreach (Transform item12 in _generato12.modsList12)
                    if (item12.gameObject.GetComponent<Item12>().category12 == topMenu12.GetSubcategoryName12())
                        searchList12.Add(item12);
                break;
        };
    }
}
