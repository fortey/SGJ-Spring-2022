using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float _speed = 3f;
    void Start()
    {

    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        if (horizontal != 0f)
        {
            transform.position = transform.position + new Vector3(horizontal * _speed * Time.deltaTime, 0f, 0f);
        }
    }
}
