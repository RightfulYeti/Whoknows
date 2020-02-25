using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Planet;
    public Text PlanetScoreText;
    public bool NewPlanet;
    public int PlanetScore = 0;
    private Camera Cam;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {   
        if (NewPlanet)
        {
            Vector3 ScreenRandomStartPos = new Vector3(Random.Range(0.0f, 1.0f), Random.Range(0, Screen.height), Random.Range(-30, 200));
            Vector3 WorldRandomStartPos = new Vector3(Cam.ViewportToWorldPoint(ScreenRandomStartPos).x, -50, ScreenRandomStartPos.z);
            print(WorldRandomStartPos);
            Instantiate(Planet, WorldRandomStartPos, Planet.transform.rotation);
            PlanetScore++;
            NewPlanet = false;
        }

        PlanetScoreText.text = PlanetScore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            FindObjectOfType<SoundManager>().StopSound("Music");
        }
    }
}
