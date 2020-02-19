using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    Ray Ray;
    RaycastHit Hit;
    public PlanetsInfo PlanetInfoRef;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // Planet click detection
        if (Input.GetMouseButtonDown(0))
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);     
            if (Physics.Raycast(Ray, out Hit))
            {
                if (Hit.transform.tag == "Planet")
                {
                    PlanetInfoRef.PlanetFinder(Hit.transform.name);
                }
                else
                {
                }
            }
        }

   
    }

}
