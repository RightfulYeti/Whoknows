using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetsInfo : MonoBehaviour
{
    public Planet[] Planets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string PlanetFinder(string planetname)
    {
        for (int i = 0; i < Planets.Length; i++)
        {
            print(Planets[i].name);
            if (Planets[i].name == planetname)
            {
                return Planets[i].name;
            }
        }
        return null;
    }
}
