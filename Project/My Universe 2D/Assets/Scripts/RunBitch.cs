using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunBitch : MonoBehaviour
{
    public float period;
    public float Speed;
    private Vector2 temp;
    private float nexactiontime = 0.0f;

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("predator");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
    private Transform Target;
    // Use this for initialization
    private void Start()
    {
        temp = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
    }
    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        eatfood life = gameObject.GetComponent<eatfood>();
        if (life.totallife >= 5)
        {
            Target = FindClosestEnemy().transform;
            if (Mathf.Abs(Target.position.x) - Mathf.Abs(transform.position.x) <=0.05)
            {
                temp = (transform.position + Target.position).normalized;
                Debug.Log("DANGEEEER");
                Debug.Log(transform.position + Target.position);
                transform.position = Vector2.MoveTowards(transform.position, temp, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
            }
        }
    }
}