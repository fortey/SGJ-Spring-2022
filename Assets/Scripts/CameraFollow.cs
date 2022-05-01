using UnityEngine;
using Cinemachine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
    public static CameraFollow instance;
    public float offsetX = 0.2f;
    private CinemachineFramingTransposer _transposer;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
        if (vcam != null)
            _transposer = vcam.GetCinemachineComponent<CinemachineFramingTransposer>();
    }

    public void MoveLeft()
    {
        StartCoroutine(ChangeScreenX(0.5f + offsetX));
    }
    public void MoveRight()
    {
        StartCoroutine(ChangeScreenX(0.5f - offsetX));
    }

    IEnumerator ChangeScreenX(float newX)
    {
        float oldX = _transposer.m_ScreenX;
        var time = 1f;
        while (time > 0)
        {
            yield return new WaitForEndOfFrame();
            time -= Time.deltaTime;
            _transposer.m_ScreenX = Mathf.Lerp(newX, oldX, time);
        }
        _transposer.m_ScreenX = newX;
    }
}
