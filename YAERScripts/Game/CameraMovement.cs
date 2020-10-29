using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform _camHolder;

    private Vector3 _initialCameraOffset;
    private Vector3 _cameraPosition;

    private void Update()
    {
        SetToPlayer();
    }

    private void LateUpdate()
    {
        FollowPlayer();
    }

    private void SetToPlayer()
    {
        if (!(StateMachine.GameState == States.Start))
            return;
        
        _initialCameraOffset = _camHolder.position - gameObject.transform.position;
    }

    private void FollowPlayer()
    {
        if (!(StateMachine.GameState == States.Play))
            return;

        _cameraPosition = gameObject.transform.position + _initialCameraOffset;
        _camHolder.position = _cameraPosition;
    }
}
