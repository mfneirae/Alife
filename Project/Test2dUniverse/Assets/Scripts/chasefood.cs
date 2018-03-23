using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chasefood : MonoBehaviour {
    public float Speed;
    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("empanada");
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
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        Target = FindClosestEnemy().transform;
        transform.position = Vector2.MoveTowards(transform.position, Target.position, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
	}
}
