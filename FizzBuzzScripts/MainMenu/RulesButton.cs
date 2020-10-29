using UnityEngine;
using UnityEngine.UI;

public class RulesButton : MonoBehaviour
{
    [SerializeField] private GameObject _rulesBackground;

    private Button _rulesButton;

    private void Awake()
    {
        _rulesButton = gameObject.GetComponent<Button>();
        _rulesButton.onClick.AddListener(Rules);
        _rulesBackground.SetActive(false);
    }

    private void Rules()
    {
        _rulesBackground.SetActive(true);
    }
}
