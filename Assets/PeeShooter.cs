using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeShooter : MonoBehaviour
{
    public GameObject Peedrop;
    private GameObject peeObj;
    private Vector3 Peepos;
    private Rigidbody playerRB;
    private GameObject spawnedPee;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnPee", .5f, .2f);
        //InvokeRepeating("KillPee", .5f, .5f);
        peeObj = GameObject.FindGameObjectWithTag("Player");
        Peepos = new Vector3(peeObj.transform.position.x, peeObj.transform.position.y, peeObj.transform.position.z +2);
        playerRB = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Jump")){
            InvokeRepeating("SpawnPee", Random.Range(.1f,.8f), Random.Range(.0f, .8f));
            
        }
        else if (Input.GetKeyUp(KeyCode.Space)) {
            CancelInvoke();
        }

       
    }

    void SpawnPee()
    {

        spawnedPee = Instantiate(Peedrop, Peepos, peeObj.transform.rotation);
        spawnedPee.GetComponent<Rigidbody>().AddForce(Vector3.forward * 40, ForceMode.Impulse);
        spawnedPee.GetComponent<Rigidbody>().AddForce(Vector3.up * 20, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
