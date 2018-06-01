using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject Food;
    public float speed;
    public int total;

    private void Start()
    {

    }

    private void FixedUpdate()
    {
        if (total >= 1)
        {
            Generate();
            total = total - 1;
            Debug.Log(total);
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
