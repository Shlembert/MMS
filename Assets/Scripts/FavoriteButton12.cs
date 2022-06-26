using UnityEngine;
using UnityEngine.EventSystems;

public class FavoriteButton12 : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _content12;
    [SerializeField] private GenerateMods12 _gernerator12;
    [SerializeField] private GenerateMap12 _mapGenerator12;
    [SerializeField] private GenerateSkins12 _skinGenegator12;
    [SerializeField] private GenerateSeed _textureGenegator12;
    [SerializeField] private GenerateWallpap12 _wallGenegator12;

    public bool press12 = false;
    
    public void OnPointerClick(PointerEventData eventData12)
    {
        press12 = true;

        if(_gernerator12 != null)
        {
            foreach (var item12 in _gernerator12.modsList12)
            {
                if (item12.GetComponent<Item12>().favorite12)
                {
                    item12.gameObject.SetActive(true);
                }
                else
                {
                    item12.gameObject.SetActive(false);
                }
            }
        }
        if (_mapGenerator12 != null)
        {
            foreach (var item12 in _mapGenerator12.modsList12)
            {
                if (item12.GetComponent<Item12>().favorite12)
                {
                    item12.gameObject.SetActive(true);
                }
                else
                {
                    item12.gameObject.SetActive(false);
                }
            }
        }
        if (_skinGenegator12 != null)
        {
            foreach (var item12 in _skinGenegator12.modsList12)
            {
                if (item12.GetComponent<Item12>().favorite12)
                {
                    item12.gameObject.SetActive(true);
                }
                else
                {
                    item12.gameObject.SetActive(false);
                }
            }
        }
        if (_textureGenegator12 != null)
        {
            foreach (var item12 in _textureGenegator12.modsList12)
            {
                if (item12.GetComponent<Item12>().favorite12)
                {
                    item12.gameObject.SetActive(true);
                }
                else
                {
                    item12.gameObject.SetActive(false);
                }
            }
        }

        if (_wallGenegator12 != null)
        {
            foreach (var item12 in _wallGenegator12.modsList12)
            {
                if (item12.GetComponent<Item12>().favorite12)
                {
                    item12.gameObject.SetActive(true);
                }
                else
                {
                    item12.gameObject.SetActive(false);
                }
            }
        }
    }
}
