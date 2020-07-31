using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 leftUp = new Vector3(-16.854f, -13.933f, 0.789f);
    private Vector3 leftDown = new Vector3(6f, -16f, 0.789f);
    private Vector3 rightUp = new Vector3(-14.934f, 13.214f, 0.823f);
    private Vector3 rightDown = new Vector3(9f, 13.214f, 6f);

    
    public GameObject currentlySelectedWindow;
    private GameObject spawnedPee;
    private GameObject playerGoal;
    private  Vector3 peeDirection;
    private Vector3 peePos;

    public GameObject peeObject;

    [Tooltip ("The amount the pee spreads. (Higher is more)")]
    public float peeSpread = 50f;
    public float killDelay = 3f;



    // Start is called before the first frame update
    void Start()
    {
        peePos = new Vector3(transform.position.x, transform.position.y, transform.position.z + 2);
        
    }

    // Update is called once per frame
    void Update()
    {

        currentlySelectedWindow = GameObject.Find("Cube").GetComponent<RunWindows>().selectedWindow;

        //TLeft Input
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0)
        {
            transform.eulerAngles = leftUp;

            playerGoal = GameObject.Find("WindowTL");
            peeDirection = (playerGoal.transform.position - transform.position);
        }


        //TR Right Input
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") >0 )
        {
            transform.eulerAngles = rightUp;
            playerGoal = GameObject.Find("WindowTR");
            peeDirection = (playerGoal.transform.position - transform.position);
        }

        //BLeft INput
        if (Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0)
        {

            transform.eulerAngles = leftDown;
            playerGoal = GameObject.Find("WindowBL");
            peeDirection = (playerGoal.transform.position - transform.position);
        }

        //BR Right Input
        if (Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0)
        {
            transform.eulerAngles = rightDown;
            playerGoal = GameObject.Find("WindowBR");
            peeDirection = (playerGoal.transform.position - transform.position);
        }


        //PEE INput
        if (Input.GetButton("Jump"))
        {
            if (!IsInvoking("SpawnPeeWithForce"))
                //InvokeRepeating("SpawnPeeWithForce", Random.Range(.2f, .3f), Random.Range(0, .05f));
                InvokeRepeating("SpawnPeeWithForce", 0, 0.03f);
        }
        else
        {
            CancelInvoke();
        }


        


    }

    void SpawnPeeWithForce()
    {

        Transform t = this.transform;

        //force vector
        Vector3 peeVec =
            t.position +
            t.forward * 2000 +
            (t.right * Random.Range(-peeSpread, peeSpread)) +
            (t.up * Random.Range(-peeSpread, peeSpread));

        Vector3 peeOrig = t.position + t.forward * 0.5f + t.right; //position of spawn

        spawnedPee = Instantiate(peeObject, peeOrig, Quaternion.identity);
        Destroy(spawnedPee, killDelay); // remove after a set amount

        float mass = spawnedPee.GetComponent<Rigidbody>().mass;
        spawnedPee.GetComponent<Rigidbody>().AddForce(peeVec * mass);
    }
}
    
