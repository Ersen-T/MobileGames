using UnityEngine;
using TMPro;
using System.Collections;

public class EntranceWalkAndSet : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _countdownText;

    private CharacterController _controller;

    private Animator _animator;

    private IEnumerator _countdown;

    private readonly Vector3 _walkDirection = new Vector3(0.0f, 0.0f, 1.0f);
    private Vector3 _walkVector;

    [SerializeField] private float _walkDuration = 4.0f;
    [SerializeField] private float _walkSpeed = 2.0f;

    private float _timer;

    private int _startPosHash;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _animator = GetComponentInChildren<Animator>();

        _startPosHash = Animator.StringToHash("startPos");

        _countdown = Countdown();

        _countdownText.gameObject.SetActive(false);
    }

    private void Start()
    {
        StateMachine.SetState(States.Entrance);

        _timer = 0.0f;
    }

    private void Update()
    {
        EntranceWalk();
    }

    private void EntranceWalk()
    {
        if (!(StateMachine.GameState == States.Entrance))
            return;

        _walkVector = _walkDirection * _walkSpeed * Time.deltaTime;

        if (_timer < _walkDuration)
        {
            _timer += Time.deltaTime;

            _controller.Move(_walkVector);
        }
        else if (_timer > _walkDuration)
        {
            StateMachine.SetState(States.Start);

            _animator.SetBool(_startPosHash, true);

            _countdownText.gameObject.SetActive(true);

            StartCoroutine(_countdown);
        }
    }

    private IEnumerator Countdown()
    {
        _countdownText.text = "Get Ready!";
        yield return new WaitForSeconds(1.5f);
        _countdownText.text = "3";
        yield return new WaitForSeconds(1.0f);
        _countdownText.text = "2";
        yield return new WaitForSeconds(1.0f);
        _countdownText.text = "1";
        yield return new WaitForSeconds(1.0f);
        _countdownText.text = "RUN!";

        StateMachine.SetState(States.Play);

        yield return new WaitForSeconds(1.25f);
        _countdownText.gameObject.SetActive(false);
    }
}
