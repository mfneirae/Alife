using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawnfood : MonoBehaviour
{
    public GameObject Food;
    public GameObject Sugar;
    public float speed;
    public float speeds;
    public int total;
    private int lx;
    private int ly;
    public float season_duration;
    public float io;
    private int count;
    private float nextactiontime;
    private float nextactiontimes = 0.0f;

    private void FixedUpdate()
    {
        if (total >= 1)
        {
            Generate();
            total = total - 1;
        }
        if (Time.time > nextactiontime)
        {
            nextactiontime += season_duration;
            count = count + 1;
        }
        io = (count % 2) + 1;

        if (Time.time > nextactiontimes)
        {
            nextactiontimes += speeds;
            if (io < 2)
            {
                if (this.gameObject.tag == "Lsystem1")
                {
                    Invoke("Generatesugar", 1);
                }
            }
            else if (io >= 2)
            {
                if (this.gameObject.tag == "Lsystem2")
                {
                    Invoke("Generatesugar", 1);
                }
            }
        }
    }

    void Generate()
    {
        lx = Random.Range(0, Camera.main.pixelWidth);
        ly = Random.Range(0, Camera.main.pixelHeight);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(lx, ly, 0));
        Target.z = -2;

        Instantiate(Food, Target, Quaternion.identity);
    }
    void Generatesugar()
    {
        int x = Random.Range(lx - 80, lx + 80);
        int y = Random.Range(ly - 80, ly + 80);

        Vector3 Target = Camera.main.ScreenToWorldPoint(new Vector3(x, y, 0));
        Target.z = 0;

        Instantiate(Sugar, Target, Quaternion.identity);
    }
}
