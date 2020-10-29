using System.Collections;
using UnityEngine;

public class RunnerSlide : MonoBehaviour
{
    private IEnumerator _waitAndSlide;

    private void Awake()
    {
        gameObject.transform.localPosition = new Vector2(-650f, gameObject.transform.localPosition.y);

        _waitAndSlide = WaitAndSlide();
    }

    private void Start()
    {
        StartCoroutine(_waitAndSlide);
    }

    IEnumerator WaitAndSlide()
    {
        yield return new WaitForSeconds(0.4f);
        LeanTween.moveLocalX(gameObject, 335f, 0.2f);//.setEase(LeanTweenType.easeOutBounce);
    }
}
