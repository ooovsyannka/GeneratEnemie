using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]

public class Enemy : MonoBehaviour
{
    [SerializeField] private float _speedMove;
    [SerializeField] private Transform _checkPoint;

    private Animator _enemyAnimator;
    private WaitForSeconds _waitForSeconds;
    private float _delay = 2f;
    private bool _isFall;

    private void Start()
    {
        _enemyAnimator = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Vector3 direction = transform.forward * (_speedMove * Time.deltaTime);
        transform.Translate(direction, Space.World);

        _enemyAnimator.SetBool("IsFall", _isFall);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            _isFall = false;
            StopCoroutine(Coldown());
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.GetComponent<Platform>())
        {
            _isFall = true;
            StartCoroutine(Coldown());
        }
    }

    private IEnumerator Coldown()
    {
        _waitForSeconds = new WaitForSeconds(_delay);

        yield return _waitForSeconds;

        gameObject.SetActive(false);
    }
}