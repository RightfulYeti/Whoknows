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
    private int CurrentActiveUISprite;
    public Image Image1;
    public Image Image2;
    public Image Image3;

    private void Start()
    {
        GameManagerRef = FindObjectOfType<GameManager>();
        CDTimer = Timer;
        CurrentActiveUISprite = 1;
        Image1.gameObject.SetActive(false);
        Image2.gameObject.SetActive(false);
        Image3.gameObject.SetActive(false);
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
            //gameObject.GetComponent<Text>().text = DisplayTimer.ToString();
            CurrentActiveUISprite = DisplayTimer;
        }
        else if (CDTimer <= 0.0f)
        {
            GameManagerRef.NewPlanet = true;
            gameObject.GetComponent<Text>().enabled = false;
            CDTimer = Timer;
            Counting = false;
            CurrentActiveUISprite = 0;
            Image1.gameObject.SetActive(false);
            Image2.gameObject.SetActive(false);
            Image3.gameObject.SetActive(false);
        }

        if (CurrentActiveUISprite == 1)
        {
            Image1.gameObject.SetActive(true);
            Image2.gameObject.SetActive(false);
            Image3.gameObject.SetActive(false);
        }
        else if (CurrentActiveUISprite == 2)
        {
            Image1.gameObject.SetActive(false);
            Image2.gameObject.SetActive(true);
            Image3.gameObject.SetActive(false);
        }
        else if (CurrentActiveUISprite == 3)
        {
            Image1.gameObject.SetActive(false);
            Image2.gameObject.SetActive(false);
            Image3.gameObject.SetActive(true);
        }
    }
}
