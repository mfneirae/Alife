using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tree : MonoBehaviour {
    System.Random rnd;
    private float maxG;
    private float grow;
    private float scale = 0;
    
    void Start () {
        rnd= new System.Random(GetInstanceID());
        maxG = rnd.Next(1, 5);
        grow = rnd.Next(1, 10);
        Debug.Log(maxG);
    }
	
	// Update is called once per frame
	void FixedUpdate() {
        if (scale < maxG/2)
        {
            this.transform.localScale = Vector3.one * scale;
            scale += grow/50 * Time.deltaTime;
        }
     }
}
