using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    private Button _exitButton;

    private void Awake()
    {
        _exitButton = gameObject.GetComponent<Button>();
        _exitButton.onClick.AddListener(Exit);
    }

    private void Exit()
    {
        Application.Quit();
    }
}
