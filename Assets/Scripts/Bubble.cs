using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bubble : MonoBehaviour
{
    private Transform _spot;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
        gameObject.SetActive(false);

    }

    public void Setup(Transform spot)
    {
        _spot = spot;
    }
    void Update()
    {
        transform.position = RectTransformUtility.WorldToScreenPoint(_camera, _spot.position);
    }
}
