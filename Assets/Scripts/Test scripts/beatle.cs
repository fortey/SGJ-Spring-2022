using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class beatle : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text Ogr;
    public bool key;
    public int Stage;
    public bool start;


    private void OnTriggerEnter2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            text.text = ("������ � �������� � ���� ������� � ���� ������");
            Ogr.text = ("������� 'E' ��� �� ����������");
            start = true;
        }
    }
    private void OnTriggerExit2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            text.text = ("");
            Ogr.text = ("");
            Stage = 0;
            start = false;

        }

    }
    public void Update()
    {
        if (start == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                key = true;
            }
            if (key == true)
            {
                Stage = Stage + 1;
                //text.text = ("E ���� ������");
                key = false;
            }
            if (Stage == 1)
            {
                text.text = ("������ ������ ����� �����");
            }
            if (Stage == 2)
            {
                text.text = ("������ ������ ����� �����");
            }
            if (Stage == 3)
            {
                text.text = ("������ ������ ����� �����");
            }
            if (Stage == 4)
            {
                text.text = ("�� �����");
                Ogr.text = ("");
            }

        }
    }
}