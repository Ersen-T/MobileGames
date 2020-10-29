using System.Collections;
using UnityEngine;

public class FizzPopUp : MonoBehaviour
{
    private IEnumerator _waitAndPopUp;

    private void Awake()
    {
        gameObject.transform.localScale = new Vector2(0f, 0f);

        _waitAndPopUp = WaitAndPopUp();
    }

    private void Start()
    {
        StartCoroutine(_waitAndPopUp);
    }

    IEnumerator WaitAndPopUp()
    {
        yield return new WaitForSeconds(0.3f);
        LeanTween.scale(gameObject, new Vector2(1f, 1f), 0.5f).setEase(LeanTweenType.easeOutBounce);
    }
}
