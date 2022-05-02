using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CommonTrigger : MonoBehaviour
{
    public UnityEvent action;
    public UnityEvent exitAction;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            action?.Invoke();
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
            exitAction?.Invoke();
    }
}
