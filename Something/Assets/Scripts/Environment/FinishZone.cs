using System;
using BHSCamp;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FinishZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameManager.Instance.FinishCurrentLevel();
    }
}
