using UnityEngine;
using UnityEngine.UI;

public class CreditsButton : MonoBehaviour
{
    [SerializeField] private GameObject _creditsBackground;

    private Button _creditsButton;

    private void Awake()
    {
        _creditsButton = gameObject.GetComponent<Button>();
        _creditsButton.onClick.AddListener(Credits);
        _creditsBackground.SetActive(false);
    }

    private void Credits()
    {
        _creditsBackground.SetActive(true);
    }
}
