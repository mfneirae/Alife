﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eatprey : MonoBehaviour {

    public string Tag;
    public float growp;
    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            transform.localScale += new Vector3(growp, growp, growp / 10);
            Destroy(other.gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
