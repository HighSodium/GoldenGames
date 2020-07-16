using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeCam : MonoBehaviour
{
    public GameObject peeObject;
    public float peeSpread = 50f;

    GameObject spawnedPee;
    private bool firePee;
    
    // Start is called before the first frame update
    void Start()
    {
        firePee = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            if(!IsInvoking("spawnPeeWithForce"))
                InvokeRepeating("spawnPeeWithForce", 0,0.03f);
        }
        else
        {
            CancelInvoke("spawnPeeWithForce");
        }
    }
    
    void spawnPeeWithForce()
    {
        
        Transform t = this.transform;
        
        //force vector
        Vector3 peeVec = 
            t.position + 
            t.forward*1000 + 
            (t.right*Random.Range(-peeSpread, peeSpread)) + 
            (t.up*Random.Range(-peeSpread, peeSpread)); 

        Vector3 peeOrig = t.position + t.forward*0.5f + t.right; //position of spawn

        spawnedPee = Instantiate(peeObject, peeOrig, Quaternion.identity);

        float mass = spawnedPee.GetComponent<Rigidbody>().mass;
        spawnedPee.GetComponent<Rigidbody>().AddForce(peeVec*mass);
    }
}
