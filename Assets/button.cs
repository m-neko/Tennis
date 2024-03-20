using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class button : MonoBehaviour
{

    private GameManager manager;

    // Start is called before the first frame update
    void Start()
    {
        manager = GameObject.Find("Frame").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click(){

        manager.InputUIButton(this.name);
        
        /*GameObject barA = GameObject.Find("PlayerA");
        GameObject barB = GameObject.Find("PlayerB");
        ball cball = GameObject.Find("Ball").GetComponent<ball>();
        GameState state = cball.state;

        // ボタンが押された時にバーを移動させる
        if(state == GameState.Game){
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
            }             
        }
        if(state == GameState.Clear && this.name == "BtnMain"){
            GameObject.Find("Ball").GetComponent<ball>().GameInitialize();
        }
        if(state == GameState.Opening){
            if((this.name=="BtnUpA" || this.name=="BtnUpB") && cball.difficulty > 1.0f){
                cball.difficulty -= 1.0f;
                GameObject.Find("Cursor").transform.position += new Vector3(0,1,0);
            }
            if((this.name=="BtnDownA" || this.name=="BtnDownB") && cball.difficulty < 3.0f){
                cball.difficulty += 1.0f;
                GameObject.Find("Cursor").transform.position += new Vector3(0,-1,0);
            }
            if(this.name=="BtnMain"){
                GameObject.Find("Opening").SetActive(false);
                GameObject.Find("Ball").GetComponent<ball>().GameInitialize();
            }
        } */     

    }
}
