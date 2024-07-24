using UnityEngine;

public class ParallaxBahaviour : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField, Range(0, 1)] private float _horizontalMovemwntMultiplier;
    [SerializeField, Range(0, 1)] private float _verticalMovemwntMultiplier;

    private Vector3 _targetPosition => _target.position;
    private Vector3 _lastTargetPosition;

    private void Start()
    {
        _lastTargetPosition = transform.position;
    }

    // Update is called once per frame
    private void Update()
    {
        Vector3 delta = _targetPosition - _lastTargetPosition;
        delta *= new Vector2(_horizontalMovemwntMultiplier, _verticalMovemwntMultiplier);
        transform.position += delta;

        _lastTargetPosition = _targetPosition;
    }
}
