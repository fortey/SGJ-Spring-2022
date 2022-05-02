using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public static Scenario instance;
    [SerializeField] private Player _player;
    [SerializeField] private Blackout _blackout;

    private void Awake()
    {
        instance = this;
    }
    public void OnComeHome()
    {
        if (!_player.IsTrashOnHand)
        {
            _blackout.Play(GiveTrashBag);
            CameraFollow.instance.MoveRight();
        }
    }

    private void GiveTrashBag()
    {
        _player.TakeTrashBag();
    }


}
