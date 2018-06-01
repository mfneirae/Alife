using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {
    // Use this for initialization
    public Renderer test;
    public float xmag;
    public float ymag;
    void Start () {
        test = GetComponent<Renderer>();
        test.material.shader = Shader.Find("Martin/ImageDistortionBasic");
        xmag = Random.Range(0.1f, 1.0f);
        ymag = Random.Range(0.1f, 1.0f);
    }
	
	// Update is called once per frame
	void Update () {
        
        test.material.SetFloat("_XTimer",xmag);
        test.material.SetFloat("_YTimer",ymag);
    }
}
