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
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (gameObject.GetComponent<TrailRenderer>().emitting)
                gameObject.GetComponent<TrailRenderer>().emitting = false;
            else
                gameObject.GetComponent<TrailRenderer>().emitting = true;
        }
    }

    void OnBecameInvisible()
    {
        gameObject.GetComponent<TrailRenderer>().emitting = false;
        if (Cam != null)
        {
           // print(Cam.WorldToViewportPoint(transform.position));
            if (Cam.WorldToViewportPoint(transform.position).x < 0)
            {
                print("1");
                transform.forward = transform.forward * -1;
                //transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
            }
            else if (Cam.WorldToViewportPoint(transform.position).x > 1)
            {
                print("2");
                transform.forward = transform.forward * -1;
                //transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
            }
            else if (Cam.WorldToViewportPoint(transform.position).y < 0)
            {
                print("3");
                transform.forward = transform.forward * -1;
            }
            else if (Cam.WorldToViewportPoint(transform.position).y > 1)
            {
                print("4");
                transform.forward = transform.forward * -1;
            }
        }
    }

    private void OnBecameVisible()
    {
        //print("Visible!");
        gameObject.GetComponent<TrailRenderer>().emitting = true;
    }
}
