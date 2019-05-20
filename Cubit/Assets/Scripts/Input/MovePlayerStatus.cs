using UnityEngine;

public class MovePlayerStatus : MonoBehaviour, IInputStatus
{
    private Vector2 _lastTouchPoint;

    private float _minTouchDelta;

    private bool _isSwipe = false;

    public void Initialize()
    {
        _minTouchDelta = Screen.width * 0.15f;
    }

    public void FirstCall(Vector2 firstUserInput)
    {
        _lastTouchPoint = firstUserInput;
        _isSwipe = false;
    }

    public void UpdateStatus(Vector2 userInput)
    {
        if (Vector2.Distance(_lastTouchPoint, userInput) > _minTouchDelta && !_isSwipe)
        {
            var direction = GetSwipeDirection(userInput);
            Managers.Gameplay.UpdatePlayer(direction);
            _isSwipe = true;
        }
    }

    private Vector3 GetSwipeDirection(Vector2 swipe)
    {
        Vector2 currentSwipe = new Vector2(swipe.x - _lastTouchPoint.x, swipe.y - _lastTouchPoint.y);

        int roundedAngle = (int)(Mathf.Round(GetRawAngle(currentSwipe) / 90f) * 90);

        if (roundedAngle >= 360) { roundedAngle = 0; }

        return GameConstants.Directions[roundedAngle/90];
    }

    private float GetRawAngle(Vector2 currentSwipe)
    {
        float angle = Vector2.Angle(Vector2.right, currentSwipe);
        return currentSwipe.y > 0f ? angle : 360 - angle;
    }
}
