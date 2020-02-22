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

    // Start is called before the first frame update
    void Start()
    {
        PlanetScoreText = FindObjectOfType<Canvas>().transform.GetChild(1).GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (NewPlanet)
        {
            Instantiate(Planet, new Vector3(Random.Range(-100, 100), -50, 50), Planet.transform.rotation);
            PlanetScore++;
            NewPlanet = false;
        }

        PlanetScoreText.text = PlanetScore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
