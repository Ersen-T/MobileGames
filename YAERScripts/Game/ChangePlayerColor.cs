using UnityEngine;

public class ChangePlayerColor : MonoBehaviour
{
    [SerializeField] private Material _red;
    [SerializeField] private Material _green;
    [SerializeField] private Material _blue;

    // OnClick events are on the buttons in the editor.
    public void ChangeColorToRed()
    {
        gameObject.GetComponentInChildren<Renderer>().material = _red;
    }

    public void ChangeColorToGreen()
    {
        gameObject.GetComponentInChildren<Renderer>().material = _green;
    }

    public void ChangeColorToBlue()
    {
        gameObject.GetComponentInChildren<Renderer>().material = _blue;
    }
}
