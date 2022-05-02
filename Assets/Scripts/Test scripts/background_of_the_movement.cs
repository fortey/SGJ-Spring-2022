using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background_of_the_movement : MonoBehaviour
{

    [SerializeField] private float _speed = 1f;
    private bool _canMove = true;
    private bool _inDialogue;

    void Start()
    {
 
        var borderCheck = GetComponentInChildren<BorderCheck>();
        borderCheck.onBorderEnter += () => _canMove = false;
        borderCheck.onBorderExit += () => _canMove = true;
    }

    private void OnEnable()
    {
        Dialogue.instance.onDialogueStart += SetInDialogue;
        Dialogue.instance.onDialogueEnd += SetNotInDialogue;
    }

    private void OnDisable()
    {
        Dialogue.instance.onDialogueStart -= SetInDialogue;
        Dialogue.instance.onDialogueEnd -= SetNotInDialogue;
    }

    void Update()
    {

        var horizontal = Input.GetAxis("Horizontal");
        if (!_inDialogue && horizontal != 0f)
        {

            if (_canMove)
                transform.position = transform.position - new Vector3(horizontal * _speed * Time.deltaTime, 0f, 0f);
        }
       
    }

    private void SetInDialogue()
    {
        _inDialogue = true;
    }

    private void SetNotInDialogue()
    {
        _inDialogue = false;
    }
}
