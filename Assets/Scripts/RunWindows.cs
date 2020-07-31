using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunWindows : MonoBehaviour
{
    public GameObject selectedWindow;
    public GameObject[] windowsToChooseFrom;
    public Material fireMat;
    public Material startingMat;
    public int score = 0;
    public float windowTime;

    // Start is called before the first frame update
    void Start()
    {
        windowTime = Random.Range(2, 4);
        InvokeRepeating("WindowSelector", 1, windowTime);
        
       
    }

    // Update is called once per frame
    void Update()
    {
        
        Debug.Log(score);
    }

    void WindowSelector()
    {
        selectedWindow = windowsToChooseFrom[(Random.Range(0, 4))];
        selectedWindow.GetComponent<Renderer>().material = fireMat;        
        selectedWindow.tag = "CurWindow";
        Invoke("ResetWindow", windowTime);
    }

    void ResetWindow()
    {
        selectedWindow.GetComponent<Renderer>().material = startingMat;
        selectedWindow.tag = "Window";
    }
       
       



}
