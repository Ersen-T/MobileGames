using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    private Button _playButton;

    private void Awake()
    {
        _playButton = gameObject.GetComponent<Button>();
        _playButton.onClick.AddListener(PlayGame);
    }

    private void PlayGame()
    {
        // Loads The Game Scene
        SceneManager.LoadScene(1);
    }
}
