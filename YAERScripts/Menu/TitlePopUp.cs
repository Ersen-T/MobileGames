using System.Collections;
using UnityEngine;

public class TitlePopUp : MonoBehaviour
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
        yield return new WaitForSeconds(0.2f);
        LeanTween.scale(gameObject, new Vector2(1f, 1f), 0.25f);//.setEase(LeanTweenType.easeOutBounce);
    }
}
