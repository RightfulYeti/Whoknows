using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public InputField IF;

    // Start is called before the first frame update
    void Start()
    {
        IF = FindObjectOfType<InputField>();
        IF.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
