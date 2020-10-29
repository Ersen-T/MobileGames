using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ButtonTextFadeIn : MonoBehaviour
{
    private Image _image;
    private IEnumerator _waitAndFade;

    private void Awake()
    {
        _image = gameObject.GetComponent<Image>();
        _image.color = new Color(_image.color.r, _image.color.g, _image.color.b, 255f);

        _waitAndFade = WaitAndFade();
    }

    private void Start()
    {
        StartCoroutine(_waitAndFade);
    }

    IEnumerator WaitAndFade()
    {
        yield return new WaitForSeconds(1.2f);
        _image.CrossFadeAlpha(0f, 0.5f, true);
    }
}
