using UnityEngine;
using UnityEngine.UI;

public class BackButton : MonoBehaviour
{
    [SerializeField] private GameObject _rulesBackground;
    [SerializeField] private GameObject _creditsBackground;

    private Button _backButton;

    private void Awake()
    {
        _backButton = gameObject.GetComponent<Button>();
        _backButton.onClick.AddListener(Back);
    }

    private void Back()
    {
        _rulesBackground.SetActive(false);
        _creditsBackground.SetActive(false);
    }
}