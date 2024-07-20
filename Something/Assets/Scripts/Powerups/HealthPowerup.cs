using BHSCamp;
using UnityEngine;

public class HealthPowerup : MonoBehaviour, IPowerup
{
    [SerializeField] private int _healAmount;

    public void Apply(GameObject target)
    {
        IHealable healable = target.GetComponent<IHealable>();
        healable.Heal(_healAmount);
    }
}
