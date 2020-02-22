using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float Timer;
    public float CDTimer;
    private GameManager GameManagerRef;
    public bool Counting = true;
    private void Start()
    {
        GameManagerRef = FindObjectOfType<GameManager>();
        CDTimer = Timer;
    }

    // Update is called once per frame
    void Update()
    {
        if (CDTimer >= 0.0f)
        {
            GameManagerRef.NewPlanet = false;
            if (Counting)
                CDTimer -= Time.deltaTime;
            int DisplayTimer = (int)CDTimer + 1;
            gameObject.GetComponent<Text>().text = DisplayTimer.ToString();
        }
        else if (CDTimer <= 0.0f)
        {
            GameManagerRef.NewPlanet = true;
            gameObject.GetComponent<Text>().enabled = false;
            CDTimer = Timer;
            Counting = false;
        }
    }
}
