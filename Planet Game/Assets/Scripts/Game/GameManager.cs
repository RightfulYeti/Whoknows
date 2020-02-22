using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Planet;
    public bool NewPlanet; 

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {   
        if (NewPlanet)
        {
            Instantiate(Planet, new Vector3(Random.Range(-100, 100), -50, 50), Planet.transform.rotation);
            NewPlanet = false;
        }
    }
}
