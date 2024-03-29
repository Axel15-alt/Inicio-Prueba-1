using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Vertical") != 0) 
        {
            transform.Translate(transform.forward * Input.GetAxis("Vertical") * Time.deltaTime * 4);
        }

        if (Input.GetAxis("Horizontal") != 0) 
        { 
            transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * 50 * Time.deltaTime);
        }
    }
}
