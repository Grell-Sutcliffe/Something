using System;
using System.Collections;
using UnityEngine;

public class ActionOnTimer : MonoBehaviour
{
    public void ExecuteAfterTime(Action action, float time)
    {
        StartCoroutine(Timer(action, time));
    }

    private IEnumerator Timer(Action action, float time)
    {
        yield return new WaitForSeconds(time);
        action();
    }
}
