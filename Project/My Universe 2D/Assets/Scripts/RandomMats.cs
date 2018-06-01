using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMats : MonoBehaviour {
    public Material[] randomMaterials;
    public GameObject[] ColoredWalls;
        // Use this for initialization
	void Start () {
        foreach (GameObject wall in ColoredWalls)
        {
            wall.GetComponent<Renderer>().material = randomMaterials[Random.Range(0, randomMaterials.Length)];
        }
	}
	
}
