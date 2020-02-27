using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public float BufferZone;
    private Camera Cam;
    private TrailRenderer PlanetTrailRenderer;
    private float Timer = 0.0f;
    private float PlanetWidth;
    private float PlanetHeight;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        PlanetTrailRenderer = gameObject.GetComponent<TrailRenderer>();
        PlanetWidth = GetComponent<MeshRenderer>().bounds.size.x / 2;
        PlanetHeight = GetComponent<MeshRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (Cam.WorldToViewportPoint(transform.position).x <= 0)
        {
            print("1");
            transform.forward = transform.forward * -1;
            transform.position = new Vector3(transform.position.x + PlanetWidth, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        // Screen right bounds
        if (Cam.WorldToViewportPoint(transform.position).x >= 1)
        {
            print("2");
            transform.forward = transform.forward * -1;
            transform.position = new Vector3(transform.position.x - PlanetWidth, transform.position.y, transform.position.z);
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        // Screen bottom bounds
        if (Cam.WorldToViewportPoint(transform.position).y <= 0)
        {
            print("3");
            transform.forward = transform.forward * -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + PlanetWidth);
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
        // Screen top bounds
        if (Cam.WorldToViewportPoint(transform.position).y >= 1)
        {
            print("4");
            transform.forward = transform.forward * -1;
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - PlanetWidth);
            transform.rotation = Quaternion.LookRotation(transform.forward);
        }
    }
}
