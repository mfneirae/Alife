using System.Collections;
using System.Collections.Generic;
using testc = System.Math;
using Conva = System.Convert;
using UnityEngine;



public class eatfood : MonoBehaviour {
    public string Tag;
    public float growp;
    public float totallife;
    public float startlife;
    public float metabolism;
    public float Age;
    public float maxage;
    public float foodvalue;
    public string geneticcode;
    public static string gen;
    private float nexactiontime = 0.0f;
    private bool sik;

    void Start () {
        sik = false;
        Age = 0;
        totallife = startlife;
        metabolism = Random.Range(1f, 3f);
        maxage = Random.Range(60f, 200f);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == Tag)
        {
            transform.localScale += new Vector3(growp, growp, growp/10);
            Destroy(other.gameObject);
            totallife = totallife + foodvalue;
        }    
    }

    // Update is called once per frame
    void FixedUpdate () {
        Age = Age + Time.deltaTime;
        Test transformvalue = gameObject.GetComponent<Test>();
        int temp = (int)testc.Truncate(transformvalue.xmag * 100);
        string x = Conva.ToString(temp,2);
        temp = (int)testc.Truncate(transformvalue.ymag * 100);
        string y = Conva.ToString(temp,2);
        temp = (int)testc.Truncate(transform.localScale.x * 100);
        string size = Conva.ToString(temp,2);
        temp = (int)testc.Truncate(metabolism * 100);
        string meta = Conva.ToString(temp,2);
        //Acondicionamiento
        var xlen = x.Length;
        if (xlen < 10)
        {
            for (int i = xlen; i < 10; i++)
            {
                x = "0" + x;
            }
        }
        var ylen = y.Length;
        if (ylen < 10)
        {
            for (int i = ylen; i < 10; i++)
            {
                y = "0" + y;
            }
        }
        var metalen = meta.Length;
        if (metalen < 10)
        {
            for (int i = metalen; i < 10; i++)
            {
               meta = "0" + meta;
            }
        }
        var sizelen = size.Length;
        if (sizelen < 10)
        {
            for (int i = sizelen; i < 10; i++)
            {
                size = "0" + size;
            }
        }
        geneticcode = x + y + size + meta;
        
        if (!sik)
        {
            gen = geneticcode;
            sik = true;
        }
        
        Debug.Log("PREY: Life: " + totallife + ", Age: " + Age + ", Max Age: " + maxage + ", Metabolism: " + metabolism + ", GenCode: " + gen);
        if (Time.time > nexactiontime)
        {
            nexactiontime += metabolism;
            totallife = totallife - 1;
            if (totallife <= 0)
            {
                Destroy(this.gameObject);
            }
            if (Age >= maxage)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
