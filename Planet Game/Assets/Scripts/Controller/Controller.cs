using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ResourceType {WATER, FOOD, MONEY};

class ResourceInfo
{
    public Transform ParentPlanet;
    public ResourceType RType;
}

public class Controller : MonoBehaviour
{
    Ray Ray;
    RaycastHit Hit;
    public PlanetsInfo PlanetInfoRef;
    private bool Selected = false;

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
        if (Input.GetMouseButton(0) && !Selected)
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit))
            {
                if (Hit.transform.tag == "Resource")
                {
                    if (Hit.transform.parent.tag == "Money Bar")
                    {
                        print("Holding button on a Money resource!");
                        ResourceInfo ResourceAction = new ResourceInfo();
                        ResourceAction.ParentPlanet = Hit.transform.parent.parent.parent;
                        ResourceAction.RType = ResourceType.MONEY;
                    }
                    else if (Hit.transform.parent.tag == "Water Bar")
                    {
                        print("Holding button on a Water resource!");
                        ResourceInfo ResourceAction = new ResourceInfo();
                        ResourceAction.ParentPlanet = Hit.transform.parent.parent.parent;
                        ResourceAction.RType = ResourceType.WATER;
                    }
                    else if (Hit.transform.parent.tag == "Food Bar")
                    {
                        print("Holding button on a Food resource!");
                        ResourceInfo ResourceAction = new ResourceInfo();
                        ResourceAction.ParentPlanet = Hit.transform.parent.parent.parent;
                        ResourceAction.RType = ResourceType.FOOD;
                    }
                    Selected = true;
                }
                else
                {
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            print("Released mouse button!");
        }

    }

}
