using System.Collections;
using UnityEngine;

public class ball : MonoBehaviour
{
    private int scoreA = 0;
    private int scoreB = 0;
    private bool clear = false;

    // Start is called before the first frame update
    void Start()
    {
        GameInitialize();
    }

    void GameInitialize(){
        scoreA = 0;
        scoreB = 0;
        clear = false;
        GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("ScoreA").GetComponent<UnityEngine.UI.Text>().text = scoreA.ToString();
        GameObject.Find("ScoreB").GetComponent<UnityEngine.UI.Text>().text = scoreB.ToString();
        GetComponent<Renderer>().enabled = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 10);
    }

    // Update is called once per frame
    void Update()
    {
        // ゲームクリア画面でエンターキーを押したら再プレイ
        if(clear && Input.GetKey(KeyCode.Return)){
            GameInitialize();
        }
        // ESCで終了
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    void GameClear(){
        clear = true;
        GameObject.Find("SoundWin").GetComponent<AudioSource>().Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = true;
        GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = true;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // ボールがラケットに当たったら音を鳴らす
        if(other.gameObject.name == "PlayerA" || other.gameObject.name == "PlayerB")
        {
            GameObject.Find("SoundBall").GetComponent<AudioSource>().Play();
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // ボールがゴールに入ったら初期位置に戻す
        GameObject.Find("SoundBeep").GetComponent<AudioSource>().Play();
        StartCoroutine(BallInit(other.name));
    }

    IEnumerator BallInit(string name)
    {
        yield return new WaitForSeconds(2);
        transform.position = new Vector3(0, 4, 0);
       if(name == "GoalLeft")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(10, 10);
            scoreB += 10;
            GameObject.Find("ScoreB").GetComponent<UnityEngine.UI.Text>().text = scoreB.ToString();
        }
        else if(name == "GoalRight")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10, 10);
            scoreA += 10;
            GameObject.Find("ScoreA").GetComponent<UnityEngine.UI.Text>().text = scoreA.ToString();
        }

        // 先に100点を取った方が勝ち
        if(scoreA >= 100)
        {
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = "Player A Win!";
            GameClear();
        }
        else if(scoreB >= 100)
        {
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = "Player B Win!";
            GameClear();

        }
    }

}
