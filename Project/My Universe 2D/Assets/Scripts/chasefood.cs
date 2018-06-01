using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Conva = System.Convert;

public class chasefood : MonoBehaviour {
    public float Speed;
    public GameObject baby;
    public float agendaded;
    public float period;
    private Vector3 temp;
    private Transform Target;
    private Transform Targetl;
    private bool runbitch = false;
    private float nexactiontime = 1.0f;
    private bool born = false;
    private bool letsgetiton = false;
    public string childgeneticode;
    private bool iscreated = false;

    public GameObject FindClosestAlly()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("prey");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (go.gameObject != this.gameObject)
            {
                if (curDistance < distance)
                {
                    if (curDistance >= 3f)
                    {
                        closest = go;
                        distance = curDistance;
                    }
                    else
                    {
                        temp = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 1.0f);
                        closest = new GameObject();
                        closest.transform.position = temp;
                    }
                }
            }
        }
        return closest;
    }

    public GameObject FindClosestlover()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("prey");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (go.gameObject != this.gameObject)
            {
                if (curDistance < distance)
                {
                    if (agendaded > 10)
                    {
                        closest = go;
                        distance = curDistance;
                        if (curDistance <= 0.1f)
                        {
                            born = true;
                        }
                    }
                    else if (agendaded <= 10 || iscreated == true)
                    {
                        temp = new Vector3(Random.Range(-4f, 4f), Random.Range(-4f, 4f), 1.0f);
                        closest = new GameObject();
                        closest.transform.position = temp;
                    }
                }
            }
        }
        return closest;
    }

    public GameObject FindClosestEnemy()
    {
        GameObject[] gos;
        gos = GameObject.FindGameObjectsWithTag("predator");
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        temp = new Vector3(Random.Range(-8f, 8f), Random.Range(-2f, 2f), 1.0f);
        closest = new GameObject();
        closest.transform.position = temp;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                if (curDistance<5.0f)
                {
                    runbitch = true;
                    var distances = diff.magnitude;
                    var direction = diff / distances;
                    var nexttarget = new Vector3(this.gameObject.transform.position.x - direction.x, this.gameObject.transform.position.y - direction.y, 1.0f);
                    Debug.Log("RUN BITCH");
                    closest = new GameObject();
                    closest.transform.position = nexttarget;
                }
                else
                {
                    runbitch = false;
                    Debug.Log("All clear");
                }
            }
        }
        return closest;
    }

    public GameObject FindClosestFood()
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
	// Use this for initialization
	void Start () {
        temp = new Vector3(Random.Range(-8f, 8f), Random.Range(-2f, 2f), 1.0f);
        transform.position = Vector2.MoveTowards(transform.position, temp, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
    }

    // Update is called once per frame
    void FixedUpdate () {
        var contador = 0;
        eatfood life = gameObject.GetComponent<eatfood>();
        agendaded = life.Age;
        Target = FindClosestEnemy().transform;
        
        if (agendaded > 10 && runbitch == false)
        {
            Targetl = FindClosestlover().transform;
            eatfood lifelov = Targetl.gameObject.GetComponent<eatfood>();
            for (int i = 0; i < 40; i++)
            {
                if (lifelov.geneticcode[i] == life.geneticcode[i])
                {
                    contador += 1;
                }
            }
            if (contador >= 25)
            {
                letsgetiton = true;
            }
            else
            {
                letsgetiton = false;
            }
        }
        if (life.totallife < 5 )
        {
            Target = FindClosestFood().transform;
            transform.position = Vector2.MoveTowards(transform.position, Target.position, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
        }
       else if (life.totallife >= 5 && runbitch == true)
        {   
            if (Time.time > nexactiontime)
            {
                nexactiontime += period;
                Target = FindClosestEnemy().transform;
            }
            transform.position = Vector2.MoveTowards(transform.position, Target.position, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
        }
        else if (life.totallife < 28)
        {
            Target = FindClosestFood().transform;
            transform.position = Vector2.MoveTowards(transform.position, Target.position, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
        }
        else if (life.totallife > 30 && letsgetiton == true && agendaded > 10 && iscreated == false)
        {
            Targetl = FindClosestlover().transform;
            eatfood lifelov = Targetl.gameObject.GetComponent<eatfood>();
            var transform1 = "";
            var transform2 = "";
            var siz = "";
            var meta = "";
            var newgen = "";
            //Crossover
            for (int i = 0; i < 40; i++)
            {
                if (i % 2 == 1)
                {
                    newgen += life.geneticcode[i];
                }
                else
                {
                    newgen += lifelov.geneticcode[i];
                }
                if (i < 10)
                {
                    transform1 += lifelov.geneticcode[i];
                }
                else if (i >= 10 && i < 20)
                {
                    transform2 += lifelov.geneticcode[i];
                }
                else if (i >= 20 && i < 25)
                {
                    siz += lifelov.geneticcode[i];
                }
                else
                {
                    meta += lifelov.geneticcode[i];
                }
            }

            int xtrans = Conva.ToInt32(transform1, 2);
            float xtransf = (float)xtrans / 100;
            int ytrans = Conva.ToInt32(transform2, 2);
            float ytransf = (float)ytrans / 100;
            int sizi = Conva.ToInt32(siz, 2);
            float sizif = (float)sizi / 100;
            int meti = Conva.ToInt32(meta, 2);
            float metif = (float)meti / 100;
            transform.position = Vector2.MoveTowards(transform.position, Targetl.position, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
            if (!iscreated && born)
            { 
                var child = Instantiate(baby,this.gameObject.transform.position,Quaternion.identity);
                eatfood.gen = newgen;
                Debug.Log("---------------------------------------->" + newgen);
                iscreated = true;
                born = false;
                life.totallife = life.totallife - 10;
            }
        }
        else
        {
            if (Time.time > nexactiontime)
           {
                nexactiontime += period;
                Target = FindClosestAlly().transform;
            }
            transform.position = Vector2.MoveTowards(transform.position, Target.position, (Speed * Time.deltaTime * 10) / (transform.localScale.x));
        }
    }
}
