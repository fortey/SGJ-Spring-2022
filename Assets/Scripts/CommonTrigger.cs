using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommonTrigger : MonoBehaviour
{
    public UnityEvent action;

    private void OnTriggerEnter2D(Collider2D other)
    {
        action?.Invoke();
    }
}
