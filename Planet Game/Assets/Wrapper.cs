using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wrapper : MonoBehaviour
{
    public float BufferZone;
    private Camera Cam;
    private TrailRenderer PlanetTrailRenderer;
    private int VisibilitySwap = 0;
    private float Timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        PlanetTrailRenderer = gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            if (PlanetTrailRenderer.emitting)
                PlanetTrailRenderer.emitting = false;
            else
                PlanetTrailRenderer.emitting = true;
        }


        //if (VisibilitySwap == 1)
        //{
        //    Timer += Time.deltaTime;
        //}
        //if (Timer >= 0.50f && VisibilitySwap == 0)
        //{
        //    PlanetTrailRender.emitting = true;
        //    Timer = 0.0f;
        //}
    }

    void OnBecameInvisible()
    {
        //VisibilitySwap = 1;
        print("Invisible!");
        //PlanetTrailRenderer.enabled = false;
       PlanetTrailRenderer.emitting = false;
        if (Cam)
        {
            // Screen left bounds
            if (Cam.WorldToViewportPoint(transform.position).x < 0)
            {
                //transform.position = new Vector3(transform.position.x * Screen.Width, transform.position.y, transform.position.z);
                print("1");
                transform.forward = transform.forward * -1;
                //transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
            }
            // Screen right bounds
            else if (Cam.WorldToViewportPoint(transform.position).x > 1)
            {
                print("2");
                transform.forward = transform.forward * -1;
                //transform.position = new Vector3(transform.position.x * -1, transform.position.y, transform.position.z);
            }
            // Screen bottom bounds
            else if (Cam.WorldToViewportPoint(transform.position).y < 0)
            {
                print("3");
                transform.forward = transform.forward * -1;
            }
            // Screen top bounds
            else if (Cam.WorldToViewportPoint(transform.position).y > 1)
            {
                print("4");
            }
            // This code is for ricochet effect / bouncing off the screen sides
            transform.forward = transform.forward * -1;
        }
    }

    private void OnBecameVisible()
    {
        VisibilitySwap = 0;
        print("Visible!");
        //PlanetTrailRenderer.enabled = true;
        //PlanetTrailRenderer.emitting = true;
    }
}
