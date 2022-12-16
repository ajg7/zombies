using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score
{
    public Score()
    {
    }
    public int KillCount { get; set; }

    private void Update()
    {
        Debug.Log(KillCount);
        Debug.Log("hi");
    }
}
