using System.Collections;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private const string NameAnimation = "IsAttack";

    [SerializeField] private float _delay;
    [SerializeField] private float _speed;
    [SerializeField] private float _positionY;
    [SerializeField] private float _maxDistanceToTarget;
    [SerializeField] private Animator _animator;

    private int _attackAnimatorHas = Animator.StringToHash(NameAnimation);
    private Vector3 _targetPosition;

    private void Start()
    {
        transform.position = new Vector3(transform.position.x, _positionY , transform.position.z);
    }

    private void Update()
    {
        if (TargentInZoneAttack())
        {
            StartAnimationAttack();
            StartCoroutine(DelayToDie());
        }
        else
        {
            transform.LookAt(_targetPosition);
            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _speed * Time.deltaTime);
        }
    }

    private IEnumerator DelayToDie()
    {
        WaitForSeconds waitForSeconds = new WaitForSeconds(_delay);

        yield return waitForSeconds;

        gameObject.SetActive(false);
    }

    public void SetTargetTransform(Transform targetTransform)
    {
        _targetPosition = new Vector3(targetTransform.position.x, _positionY, targetTransform.position.z);
    }

    private void StartAnimationAttack()
    {
        _animator.SetBool(_attackAnimatorHas, TargentInZoneAttack());
    }

    private bool TargentInZoneAttack()
    {
        float distanceToTarget = Vector3.Distance(transform.position, _targetPosition);

        return distanceToTarget < _maxDistanceToTarget;
    }
}