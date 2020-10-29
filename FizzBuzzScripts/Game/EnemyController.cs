using System.Collections;
using TMPro;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _enemyBubbleText;
    [SerializeField] private TurnTimer _enemyTurnTimer;

    private IEnumerator _introduction;
    private float _randomWait = 0.0f;
    private float _enemyThinkTime = 0.0f;
    private bool _randomCheck = true;
    private float _enemyThinkMaxTime = 2.48f;
    private float _enemyThinkMinTime = 0.48f;
    private float _turnSpeedUpValue = 0.02f;

    private void Awake()
    {
        _introduction = Introduction();
    }

    private void Start()
    {
        StartCoroutine(_introduction);
    }

    private void Update()
    {
        OnEnemyTurn();
        GameOverCheck();
        WinCheck();
    }

    private IEnumerator Introduction()
    {
        ChangeEnemyBubbleText("");
        yield return new WaitForSeconds(0.5f);

        ChangeEnemyBubbleText("Hello Human!");
        yield return new WaitForSeconds(3.0f);

        ChangeEnemyBubbleText("Are You Ready?");
        yield return new WaitForSeconds(3.0f);

        ChangeEnemyBubbleText("Go!");
        yield return new WaitForSeconds(1.0f);

        Counter.Count();

        ChangeEnemyBubbleText(Counter.CurrentNumber.ToString());

        StateMachine.CurrentState = State.Player;
    }

    private void OnEnemyTurn()
    {
        if (!StateMachine.CheckState(State.Enemy))
            return;

        _enemyTurnTimer.gameObject.SetActive(true);

        bool _enemyThink = EnemyThink();

        if (_enemyThink == false)
            return;

        EnemyPlay();

        PassTurnToPlayer();
    }

    private bool EnemyThink()
    {
        _enemyTurnTimer.TurnTimerUpdate();

        if (_randomCheck == true)
        {
            _enemyThinkMaxTime -= _turnSpeedUpValue;
            _randomWait = Random.Range(_enemyThinkMinTime, _enemyThinkMaxTime);
            _randomCheck = false;
        }

        _enemyThinkTime += Time.deltaTime;

        if (_enemyThinkTime < _randomWait)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void EnemyPlay()
    {
        Counter.Count();

        Bubble _bubble = FizzBuzzChecker.Check();

        switch (_bubble)
        {
            case Bubble.Next:
                ChangeEnemyBubbleText(Counter.CurrentNumber.ToString());
                break;

            case Bubble.Fizz:
                ChangeEnemyBubbleText("Fizz!");
                break;

            case Bubble.Buzz:
                ChangeEnemyBubbleText("Buzz!");
                break;

            case Bubble.FizzBuzz:
                ChangeEnemyBubbleText("Fizz\nBuzz!");
                break;
        }
    }

    private void PassTurnToPlayer()
    {
        StateMachine.CurrentState = State.Player;

        _enemyThinkTime = 0.0f;
        _randomCheck = true;
        _enemyTurnTimer.SliderMaxer();
        _enemyTurnTimer.gameObject.SetActive(false);
    }

    public void ChangeEnemyBubbleText(string _text)
    {
        _enemyBubbleText.text = _text;
    }

    private void GameOverCheck()
    {
        if (!StateMachine.CheckState(State.GameOverChecker))
            return;
        
        ChangeEnemyBubbleText("Game Over!");
    }

    private void WinCheck()
    {
        if (!StateMachine.CheckState(State.WinChecker))
            return;

        ChangeEnemyBubbleText("You Win!");
    }
}
