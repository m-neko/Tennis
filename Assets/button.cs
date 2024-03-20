using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){
        
        GameObject barA = GameObject.Find("PlayerA");
        GameObject barB = GameObject.Find("PlayerB");

        // ボタンが押された時にバーを移動させる
        switch(this.name){
            case "BtnUpA":
                if(barA.transform.position.y < 4.5f){
                    barA.transform.position += new Vector3(0, 1.0f, 0);
                }
                break;
            case "BtnDownA":
                if(barA.transform.position.y > -4.5f){
                    barA.transform.position -= new Vector3(0, 1.0f, 0);
                }
                break;
            case "BtnUpB":
                if(barB.transform.position.y < 4.5f){
                    barB.transform.position += new Vector3(0, 1.0f, 0);
                }
                break;
            case "BtnDownB":
                if(barB.transform.position.y > -4.5f){
                    barB.transform.position -= new Vector3(0, 1.0f, 0);
                }
                break;
            case "BtnMain":
                GameObject.Find("Ball").GetComponent<ball>().GameInitialize();
                break;
        }
    }
}
