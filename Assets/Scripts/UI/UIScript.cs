using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public GameObject gameController;
    
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        score = GameObject.Find("GameTroller").GetComponent<RunWindows>().score;
        gameObject.GetComponent<Text>().text = "Score: " + score.ToString();
    }
}
