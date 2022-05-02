using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Blackout : MonoBehaviour
{
    [SerializeField] float _time = 0.8f;
    private Image _image;

    private void Start()
    {
        _image = GetComponent<Image>();
        gameObject.SetActive(false);
    }
    public void Play(Action action)
    {
        gameObject.SetActive(true);

        StartCoroutine(PlayCoroutine(action));
    }

    IEnumerator PlayCoroutine(Action action)
    {
        var halfTime = _time / 2;
        var k = 1 / halfTime;
        var time = 0f;

        while (time < halfTime)
        {
            _image.color = new Color(0f, 0f, 0f, Mathf.Lerp(0f, 1f, time * k));
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }
        action?.Invoke();
        time = 0f;
        while (time < halfTime)
        {
            _image.color = new Color(0f, 0f, 0f, Mathf.Lerp(1f, 0f, time * k));
            yield return new WaitForEndOfFrame();
            time += Time.deltaTime;
        }

        gameObject.SetActive(false);

    }
}
