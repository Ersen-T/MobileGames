using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerBubbles _playerBubbles;
    [SerializeField] private TurnTimer _playerTurnTimer;
    [SerializeField] private GameObject _wrongAnswerX;

    [SerializeField] private Button _nextButton;
    [SerializeField] private Button _fizzButton;
    [SerializeField] private Button _buzzButton;
    [SerializeField] private Button _fizzBuzzButton;

    private int _winNumber = 100;

    private void Start()
    {
        OnStart();
    }

    private void Update()
    {
        OnPlayerTurn();
        GameOverCheck();
    }

    private void OnStart()
    {
        _playerBubbles.TurnPlayerBubblesOff();
        _playerBubbles.ChangeNextBubbleText(Counter.CurrentNumber.ToString());

        _wrongAnswerX.SetActive(false);

        _nextButton.onClick.AddListener(OnNextButton);
        _fizzButton.onClick.AddListener(OnFizzButton);
        _buzzButton.onClick.AddListener(OnBuzzButton);
        _fizzBuzzButton.onClick.AddListener(OnFizzBuzzButton);
    }

    private void OnNextButton()
    {
        if (!StateMachine.CheckState(State.Player))
            return;

        Counter.Count();

        Bubble _checker = FizzBuzzChecker.Check();

        if (_checker == Bubble.Next)
        {
            _playerBubbles.ChangeNextBubbleText(Counter.CurrentNumber.ToString());
            _playerBubbles.TurnPlayerBubblesOff();
            _playerBubbles.BubbleActivator(Bubble.Next);

            PassTurnToEnemy();
        }
        else
        {
            StateMachine.CurrentState = State.GameOver;
        }
    }

    private void OnFizzButton()
    {
        if (!StateMachine.CheckState(State.Player))
            return;

        Counter.Count();

        Bubble _checker = FizzBuzzChecker.Check();

        if (_checker == Bubble.Fizz)
        {
            _playerBubbles.TurnPlayerBubblesOff();
            _playerBubbles.BubbleActivator(Bubble.Fizz);

            PassTurnToEnemy();
        }
        else
        {
            StateMachine.CurrentState = State.GameOver;
        }
    }

    private void OnBuzzButton()
    {
        if (!StateMachine.CheckState(State.Player))
            return;

        Counter.Count();

        Bubble _checker = FizzBuzzChecker.Check();

        if (_checker == Bubble.Buzz)
        {
            _playerBubbles.TurnPlayerBubblesOff();
            _playerBubbles.BubbleActivator(Bubble.Buzz);

            PassTurnToEnemy();
        }
        else
        {
            StateMachine.CurrentState = State.GameOver;
        }
    }

    private void OnFizzBuzzButton()
    {
        if (!StateMachine.CheckState(State.Player))
            return;

        Counter.Count();

        Bubble _checker = FizzBuzzChecker.Check();

        if (_checker == Bubble.FizzBuzz)
        {
            _playerBubbles.TurnPlayerBubblesOff();
            _playerBubbles.BubbleActivator(Bubble.FizzBuzz);

            PassTurnToEnemy();
        }
        else
        {
            StateMachine.CurrentState = State.GameOver;
        }
    }

    private void OnPlayerTurn()
    {
        if (!StateMachine.CheckState(State.Player))
            return;

        _playerTurnTimer.gameObject.SetActive(true);

        _playerTurnTimer.TurnTimerUpdate();

        if (_playerTurnTimer._slider.value <= 0f)
        {
            StateMachine.CurrentState = State.GameOver;
        }
    }

    private void PassTurnToEnemy()
    {
        if (Counter.CurrentNumber == _winNumber)
        {
            StateMachine.CurrentState = State.Win;
        }
        else
        {
            StateMachine.CurrentState = State.Enemy;
        }

        _playerTurnTimer.SliderMaxer();
        _playerTurnTimer.gameObject.SetActive(false);
    }

    private void GameOverCheck()
    {
        if (!StateMachine.CheckState(State.GameOverChecker))
            return;

        _playerBubbles.TurnPlayerBubblesOff();
        _wrongAnswerX.SetActive(true);
    }
}
