using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private Transform _checkPoint;

    private Animator _enemyAnimator;
    private float _delay = 2f;
    private bool _isFall;
    private int _runAnimatorHas = Animator.StringToHash(nameof(_isFall));
    private Vector3 _direction;

    private void Start()
    {
        _enemyAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        transform.Translate(_direction, Space.World);

        _enemyAnimator.SetBool(_runAnimatorHas, _isFall);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            _isFall = false;
            StopCoroutine(DelayToDie());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            _isFall = true;
            StartCoroutine(DelayToDie());
        }
    }

    private IEnumerator DelayToDie()
    {
        yield return new WaitForSeconds(_delay);

        gameObject.SetActive(false);
    }

    public void SetDirection(Vector3 direction) => _direction = direction * (_speedMove * Time.deltaTime);
}