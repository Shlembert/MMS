using UnityEngine;
using UnityEngine.UI;

public class AllButton12 : MonoBehaviour
{
    [SerializeField] private GenerateMods12 _generator12;
    [SerializeField] private Button _buttonAll12;
    [SerializeField] private FavoriteButton12 favoriteButton12;

    private void Awake()
    {
        _buttonAll12.onClick.AddListener(TaskOnClick12);
    }

    public void TaskOnClick12()
    {
        favoriteButton12.press12 = false;

        for (int i = 0; i < _generator12.modsList12.Count; i++)
        {
            _generator12.modsList12[i].gameObject.SetActive(true);
        }
    }
}