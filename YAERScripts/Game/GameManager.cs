using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _menuButton;
    [SerializeField] private Button _backButton;
    [SerializeField] private Button _buttonVibrate;
    [SerializeField] private Button _buttonVibrateOff;

    [SerializeField] private GameObject _front;
    [SerializeField] private GameObject _menu;

    [SerializeField] private TextMeshProUGUI _countdownText;

    private static bool _vibrateCurrent = true;

    private void Awake()
    {
        SetCanvas();

        AddListeners();

        SetVibrationState();
    }

    private void Update()
    {
        GameOver();
    }

    private void SetCanvas()
    {
        _front.SetActive(true);
        _menu.SetActive(false);

        _restartButton.gameObject.SetActive(false);
        _menuButton.gameObject.SetActive(false);
    }

    private void AddListeners()
    {
        _restartButton.onClick.AddListener(Restart);
        _mainMenuButton.onClick.AddListener(MainMenu);
        _menuButton.onClick.AddListener(Menu);
        _backButton.onClick.AddListener(BackToFront);
        _buttonVibrate.onClick.AddListener(VibrateOff);
        _buttonVibrateOff.onClick.AddListener(VibrateOn);
    }

    private void SetVibrationState()
    {
        if (_vibrateCurrent)
            Vibration.On();

        if (Vibration.Status == true)
        {
            Vibration.On();
            _buttonVibrate.gameObject.SetActive(true);
            _buttonVibrateOff.gameObject.SetActive(false);
        }
        else
        {
            Vibration.Off();
            _buttonVibrate.gameObject.SetActive(false);
            _buttonVibrateOff.gameObject.SetActive(true);
        }
    }

    public void Restart()
    {
        MovePlatform.SetToZero();
        ScoreBoard.SetToZero();
        _vibrateCurrent = Vibration.Status;
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        MovePlatform.SetToZero();
        ScoreBoard.SetToZero();
        _vibrateCurrent = Vibration.Status;
        SceneManager.LoadScene(0);
    }

    private void Menu()
    {
        _front.SetActive(false);
        _menu.SetActive(true);
    }

    private void BackToFront()
    {
        _front.SetActive(true);
        _menu.SetActive(false);
    }

    private void VibrateOff()
    {
        Vibration.Off();
        _buttonVibrateOff.gameObject.SetActive(true);
        _buttonVibrate.gameObject.SetActive(false);
    }

    private void VibrateOn()
    {
        Vibration.On();
        Handheld.Vibrate();
        _buttonVibrate.gameObject.SetActive(true);
        _buttonVibrateOff.gameObject.SetActive(false);
    }

    private void GameOver()
    {
        if (!(StateMachine.GameState == States.Over))
            return;

        _countdownText.text = "Game Over";
        _countdownText.gameObject.SetActive(true);
        _restartButton.gameObject.SetActive(true);
        _menuButton.gameObject.SetActive(true);
    }
}
