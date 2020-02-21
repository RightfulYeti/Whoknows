using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float Speed;
    public float SpeedFactor;
    private Rigidbody RigidbodyRef;
    GameObject StartingPoint;
    GameObject NewTarget;
    bool Collided = false;
    private int CurrentTarget;
    public List<Transform> Target;

    private float Timer = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        RigidbodyRef = gameObject.GetComponent<Rigidbody>();
        StartingPoint = new GameObject();
        StartingPoint.transform.position = gameObject.transform.position;
        StartCoroutine(Waiter());
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
                print("poasd");
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
        gameObject.GetComponent<SphereCollider>().enabled = false;
        gameObject.GetComponent<TrailRenderer>().enabled = false;
    }
}
