using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum ResourceType {WATER, FOOD, MONEY, EMPTY};

class Resource
{
    public Transform FromPlanet;
    public Transform ToPlanet;
    public ResourceType RType;
}

public class Controller : MonoBehaviour
{
    Ray Ray;
    RaycastHit Hit;
    public PlanetsInfo PlanetInfoRef;
    Resource ResourceSelection;
    private bool Selected = false;
    GameManager GameManagerRef;

    // Start is called before the first frame update
    void Start()
    {
        GameManagerRef = FindObjectOfType<GameManager>();
        GameManagerRef.IF.onEndEdit.AddListener(delegate { LockInput(GameManagerRef.IF); });
    }

    void LockInput(InputField input)
    {
        float ResourceTransferAmount = System.Single.Parse(GameManagerRef.IF.text);
        if (ResourceSelection.RType == ResourceType.FOOD)
        {
            if (ResourceSelection.FromPlanet.GetComponent<Planet>().Food - ResourceTransferAmount < 0 || ResourceSelection.ToPlanet.GetComponent<Planet>().Food + ResourceTransferAmount > 100)
            {
                print("Impossible!");
            }
            else
            {
                ResourceSelection.FromPlanet.GetComponent<Planet>().Food -= ResourceTransferAmount;
                ResourceSelection.ToPlanet.GetComponent<Planet>().Food += ResourceTransferAmount;
            }
           
        }
        else if (ResourceSelection.RType == ResourceType.WATER)
        {
            if (ResourceSelection.FromPlanet.GetComponent<Planet>().Water - ResourceTransferAmount < 0 || ResourceSelection.ToPlanet.GetComponent<Planet>().Water + ResourceTransferAmount > 100)
            {
                print("Impossible!");
            }
            else
            {
                ResourceSelection.FromPlanet.GetComponent<Planet>().Water -= ResourceTransferAmount;
                ResourceSelection.ToPlanet.GetComponent<Planet>().Water += ResourceTransferAmount;
            }
           
        }
        else if (ResourceSelection.RType == ResourceType.MONEY)
        {
            if (ResourceSelection.FromPlanet.GetComponent<Planet>().Money - ResourceTransferAmount < 0 || ResourceSelection.ToPlanet.GetComponent<Planet>().Money + ResourceTransferAmount > 100)
            {
                print("Impossible!");
            }
            else
            {
                ResourceSelection.FromPlanet.GetComponent<Planet>().Money -= ResourceTransferAmount;
                ResourceSelection.ToPlanet.GetComponent<Planet>().Money += ResourceTransferAmount;
            }
        }
        GameManagerRef.IF.gameObject.SetActive(false);
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
            }
        }
        if (Input.GetKey(KeyCode.Escape))
        {
            GameManagerRef.IF.gameObject.SetActive(false);
        }
        if (Input.GetMouseButton(0) && !Selected)
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit))
            {
                if (Hit.transform.tag == "Money Bar")
                {
                    ResourceSelection = new Resource();
                    ResourceSelection.FromPlanet = Hit.transform.parent.parent;
                    ResourceSelection.RType = ResourceType.MONEY;
                }
                else if (Hit.transform.tag == "Water Bar")
                {
                    ResourceSelection = new Resource();
                    ResourceSelection.FromPlanet = Hit.transform.parent.parent;
                    ResourceSelection.RType = ResourceType.WATER;
                }
                else if (Hit.transform.tag == "Food Bar")
                {
                    ResourceSelection = new Resource();
                    ResourceSelection.FromPlanet = Hit.transform.parent.parent;
                    ResourceSelection.RType = ResourceType.FOOD;
                }
                Selected = true;
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Ray, out Hit))
            {
                if (Hit.transform.tag == "Planet")
                {
                    print(Hit.transform.name);
                    ResourceSelection.ToPlanet = Hit.transform;
                }
            }
            Selected = false;
            GameManagerRef.IF.gameObject.SetActive(true);
        }
    }

}
