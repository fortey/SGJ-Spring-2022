using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public static Dialogue instance;
    public event Action onDialogueStart;
    public event Action onDialogueEnd;
    [SerializeField] private Text _textComponent;
    private Speech _speech;
    private int _index;
    [SerializeField] private float _textSpeed;
    [SerializeField] private GameObject _gameObject;

    private void Awake()
    {
        instance = this;
    }

    public void StartDialogue(Speech speech)
    {
        _gameObject.SetActive(true);
        _speech = speech;
        _index = 0;
        StartTypeLine();
        onDialogueStart?.Invoke();
    }

    private void StartTypeLine()
    {
        _textComponent.text = string.Empty;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (var c in _speech.lines[_index].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }

    private void NextLine()
    {
        if (_index < _speech.lines.Length - 1)
        {
            _index++;
            StartTypeLine();
        }
        else
        {
            onDialogueEnd?.Invoke();
            _gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (_textComponent.text == _speech.lines[_index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                _textComponent.text = _speech.lines[_index];
            }
        }
    }
}
