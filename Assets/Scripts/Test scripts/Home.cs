using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Home : MonoBehaviour
{
    [SerializeField] Text text;
    public bool key;
    public Animator player;

    private void OnTriggerEnter2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            Global.Stop = true;
            if (Global.Event_trash == true)
            {
                text.text = ("Õ¿∆Ã»“≈ 'E' ◊“Œ ¡€ ¬«ﬂ“‹ Ã”—Œ–");
                if (key == true)
                {
                    player.SetBool("trash", true);
                    key = false;
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
