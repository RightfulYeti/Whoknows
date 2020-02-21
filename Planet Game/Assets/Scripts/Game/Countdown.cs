using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Countdown : MonoBehaviour
{
    public float Timer;

    // Update is called once per frame
    void Update()
    {
        if (Timer >= 0.0f)
        {
            print(Timer);
            Timer -= Time.deltaTime;
            int DisplayTimer = (int)Timer+1;
            gameObject.GetComponent<Text>().text = DisplayTimer.ToString();
        }
        else if (Timer <= 0)
        {
            gameObject.GetComponent<Text>().enabled = false;
        }
    }
}
