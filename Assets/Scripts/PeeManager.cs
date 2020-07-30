using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeeManager : MonoBehaviour

{
    public int Score = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Score);
    }

    /*  void OnCollisionEnter(Collision collision)
      {
          Debug.Log("Collided with " + collision.gameObject);
          if (collision.gameObject.tag == "CurWindow")
          {
              Score++;

              // Destroy(gameObject);


          }
      }
      */
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collided with " + other.gameObject);
        if (other.gameObject.tag == "CurWindow")
        {
            Score++;
        }
    }

}
