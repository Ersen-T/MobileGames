using UnityEngine;
using UnityEngine.UI;

public class MainMenuCanvasController : MonoBehaviour
{
    [SerializeField] private GameObject _front;
    [SerializeField] private GameObject _info;

    [SerializeField] private Button _infoButton;
    [SerializeField] private Button _backButton;

    private void Awake()
    {
        _front.SetActive(true);
        _info.SetActive(false);

        _infoButton.onClick.AddListener(InfoMenu);
        _backButton.onClick.AddListener(BackToFront);
    }

    private void InfoMenu()
    {
        _front.SetActive(false);
        _info.SetActive(true);
    }

    private void BackToFront()
    {
        _front.SetActive(true);
        _info.SetActive(false);
    }
}
