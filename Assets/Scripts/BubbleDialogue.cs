using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleDialogue : MonoBehaviour
{
    public event Action onDialogueStart;
    public event Action onDialogueEnd;

    public bool stopPlayer;
    public bool IsCompleted { get; private set; }
    [SerializeField] private Bubble _bubble;
    [SerializeField] private Text _textComponent;
    [SerializeField] private SpeechLine[] _lines;
    private int _index;
    [SerializeField] private float _textSpeed;

    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private Sprite _sprite;
    [SerializeField] private Animator _animator;
    [SerializeField] private bool _donnotDisable;
    private int _animatorParameter = Animator.StringToHash("Count");

    private bool _inProgress;

    private void Start()
    {
        if (stopPlayer)
        {
            var mover = FindObjectOfType<Mover>();
            onDialogueStart += mover.SetInDialogue;
            onDialogueEnd += mover.SetNotInDialogue;
        }
    }

    private void OnEnable()
    {
        if (_renderer && _sprite)
            _renderer.sprite = _sprite;
        if (_animator)
            _animator.SetInteger(_animatorParameter, _animator.GetInteger(_animatorParameter) + 1);
    }
    public void StartDialogue(float time)
    {
        Invoke(nameof(StartDialogue), time);
    }
    public void StartDialogue()
    {
        _inProgress = true;
        _bubble.gameObject.SetActive(true);
        _index = -1;
        NextLine();

        onDialogueStart?.Invoke();

    }

    private void TypeLine()
    {
        _bubble.Setup(_lines[_index].bubbleSpot);
        // to do flip bubble
        _textComponent.text = _lines[_index].line;
        SoundPlayer.Play(_lines[_index].clip);
        Invoke(nameof(NextLine), _textSpeed);
    }

    private void NextLine()
    {
        if (_index < _lines.Length - 1)
        {
            _index++;
            TypeLine();
        }
        else
        {
            _inProgress = false;
            IsCompleted = true;
            onDialogueEnd?.Invoke();
            _bubble.gameObject.SetActive(false);
            if (_donnotDisable)
                Destroy(GetComponent<BoxCollider2D>());
            else
                gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Player>(out Player player))
        {
            if (!_inProgress)
                StartDialogue();
        }
    }

}

[Serializable]
public class SpeechLine
{

    public Transform bubbleSpot;
    public AudioClip clip;
    [TextArea(2, 10)] public string line;
}