using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initialize : MonoBehaviour {
    public GameObject Food;
    public float cantidad;
    // Use this for initialization
    void Start () {
        for (int i = 0; i < cantidad; i++)
        {
            Generate();
        }
	}
    void Generate()
    {
        int x = Random.Range(0, Camera.main.pixelWidth);
        int y = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = -2;

        Instantiate(Food, Target, Quaternion.identity);
    }
}
