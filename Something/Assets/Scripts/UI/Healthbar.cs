using BHSCamp;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Collections;
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
        if (_parentIsUI)
        {
            if (_health.CurrentHealth <= 0)
                StartCoroutine(ReturnToMainMenuAfterDelay(3));
        }
        else
        {
            transform.localScale = new Vector3(
                transform.parent.localScale.x * 2,
                transform.localScale.y,
                transform.localScale.z
            );
        }
    }

    private IEnumerator ReturnToMainMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        GameManager.Instance.ExitCurrentLevel();
    }
}
