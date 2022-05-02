using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _trashBag;
    [SerializeField] private GameObject _actionHint;
    private Mover _mover;

    private Animator _animator;
    private readonly int _animTrash = Animator.StringToHash("trash");

    private Action _currentAction;
    private Action CurrentAction
    {
        get => _currentAction;
        set
        {
            _actionHint.SetActive(value != null);
            _currentAction = value;
        }
    }

    public bool IsTrashOnHand => _trashBag.activeSelf;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _mover = GetComponent<Mover>();
    }
    public void TakeTrashBag()
    {
        _trashBag.SetActive(true);
        _mover.Flip();
        _animator.SetBool(_animTrash, true);
    }

    public void OnComeToDumpster()
    {
        if (IsTrashOnHand)
        {
            CurrentAction = ThrowOutTrash;
        }
    }
    public void OnLeftDumpster()
    {
        if (IsTrashOnHand)
        {
            CurrentAction = null;
        }
    }

    private void ThrowOutTrash()
    {
        _trashBag.SetActive(false);
        CurrentAction = null;
        _animator.SetBool(_animTrash, false);
        Scenario.instance.FinishTrashEvent();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentAction?.Invoke();
        }
    }
}
