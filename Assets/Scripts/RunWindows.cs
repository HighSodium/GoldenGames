using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWindows : MonoBehaviour
{
    public GameObject selectedWindow;
    public Material fireMat;
    public Material startingMat;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("WindowSelector", 1, Random.Range(2, 4));
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void WindowSelector()
    {
        selectedWindow = this.gameObject.transform.GetChild(Random.Range(1, 4)).gameObject;
        selectedWindow.GetComponent<Renderer>().material = fireMat;        
        selectedWindow.tag = "CurWindow";
    }

    
       
       
/*
        yield return new WaitForSeconds(waitTime);
        selectedWindow.GetComponent<Renderer>().material = startingMat;
        selectedWindow.tag = "Window";


    }*/
    
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(this.gameObject.tag + "Collided with:" + collision.gameObject.tag);
        score++;
       
    }
    
    /*
    private void OnTriggerEnter(Collider other)
    {
        
      
        if(other.gameObject.tag == selectedWindow.tag)
        {
            Debug.Log(gameObject.tag + "Collided with:" + other.gameObject.tag);
            score++;
        }
       
    }
    */



}
