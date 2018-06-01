using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Winteriscomming : MonoBehaviour {
    public float season_duration;
    public float io;
    private int count;
    private float nextactiontime;
    // Update is called once per frame
    private void Start()
    {
        nextactiontime = 0;
        count = 0;
        io = 1;
    }
    void FixedUpdate () {
        if(Time.time > nextactiontime)
            {
            nextactiontime += season_duration;
            count = count + 1;
            }
        io = (count % 2) + 1;
    }
}
