using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public SoundManager SoundManagerRef;
    private void Start()
    {
        SoundManagerRef.PlaySound("Music");
    }
    public void BeginMainScene()
    {
        SoundManagerRef.PlaySound("Menu Selection");
        SceneManager.LoadScene("JeppeScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
