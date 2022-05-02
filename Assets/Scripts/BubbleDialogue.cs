using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleDialogue : MonoBehaviour
{
    public event Action onDialogueStart;
    public event Action onDialogueEnd;
    [SerializeField] private Bubble _bubble;
    [SerializeField] private Text _textComponent;
    [SerializeField] private SpeechLine[] _lines;
    private int _index;
    [SerializeField] private float _textSpeed;


    private bool _inProgress;

    public void StartDialogue()
    {
        _inProgress = true;
        _bubble.gameObject.SetActive(true);
        _index = 0;
        TypeLine();

        onDialogueStart?.Invoke();
    }

    private void TypeLine()
    {
        _bubble.Setup(_lines[_index].bubbleSpot);
        // to do flip bubble
        _textComponent.text = _lines[_index].line;

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
            onDialogueEnd?.Invoke();
            _bubble.gameObject.SetActive(false);
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
    [TextArea(2, 10)] public string line;
}