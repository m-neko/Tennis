using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Dependencies.Sqlite;
using UnityEngine;

public class ball : MonoBehaviour
{
    private int scoreA = 0;
    private int scoreB = 0;
    private bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 10);
        GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(clear){
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = true;
            GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = true;
            if(Input.GetKey(KeyCode.Return))
            {
                scoreA = 0;
                scoreB = 0;
                clear = false;
                GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = false;
                GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = false;
                GameObject.Find("ScoreA").GetComponent<UnityEngine.UI.Text>().text = scoreA.ToString();
                GameObject.Find("ScoreB").GetComponent<UnityEngine.UI.Text>().text = scoreB.ToString();
                this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 10);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        StartCoroutine(BallInit(other.name));
    }

    IEnumerator BallInit(string name)
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(0, 4, 0);
       if(name == "Square (2)")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(10, 10);
            scoreB += 10;
            GameObject.Find("ScoreB").GetComponent<UnityEngine.UI.Text>().text = scoreB.ToString();
        }
        else if(name == "Square (3)")
        {
            this.GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 10);
            scoreA += 10;
            GameObject.Find("ScoreA").GetComponent<UnityEngine.UI.Text>().text = scoreA.ToString();
        }
        // 先に100点を取った方が勝ち
        if(scoreA >= 100)
        {
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = "Player A Win!";
            clear = true;
        }
        else if(scoreB >= 100)
        {
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = "Player B Win!";
            clear = true;
        }
    }

}
