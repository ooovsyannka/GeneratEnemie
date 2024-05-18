using UnityEngine;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform[] _wayPoints;
    [SerializeField] private float _speed;
    [SerializeField] private float _maxDistanceToPoint;

    private float _delay = 5;
    private int _currentPoint = 0;

    void Update()
    {
        Vector3 pointPosition = new Vector3(_wayPoints[_currentPoint].position.x, transform.position.y, _wayPoints[_currentPoint].position.z);
        float distanceToPoint = Vector3.Distance(transform.position, pointPosition);

        if (distanceToPoint < _maxDistanceToPoint)
        {
            if (TimerIsOver())
            {
                _currentPoint = (_currentPoint + 1) % _wayPoints.Length;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, pointPosition, _speed * Time.deltaTime);

        transform.LookAt(pointPosition);
    }

    private bool TimerIsOver()
    {
        float maxDelay = 5;
        _delay -= Time.deltaTime;

        if (_delay < 0)
        {
            _delay = maxDelay;
            return true;
        }

        return false;
    }
}
