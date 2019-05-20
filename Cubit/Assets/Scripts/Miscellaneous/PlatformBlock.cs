using System.Collections;
using UnityEngine;

public class PlatformBlock : MonoBehaviour, IButtonBlockTarget
{
    [SerializeField]
    private Transform targetTrasnform;
    [SerializeField]
    private float speed;

    private Vector3 _origin;
    private Vector3 _targetOrigin;

    private bool _moving = false;

    private void Start()
    {
        Initialize();
    }

    public void Initialize()
    {
        _origin = transform.position;
        _targetOrigin = targetTrasnform.position;
    }

    public void OnButtonTrigger()
    {
        if (!_moving) //Should check if a player is under
        {
            StartCoroutine(MoveToTarget(transform.position == _origin ? _targetOrigin : _origin));
        }
    }

    private IEnumerator MoveToTarget(Vector3 target)
    {
        _moving = true;

        var direction = target - transform.position;

        while (Vector3.Distance(transform.position, target) > 0.05f)
        {
            transform.position += direction * speed * Time.deltaTime;
            yield return null;
        }

        transform.position = target;
        _moving = false;
    }
}