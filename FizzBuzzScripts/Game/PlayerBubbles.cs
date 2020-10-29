using TMPro;
using UnityEngine;

public class PlayerBubbles : MonoBehaviour
{
    [SerializeField] private GameObject _playerBubbleNext;
    [SerializeField] private GameObject _playerBubbleFizz;
    [SerializeField] private GameObject _playerBubbleBuzz;
    [SerializeField] private GameObject _playerBubbleFizzBuzz;

    private GameObject[] _playerBubbles;

    private TextMeshProUGUI _nextBubbleText;

    private void Awake()
    {
        _playerBubbles = new GameObject[] { _playerBubbleNext, _playerBubbleFizz, _playerBubbleBuzz, _playerBubbleFizzBuzz };

        _nextBubbleText = _playerBubbleNext.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void TurnPlayerBubblesOff()
    {
        foreach (GameObject item in _playerBubbles)
        {
            item.SetActive(false);
        }
    }

    public void BubbleActivator(Bubble _bubble)
    {
        if (_bubble == Bubble.Next)
        {
            _playerBubbleNext.SetActive(true);
        }
        else if (_bubble == Bubble.Fizz)
        {
            _playerBubbleFizz.SetActive(true);
        }
        else if (_bubble == Bubble.Buzz)
        {
            _playerBubbleBuzz.SetActive(true);
        }
        else
        {
            _playerBubbleFizzBuzz.SetActive(true);
        }
    }

    public void ChangeNextBubbleText(string _text)
    {
        _nextBubbleText.text = _text;
    }
}
