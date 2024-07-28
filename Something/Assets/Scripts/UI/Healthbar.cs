using BHSCamp;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    [SerializeField] private Health _health;
    [SerializeField] private Image _fillImage;
    private bool _parentIsUI;

    private void OnEnable()
    {
        _health.OnDamageTaken += UpdateHealthbar;
        _health.OnHealed += UpdateHealthbar;
    }

    private void OnDisable()
    {
        _health.OnDamageTaken -= UpdateHealthbar;
        _health.OnHealed -= UpdateHealthbar;
    }

    private void Start()
    {
        _parentIsUI = transform.parent.GetComponent<RectTransform>() != null;
    }

    public void UpdateHealthbar(int healthChange)
    {
        SetFill(
            (float)_health.CurrentHealth /
            _health.MaxHealth
        );
    }

    private void SetFill(float value)
    {
        _fillImage.fillAmount = Mathf.Clamp01(value);
    }

    private void Update()
    {
        if (_parentIsUI) return;

        transform.localScale = new Vector3(
            transform.parent.localScale.x * 2,
            transform.localScale.y,
            transform.localScale.z
        );
    }
}
