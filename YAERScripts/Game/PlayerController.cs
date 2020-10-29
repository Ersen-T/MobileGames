using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private CameraShake _mainCameraShake;

    [SerializeField] private TextMeshProUGUI _scoreText;

    private CharacterController _controller;

    private Animator _animator;

    private Vector3 _runDirection = new Vector3(0.0f, 0.0f, 1.0f);
    private Vector3 _runVector;

    [SerializeField] private float _speedUp = 0.25f;
    private float _runSpeed = 10.0f;

    private int _slowRunHash;
    private int _hitWallHash;
    private int _fallHash;
    private int _runSpeedHash;

    private bool isFalling = false;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();

        _animator = GetComponentInChildren<Animator>();

        _slowRunHash = Animator.StringToHash("slowRun");
        _hitWallHash = Animator.StringToHash("hitWall");
        _fallHash = Animator.StringToHash("fall");
        _runSpeedHash = Animator.StringToHash("runSpeed");

        StateMachine.SetState(States.Entrance);
    }

    private void Update()
    {
        Run();
        Fall();
    }

    private void Run()
    {
        if (!(StateMachine.GameState == States.Play))
            return;
        
        _animator.SetBool(_slowRunHash, true);
        _runVector = _runDirection * _runSpeed * Time.deltaTime;
        _controller.Move(_runVector);

        _runSpeed += Time.deltaTime * _speedUp;

        _animator.SetFloat(_runSpeedHash, _runSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Dikkat!!!
        // Aşağıdaki yöntemi (maxColorComponent) kullanabilmek için, editörde max renk değerleri arasında birer fark bıraktım.
        // Red max 255. Green max 254. Blue max 253. PlayerMat max 252.
        // Böylece max değer karşılaştırması, renk karşılaştırması haline geldi.
        // Daha iyi bir yöntem bul!

        float _playerMax = gameObject.GetComponentInChildren<Renderer>().material.color.maxColorComponent;
        float _triggerMax = other.gameObject.GetComponent<Renderer>().material.color.maxColorComponent;

        if (other.gameObject.CompareTag("Door"))
        {
            MovePlatform.Count();

            if (_playerMax != _triggerMax)
            {
                _animator.SetBool(_hitWallHash, true);

                if (Vibration.Status == true)
                    Handheld.Vibrate();

                StateMachine.SetState(States.Over);
            }
            else
            {
                //Static door off
                other.gameObject.SetActive(false);
                //Door break on
                other.gameObject.transform.parent.GetChild(0).gameObject.SetActive(true);

                StartCoroutine(_mainCameraShake.Shake(0.2f, 0.1f));

                ScoreBoard.SetScore();
                _scoreText.text = ScoreBoard.Score.ToString();
            }
        }

        if (other.gameObject.CompareTag("Hole"))
        {
            if (_playerMax == _triggerMax)
            {
                //Static door off
                other.gameObject.SetActive(false);
                //Door break on
                other.gameObject.transform.parent.GetChild(1).gameObject.SetActive(true);

                if (Vibration.Status == true)
                    Handheld.Vibrate();

                _animator.SetBool(_fallHash, true);
                isFalling = true;
                StateMachine.SetState(States.Over);
            }
            else
            {
                ScoreBoard.SetScore();
                _scoreText.text = ScoreBoard.Score.ToString();
            }
        }
    }

    private void Fall()
    {
        if (!isFalling)
            return;

        float _fallSpeed = 10.0f;
        Vector3 _fallDirection = new Vector3(0.0f, -1.0f, 0.25f);
        Vector3 _fallVector = _fallDirection * _fallSpeed * Time.deltaTime;
        _controller.Move(_fallVector);
    }
}
