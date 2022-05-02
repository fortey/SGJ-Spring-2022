using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private GameObject _trashBag;
    [SerializeField] private GameObject _actionHint;
    private Mover _mover;
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
        _mover = GetComponent<Mover>();
    }
    public void TakeTrashBag()
    {
        _trashBag.SetActive(true);
        _mover.Flip();
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
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentAction?.Invoke();
        }
    }
}
