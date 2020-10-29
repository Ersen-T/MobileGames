using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverBackground;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Button _exitButton;

    private IEnumerator _waitForGameOverScreen;

    private void Awake()
    {
        _waitForGameOverScreen = WaitForGameOverScreen();
    }

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnGameOver();
        OnWin();
    }

    private void OnStart()
    {
        Counter.SetToZero();

        _gameOverBackground.SetActive(false);

        _restartButton.onClick.AddListener(OnRestart);
        _mainMenuButton.onClick.AddListener(OnMainMenu);
        _exitButton.onClick.AddListener(OnExit);
    }

    private void OnGameOver()
    {
        if (!StateMachine.CheckState(State.GameOver))
            return;

        StateMachine.CurrentState = State.GameOverChecker;

        if (Counter.CurrentNumber < 3)
        {
            _scoreText.text = "0";
        }
        else
        {
            _scoreText.text = (Counter.CurrentNumber - 1).ToString();
        }

        StartCoroutine(_waitForGameOverScreen);
    }

    private void OnWin()
    {
        if (!StateMachine.CheckState(State.Win))
            return;

        StateMachine.CurrentState = State.WinChecker;

        _scoreText.text = (Counter.CurrentNumber).ToString();

        StartCoroutine(_waitForGameOverScreen);
    }

    private IEnumerator WaitForGameOverScreen()
    {
        yield return new WaitForSeconds(3f);

        _gameOverBackground.SetActive(true);

        StateMachine.CurrentState = State.Start;
    }

    private void OnRestart()
    {
        SceneManager.LoadScene(1);
    }

    private void OnMainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void OnExit()
    {
        Application.Quit();
    }
}
