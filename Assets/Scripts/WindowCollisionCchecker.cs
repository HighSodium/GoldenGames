using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowCollisionCchecker : MonoBehaviour
{
    private GameObject thisSelectedWindow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        thisSelectedWindow = GameObject.Find("GameTroller").GetComponent<RunWindows>().selectedWindow;

    }

    public void OnCollisionEnter(Collision collision)
    {
        if (gameObject.tag == "CurWindow")
        {
            Debug.Log(this.gameObject.tag + "Collided with:" + collision.gameObject.tag);
            GameObject.Find("GameTroller").GetComponent<RunWindows>().score++;
        }
    }

}
