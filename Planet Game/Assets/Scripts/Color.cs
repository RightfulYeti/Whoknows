using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color : MonoBehaviour
{
    private float Speed;
    public UnityEngine.Color StartColor;
    public UnityEngine.Color EndColor;
    public bool Repeatable = false;
    float StartTime;

    // Start is called before the first frame update
    void Start()
    {
        StartTime = Time.time;
        StartColor = new UnityEngine.Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        EndColor = new UnityEngine.Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        Speed = Random.Range(0.1f, 1.0f);
        GetComponent<Renderer>().material.color = StartColor;
    }

    // Update is called once per frame
    void Update()
    {
        //if (!Repeatable)
        //{
        //    float t = (Time.time - StartTime) * Speed;
        //    GetComponent<Renderer>().material.color = UnityEngine.Color.Lerp(StartColor, EndColor, t);
        //}
        //else
        //{
        //    float t = (Mathf.Sin(Time.time - StartTime) * Speed);
        //    GetComponent<Renderer>().material.color = UnityEngine.Color.Lerp(StartColor, EndColor, t);
        //}
    }
}
