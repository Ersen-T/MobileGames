using System.Collections;
using UnityEngine;

public class BuzzSlide : MonoBehaviour
{
    private IEnumerator _waitAndSlide;

    private void Awake()
    {
        gameObject.transform.localPosition = new Vector2(-1000f, gameObject.transform.localPosition.y);

        _waitAndSlide = WaitAndSlide();
    }

    private void Start()
    {
        StartCoroutine(_waitAndSlide);
    }

    IEnumerator WaitAndSlide()
    {
        yield return new WaitForSeconds(0.6f);
        LeanTween.moveLocalX(gameObject, 36f, 0.5f).setEase(LeanTweenType.easeOutBounce);
    }
}
