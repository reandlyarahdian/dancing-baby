using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Trigger : MonoBehaviour
{
    [SerializeField] private UnityEvent @event;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            @event.Invoke();
        }
    }
}
