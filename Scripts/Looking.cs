using UnityEngine;

public class Looking : MonoBehaviour
{
    private const string Horizontal = nameof(Horizontal);
    private const string Vertical = nameof(Vertical);

    [SerializeField] private float _speed;

    private void Update()
    {
        float horizontal = Input.GetAxis(Horizontal) * _speed * Time.deltaTime;
        float vertical = Input.GetAxis(Vertical) * _speed * Time.deltaTime;

        transform.Translate(horizontal, 0, vertical, Space.World);
    }
}