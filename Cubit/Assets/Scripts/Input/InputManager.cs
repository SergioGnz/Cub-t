using UnityEngine;

[RequireComponent(typeof(MovePlayerStatus))]
[RequireComponent(typeof(MoveCameraStatus))]
public class InputManager : MonoBehaviour, IManager, IUpdatable
{
    private IInputStatus _movement;
    private IInputStatus _camera;
    private IInputStatus _currentStatus;

    public void Startup()
    {
        _movement = GetComponent<MovePlayerStatus>();
        _camera = GetComponent<MoveCameraStatus>();

        _movement.Initialize();
        _camera.Initialize();

        _currentStatus = _movement;

        Managers.Update.AddUpdateableObject(this);
    }

    public void UpdateObject()
    {
#if UNITY_ANDROID
        if (Input.touchCount > 0)
        {
            var touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                _currentStatus.FirstCall(touch.position);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                _currentStatus.UpdateStatus(touch.position);
            }
        }
#endif
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            _currentStatus.FirstCall(Input.mousePosition);
        }
        else if (Input.GetMouseButton(0))
        {
            _currentStatus.UpdateStatus(Input.mousePosition);
        }
    }
#endif
    public void SwitchStatus()
    {
        _currentStatus = _currentStatus == _movement ? _camera : _movement;
    }
}