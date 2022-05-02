using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialog_Script : MonoBehaviour
{
    [SerializeField] Text text;
    public bool key;
    public int Kiberbabka;


    private void OnTriggerEnter2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {         
         text.text = ("НАЖМИТЕ 'E' ДЛЯ ВЗАИМОДЕЙСТВИЯ");                    
        }
    }
    private void OnTriggerExit2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            text.text = ("");
            Kiberbabka = 0;

        }

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            key = true; 
        }
        if (key == true)
        {
            Kiberbabka = Kiberbabka + 1;
            //text.text = ("E Была нажата");
            key = false;
        }
        if (Kiberbabka == 1)
        {
            text.text = ("Первый диалог кибер бабки");
        }
        if (Kiberbabka == 2)
        {
            text.text = ("Второй диалог кибер бабки");
        }
        if (Kiberbabka == 3)
        {
            text.text = ("Третий диалог кибер бабки");
        }
        if (Kiberbabka == 4)
        {
            text.text = ("Четвертый диалог кибер бабки");
        }


    }
}
