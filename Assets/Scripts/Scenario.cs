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

    [Header("Crones")]
    [SerializeField] private BubbleDialogue[] _cronesSpeeches;

    [Header("Shop")]
    [SerializeField] private BubbleDialogue[] _shopSpeeches;
    [SerializeField] private BubbleDialogue _forgotBatteries;

    [Header("BusStop")]
    [SerializeField] private BubbleDialogue[] _busStopEvents;
    [Header("")]
    [SerializeField] private BubbleDialogue[] _carEvents;

    private bool _rememberedTrash;
    private bool _isTrashEventCompled;
    private bool _shopVisited;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        StartTrashEvent();
        foreach (var speech in _shopSpeeches)
        {
            speech.onDialogueEnd += OnShopVisited;
        }
        _shopSpeeches[2].onDialogueEnd += () => _forgotBatteries.gameObject.SetActive(true);
    }
    public void OnComeHome()
    {
        if (_rememberedTrash && !_isTrashEventCompled && !_player.IsTrashOnHand)
        {
            _blackout.Play(GiveTrashBag);

            AfterComeHome();
            return;
        }
        if (_isTrashEventCompled && _shopVisited)
        {
            _shopVisited = false;
            _blackout.Play(AfterComeHome);

            return;
        }
    }

    private void AfterComeHome()
    {
        CameraFollow.instance.MoveRight();
        ActivateNextDialogue(_cronesSpeeches);
        ActivateNextDialogue(_shopSpeeches);
        ActivateNextDialogue(_busStopEvents);
        ActivateNextDialogue(_carEvents);

        if (_forgotBatteries.gameObject.activeSelf) _forgotBatteries.StartDialogue();
    }

    private void OnShopVisited()
    {
        CameraFollow.instance.MoveLeft();
        _shopVisited = true;
        ActivateNextDialogue(_busStopEvents);
        ActivateNextDialogue(_carEvents);
    }

    private void ActivateNextDialogue(BubbleDialogue[] dialogues)
    {
        foreach (var dialogue in dialogues)
        {
            if (!dialogue.IsCompleted)
            {
                dialogue.gameObject.SetActive(true);
                break;
            }
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
