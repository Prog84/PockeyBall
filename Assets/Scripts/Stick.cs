using UnityEngine;

public class Stick : MonoBehaviour
{
    [SerializeField] private Ball _ball;
    [SerializeField] private Transform _fixationPoint;

    private void OnEnable()
    {
        _ball.FixationChanged += OnFixationChanged;
    }

    private void OnDisable()
    {
        _ball.FixationChanged -= OnFixationChanged;
    }

    private void OnFixationChanged(float newFixationPointY)
    {
        transform.position = new Vector3(transform.position.x, newFixationPointY, transform.position.z);
        _ball.transform.parent = _fixationPoint;
    }
}
