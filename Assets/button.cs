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
    }
}
