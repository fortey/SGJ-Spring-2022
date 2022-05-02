using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BorderCheck : MonoBehaviour
{
    public event Action onBorderEnter;
    public event Action onBorderExit;
    private int _layerMask;
    private readonly string _borderTag = "Border";

    private void Start()
    {
        _layerMask = LayerMask.NameToLayer("Border");
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(_borderTag))
        {
            onBorderEnter.Invoke();
            if (transform.position.x > other.transform.position.x)
            {
                Scenario.instance.OnComeHome();
            }
            else
                CameraFollow.instance.MoveLeft();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag(_borderTag))
            onBorderExit.Invoke();
    }

}
