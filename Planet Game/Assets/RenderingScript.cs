using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderingScript : MonoBehaviour
{
    private MeshRenderer PlanetMesh;
    public Material[] MaterialList;
    // Start is called before the first frame update
    void Start()
    {
        PlanetMesh = GetComponent<MeshRenderer>();
        int RandomMesh = Random.Range(0, 7);
        PlanetMesh.material = MaterialList[RandomMesh];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
