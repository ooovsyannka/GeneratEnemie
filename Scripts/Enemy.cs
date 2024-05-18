using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private const string NameAnimation = "IsAttack";

    [SerializeField] private float _speed;
    [SerializeField] private float _positionY;
    [SerializeField] private float _maxDistanceToTarget;
    [SerializeField] private Animator _animator;

    private int _attackAnimatorHas = Animator.StringToHash(NameAnimation);
    private float _delay = 4f;
    private Target _target;
    private Vector3 _targetPosition;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, _positionY, transform.position.z);
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _targetPosition);
        _targetPosition = new Vector3(_target.transform.position.x, _positionY, _target.transform.position.z);
        bool targetInZoneAttack = distanceToTarget < _maxDistanceToTarget;

        _animator.SetBool(_attackAnimatorHas, targetInZoneAttack);

        if (targetInZoneAttack)
        {
            if(TimerIsOver())
            {
                gameObject.SetActive(false);
            }
        }
        else
        {
            Move();
        }
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

    public void SetTarget(Target target)
    {
        _target = target;
    }

    private void Move()
    {
        transform.LookAt(_targetPosition);
        transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
    }
}