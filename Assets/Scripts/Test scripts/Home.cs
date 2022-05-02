using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] Text text;
    public bool key;
    public Animator player;
    public int stage;

    private void OnTriggerEnter2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            Global.Stop = true;
            if (Global.Event_trash == true)
            {
                if (stage == 1)
                {
                    text.text = ("ß óæå âçÿë ìóñîð");
                }
            }
            if (stage == 0)
            {
                if (Global.Event_trash == true)
                {
                    text.text = ("ÍÀÆÌÈÒÅ 'E' ×ÒÎ ÁÛ ÂÇßÒÜ ÌÓÑÎÐ");
                    if (key == true)
                    {
                        player.SetBool("trash", true);
                        key = false;
                        stage = 1;
                    }

                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            Global.Stop = false;
            text.text = ("");
        }

    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            key = true;
        }
        
        
        
        
    }
    public void Start()
    {
        Global.Event_trash = false;
    }
}
