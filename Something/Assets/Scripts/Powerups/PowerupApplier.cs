using UnityEngine;

public class PowerupApplier : MonoBehaviour
{
    private IPowerup[] _powerups;

    private void Awake()
    {
        _powerups = GetComponentsInChildren<IPowerup>();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        ApplyPoverups(collider.gameObject);
        Destroy(gameObject);
    }

    private void ApplyPoverups(GameObject target)
    {
        foreach (IPowerup powerup in _powerups)
        {
            powerup.Apply(target);
        }
    }
}
