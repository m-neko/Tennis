using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarB : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKey(KeyCode.O) && transform.position.y < 4.5f){
            transform.position += new Vector3(0, 15.0f*Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.M) && transform.position.y > -4.5f){
            transform.position += new Vector3(0, -15.0f*Time.deltaTime, 0);
        }       
    }
}
