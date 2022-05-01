using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 3f;
    private bool _isFlip;
    private bool _canMove = true;

    private Animator _animator;
    private readonly int _animIsWalking = Animator.StringToHash("isWalking");

    void Start()
    {
        _animator = GetComponent<Animator>();

        var borderCheck = GetComponentInChildren<BorderCheck>();
        borderCheck.onBorderEnter += () => _canMove = false;
        borderCheck.onBorderExit += () => _canMove = true;
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0f)
        {
            if (horizontal < 0 && !_isFlip || horizontal > 0 && _isFlip)
                Flip();

            if (_canMove)
                transform.position = transform.position + new Vector3(horizontal * _speed * Time.deltaTime, 0f, 0f);
        }

        _animator.SetBool(_animIsWalking, _canMove && horizontal != 0f);
    }

    private void Flip()
    {
        _isFlip = !_isFlip;
        var localScale = transform.localScale;
        transform.localScale = new Vector3(localScale.x * -1, localScale.y, localScale.z);
    }
}
