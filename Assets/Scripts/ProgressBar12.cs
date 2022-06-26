using System.Collections;
using UnityEngine;

public class ProgressBar12 : MonoBehaviour
{
    [SerializeField] private GameObject _data12;
    [SerializeField] private GameObject _mod12;

    private void Awake()
    {
        StartCoroutine(Hide12());
    }

    private IEnumerator Hide12()
    {
        yield return new WaitForSecondsRealtime(3f);
        gameObject.SetActive(false);
        _data12.SetActive(true);
        _mod12.SetActive(true);
        yield break;
    }
}
