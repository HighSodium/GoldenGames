using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeCam : MonoBehaviour
{
    public GameObject peeObject;
    public float peeSpread = 50f;
    public float killDelay = 3f;

    public GameObject spawnedPee;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space"))
        {
            if(!IsInvoking("SpawnPeeWithForce"))
                InvokeRepeating("SpawnPeeWithForce", 0,0.03f);
        }
        else
        {
            CancelInvoke("SpawnPeeWithForce");
        }
    }
    
    /// <summary>
    /// Create pee and set a force
    /// </summary>
    void SpawnPeeWithForce()
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
        Destroy(spawnedPee, killDelay); // remove after a set amount

        float mass = spawnedPee.GetComponent<Rigidbody>().mass;
        spawnedPee.GetComponent<Rigidbody>().AddForce(peeVec*mass);
    }
}
