using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scenario : MonoBehaviour
{
    public static Scenario instance;
    [SerializeField] private Player _player;
    [SerializeField] private Blackout _blackout;
    [Header("Trash event")]
    [SerializeField] private GameObject _borderForTrashEvent;
    [SerializeField] private BubbleDialogue _speechForTrashEvent;
    [SerializeField] private BubbleDialogue _speechForTrashEvent2;

    private bool _rememberedTrash;
    private bool _isTrashEventCompled;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartTrashEvent();
    }
    public void OnComeHome()
    {
        if (_rememberedTrash && !_isTrashEventCompled && !_player.IsTrashOnHand)
        {
            _blackout.Play(GiveTrashBag);
            CameraFollow.instance.MoveRight();
        }
    }

    #region TrashEvent
    private void StartTrashEvent()
    {
        _speechForTrashEvent.gameObject.SetActive(true);
        _speechForTrashEvent.onDialogueEnd += () => _rememberedTrash = true;
        _borderForTrashEvent.SetActive(true);
    }
    private void GiveTrashBag()
    {
        _player.TakeTrashBag();
        _speechForTrashEvent2.gameObject.SetActive(true);
        _speechForTrashEvent2.StartDialogue(2f);
    }

    public void FinishTrashEvent()
    {
        Destroy(_borderForTrashEvent);
        _isTrashEventCompled = true;
        CameraFollow.instance.MoveRight();
    }
    #endregion

}
