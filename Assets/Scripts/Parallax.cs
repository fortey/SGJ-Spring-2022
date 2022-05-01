using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float _startPos;
    private Transform _camera;
    [SerializeField] private float _parallaxEffect;

    void Start()
    {
        _startPos = transform.position.x;
        _camera = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        float dist = _camera.position.x * _parallaxEffect;
        transform.position = new Vector3(dist, transform.position.y, transform.position.z);
    }
}
