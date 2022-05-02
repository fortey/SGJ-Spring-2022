using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Home : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            Global.Stop = true;
        }
    }
    private void OnTriggerExit2D(Collider2D Event)
    {
        if (Event.gameObject.tag == "Player")
        {
            Global.Stop = false;
        }

    }
}
