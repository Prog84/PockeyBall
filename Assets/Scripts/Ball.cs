using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private Animator _animator;
    
    private Rigidbody _rigidbody;
    private float _power;
    private string _blend = "Blend";
    private bool IsFixation = true;
    private float _distanceBetweenBallAndTower;

    public event UnityAction GameOver;
    public event UnityAction<float> FixationChanged;


    private void Start()
    {
        _distanceBetweenBallAndTower = transform.position.z;
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && IsFixation == true)
        {
            _power += Time.deltaTime;
            ChangeStickPosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            Jump(_power);
            IsFixation = false;
            _power = 0;
            ChangeStickPosition();
        }

        if (Input.GetMouseButtonDown(0) && IsFixation == false)
        {
            Ray ray = new Ray(transform.position, Vector3.forward);
            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                if (hitInfo.collider.TryGetComponent(out Block block))
                {
                    _rigidbody.velocity = Vector3.zero;
                }
                else if (hitInfo.collider.TryGetComponent(out Segment segment))
                {
                    IsFixation = true;
                    _rigidbody.isKinematic = true;
                    _rigidbody.velocity = Vector3.zero;
                    FixationChanged?.Invoke(transform.position.y);
                }
                else if (hitInfo.collider.TryGetComponent(out Finish finish))
                {
                    Time.timeScale = 0;
                    GameOver?.Invoke();
                }
            }
        }

    }

    private void ChangeStickPosition()
    {
        _power = Mathf.Clamp(_power, 0, 1);
        _animator.SetFloat(_blend, _power);
    }

    private void Jump(float power)
    {
        transform.parent = null;
        transform.position = new Vector3(transform.position.x, transform.position.y, _distanceBetweenBallAndTower);
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _jumpForce * power, ForceMode.Impulse);
    }
}
