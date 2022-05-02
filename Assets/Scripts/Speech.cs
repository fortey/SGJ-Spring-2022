using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Speech", menuName = "New Speech", order = 52)]
public class Speech : ScriptableObject
{
    public bool stopPlayer;
    [TextArea(2, 10)]
    public string[] lines;
}

