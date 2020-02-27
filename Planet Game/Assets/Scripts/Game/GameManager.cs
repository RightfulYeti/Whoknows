using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Planet;
    private float Radius;
    public Text PlanetScoreText;
    public bool NewPlanet;
    public int PlanetScore = 0;
    private Camera Cam;
    public float Timeleft;
    public float ReturnTime;
    public Text TimeLeftText;
    public Text ReturnText;

    // Start is called before the first frame update
    void Start()
    {
        Cam = Camera.main;
        Radius = Planet.GetComponent<MeshRenderer>().bounds.size.x / 2;
        ReturnText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Timeleft > 0.0f && !FindObjectOfType<Countdown>().Counting)
        {
            Timeleft -= Time.deltaTime;
        }
      
        if (NewPlanet)
        {
            Vector3 ScreenRandomStartPos = new Vector3(Random.Range(-84, 85), 0, Random.Range(-10, 70));
            Vector3 WorldRandomStartPos = new Vector3(ScreenRandomStartPos.x, -50, ScreenRandomStartPos.z);
            print(WorldRandomStartPos);
            Instantiate(Planet, WorldRandomStartPos, Planet.transform.rotation);
            PlanetScore++;
        }

        PlanetScoreText.text = PlanetScore.ToString();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
            FindObjectOfType<SoundManager>().StopSound("Music");
        }

        if (Timeleft <= 0)
        {
            Planet.GetComponent<Movement>().GameOver = true;
            FindObjectOfType<Countdown>().enabled = false;
            NewPlanet = false;
            ReturnText.enabled = true;
            ReturnTime -= Time.deltaTime;
            if (ReturnTime <= 0)
            {
                SceneManager.LoadScene("Menu", LoadSceneMode.Single);
            }
        }
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(Timeleft / 60F);
        int seconds = Mathf.FloorToInt(Timeleft - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);

        int minutes2 = Mathf.FloorToInt(ReturnTime / 60F);
        int seconds2 = Mathf.FloorToInt(ReturnTime - minutes2 * 60);
        string niceTime2 = string.Format("{0:0}:{1:00}", minutes2, seconds2);

        ReturnText.text = "Congratulations! You created " + PlanetScore + " orbits! \n Returning to main menu in: " + niceTime2;
        TimeLeftText.text = niceTime;
        if (Timeleft < 0)
        {
            TimeLeftText.text = "00:00";
        }
    }
}
