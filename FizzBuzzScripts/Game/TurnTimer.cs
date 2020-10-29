using UnityEngine;
using UnityEngine.UI;

public class TurnTimer : MonoBehaviour
{
    public Slider _slider;
    [SerializeField] private Gradient _gradient;
    [SerializeField] private Image _fill;

    private float _maxValue;
    private float _turnSpeedUpValue = 0.02f;

    private void Awake()
    {
        _maxValue = _slider.maxValue;
    }

    private void Start()
    {
        SliderMaxer();
    }

    public void TurnTimerUpdate()
    {
        _slider.value -= Time.deltaTime;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }

    public void SliderMaxer()
    {
        _maxValue -= _turnSpeedUpValue;
        _slider.value = _maxValue;
        _fill.color = _gradient.Evaluate(_slider.normalizedValue);
    }
}
