using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Take_the_trash : MonoBehaviour
{
    [SerializeField] Text text;
    [SerializeField] Text Diolog;
    public bool key;
    public int Stage;
    public bool player;
    public bool end;


    private void OnTriggerEnter2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            if (end == false)
            {
                text.text = ("Ќј∆ћ»“≈ 'E' ƒЋя ¬«ј»ћќƒ≈…—“¬»я");
            }
            else
            {
                text.text = ("");
            }
            player = true;
        }
        if (Event.gameObject.tag == "Musor")
        {
            Stage = 2;
            Destroy(Event.gameObject);

        }
    }
    private void OnTriggerExit2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            text.text = ("");
            Diolog.text = ("");
            //Stage = 0;
            player = false;

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
            if (Stage == 0)
            {
                Stage = 1;
                Global.Event_trash = true;
                key = false;
            }
            
            //text.text = ("E Ѕыла нажата");
            key = false;
        }
        if (player == true)
        {
            if (Stage == 1)
            {
                Diolog.text = ("Ќу е мае забыл выбрасить кибер мусор");
            }
            if (Stage == 2)
            {

                Diolog.text = ("¬роде не чего не забыл");
                end = true;
                text.text = ("");
                Global.Event_trash = false;
            }

        }
    }
}