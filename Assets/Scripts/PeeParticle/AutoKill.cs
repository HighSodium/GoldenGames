using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoKill : MonoBehaviour
{
    // Start is called before the first frame update
    
    [Tooltip("Seconds before auto-delete.")]
    public float destroyDelay = 3;

    void Start()
    {
        Destroy(gameObject, destroyDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
