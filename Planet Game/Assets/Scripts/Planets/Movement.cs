﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float SpeedFactor;
    public float MinSpeed;
    public float MaxSpeed;
    private float Timer = 0.0f;
    bool Collided = false;
    private int CurrentTarget;
    GameObject StartingPoint;
    GameObject NewTarget;
    GameManager GameManagerRef;
    SoundManager SoundManagerRef;
    private Rigidbody RigidbodyRef;
    public List<Transform> Target;

    // Start is called before the first frame update
    void Start()
    {
        RigidbodyRef = gameObject.GetComponent<Rigidbody>();
        StartingPoint = new GameObject();
        StartingPoint.transform.position = gameObject.transform.position;
        GameManagerRef = FindObjectOfType<GameManager>();
        SoundManagerRef = FindObjectOfType<SoundManager>();
        StartCoroutine(Waiter());
        Speed = Random.Range(MinSpeed, MaxSpeed);
        float RandomScale = Random.Range(3.5f, 15.0f);
        gameObject.transform.localScale = new Vector3(RandomScale, RandomScale, RandomScale);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;

        if (!Collided)
        {
            RigidbodyRef.velocity = transform.forward * Speed;
        }

        if (!Collided && Timer > 0.1f)
        {
            NewTarget = new GameObject();
            NewTarget.transform.position = gameObject.transform.position;
            Target.Add(NewTarget.transform);
            Timer = 0.0f;
        }

        if (Input.GetKey(KeyCode.LeftArrow) && !Collided)
        {
            transform.Rotate(0, -1f, 0);
        }
        else if (Input.GetKey(KeyCode.RightArrow) && !Collided)
        {
            transform.Rotate(0, 1f, 0);
        }

        if (Collided)
        {
            RigidbodyRef.isKinematic = true;
            if (transform.position != Target[CurrentTarget].position)
            {
                Vector3 Pos = Vector3.MoveTowards(transform.position, Target[CurrentTarget].position, Speed * SpeedFactor);
                RigidbodyRef.MovePosition(Pos);
            }
            else if (transform.position == Target[CurrentTarget].position && CurrentTarget == Target.Count - 1)
            {
                CurrentTarget = 0;
            }
            else
            {
                CurrentTarget = CurrentTarget + 1 % Target.Count;
            }
            RigidbodyRef.MoveRotation(Target[CurrentTarget].transform.rotation);
        }
    }

    IEnumerator Waiter()
    {
        yield return new WaitForSecondsRealtime(2);
        StartingPoint.AddComponent<SphereCollider>();
        StartingPoint.GetComponent<SphereCollider>().radius = 1.5f;
        yield return new WaitForSecondsRealtime(1);
        StopCoroutine(Waiter());
    }

    private void OnCollisionEnter(Collision collision)
    {
        Collided = true;
        if (collision.gameObject.tag == "Planet")
        {
            SoundManagerRef.PlaySound("Boom");
            GameManagerRef.PlanetScore -= 1;
            Destroy(gameObject);
        }
        FindObjectOfType<Countdown>().Counting = true;
        FindObjectOfType<Countdown>().GetComponent<Text>().enabled = true;
        if (StartingPoint.GetComponent<SphereCollider>())
        {
            StartingPoint.GetComponent<SphereCollider>().enabled = false;
        }
        gameObject.GetComponent<TrailRenderer>().enabled = false;
    }
}
