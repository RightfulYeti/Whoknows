using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public float BufferZone;
    private Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnBecameInvisible()
    {
        if (transform.position.x < Cam.ViewportToWorldPoint(new Vector3(0, 0, transform.position.z)).x && (transform.position.z > -20 && transform.position.z < 200))
        {
            print("1");
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > Cam.ViewportToWorldPoint(new Vector3(1, 0, transform.position.z)).x && (transform.position.z > -20 && transform.position.z < 200))
        {
            print("2");
            transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
        }
        else if (transform.position.z < 0)
        {
            print("3");
            transform.position = new Vector3(transform.position.x, transform.position.y, 200);
        }
        else if (transform.position.z > 0)
        {
            print("4");
            transform.position = new Vector3(transform.position.x, transform.position.y, -30);
        }
    }
}
