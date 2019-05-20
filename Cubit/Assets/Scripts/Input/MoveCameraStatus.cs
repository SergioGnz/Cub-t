using UnityEngine;

public class MoveCameraStatus : MonoBehaviour, IInputStatus
{
    [SerializeField]
    private float rotationRate = 20f;

    private Transform _cameraTransform;

    private float _lastTouchXPos, _touchPosDelta;

    public void Initialize()
    {
        _cameraTransform = Camera.main.transform;
    }

    public void FirstCall(Vector2 firstUserInput)
    {
        _lastTouchXPos = firstUserInput.x;
    }

    public void UpdateStatus(Vector2 userInput)
    {
        _touchPosDelta = _lastTouchXPos - userInput.x;

        _cameraTransform.RotateAround(Vector3.zero, Vector3.up, _touchPosDelta * rotationRate * Time.deltaTime);
        _cameraTransform.LookAt(Vector3.zero);

        _lastTouchXPos = userInput.x;
    }
}
