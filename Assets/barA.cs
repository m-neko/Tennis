using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class barA : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        /*if(Input.GetKey(KeyCode.Q) && transform.position.y < 4.5f){
            transform.position += new Vector3(0, 15.0f*Time.deltaTime, 0);
        }
        if(Input.GetKey(KeyCode.Z) && transform.position.y > -4.5f){
            transform.position += new Vector3(0, -15.0f*Time.deltaTime, 0);
        }*/

        float y = GameObject.Find("SliderA").GetComponent<UnityEngine.UI.Slider>().value;
        transform.position = new Vector3(transform.position.x,y,transform.position.z);

    }
}
