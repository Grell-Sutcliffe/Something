using UnityEngine;

public abstract class TemporaryPowerup : MonoBehaviour, IPowerup
{
    [SerializeField] protected float _duraion;

    public virtual void Apply(GameObject target)
    {
        ActionOnTimer executer = target.GetComponent<ActionOnTimer>();
        if (null != executer)
            executer.ExecuteAfterTime(OnExpire, _duraion);
    }

    protected abstract void OnExpire();
}
