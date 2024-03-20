using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ball : MonoBehaviour
{
    private int scoreA = 0;
    private int scoreB = 0;
    //public GameState state = GameState.Opening;

    private float speed = 0.3f;
    public float difficulty = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        //Opening();
    }

    public void Opening(){
        //state = GameState.Opening;
        GetComponent<Renderer>().enabled = false;
        GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("BtnMain").GetComponent<UnityEngine.UI.Button>().enabled = true;
    }

    public void GameInitialize(){ 
        scoreA = 0;
        scoreB = 0;
        speed = 0.3f * difficulty;
        //state = GameState.Game;
        GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = false;
        GameObject.Find("BtnMain").GetComponent<UnityEngine.UI.Button>().enabled = false;
        GameObject.Find("ScoreA").GetComponent<UnityEngine.UI.Text>().text = scoreA.ToString();
        GameObject.Find("ScoreB").GetComponent<UnityEngine.UI.Text>().text = scoreB.ToString();
        GetComponent<Renderer>().enabled = true;
        GetComponent<Rigidbody2D>().velocity = new Vector2(-10*speed, 10*speed);
    }

    // Update is called once per frame
    void Update()
    {
        /*
        // ゲームクリア画面でエンターキーを押したら再プレイ
        if(state == GameState.Clear && Input.GetKey(KeyCode.Return)){
            GameInitialize();
        }
        // オープニング画面での難易度選択
        if(state == GameState.Opening){
            if(Input.GetKeyDown(KeyCode.UpArrow) && difficulty > 1.0f){
                difficulty -= 1.0f;
                GameObject.Find("Cursor").transform.position += new Vector3(0,1,0);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) && difficulty < 3.0f){
                difficulty += 1.0f;
                GameObject.Find("Cursor").transform.position += new Vector3(0,-1,0);
            } 
            if(Input.GetKeyDown(KeyCode.Return)){
                GameObject.Find("Opening").SetActive(false);
                GameInitialize();
            }
        }

        // ESCで終了
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
        */
    }

    void GameClear(){
        //state = GameState.Clear;
        GameObject.Find("SoundWin").GetComponent<AudioSource>().Play();
        GetComponent<Renderer>().enabled = false;
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().enabled = true;
        GameObject.Find("Message").GetComponent<UnityEngine.UI.Text>().enabled = true;
        GameObject.Find("BtnMain").GetComponent<UnityEngine.UI.Button>().enabled = true;
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
            GetComponent<Rigidbody2D>().velocity = new Vector2(10*speed, 10*speed);
            scoreB += 10;
            GameObject.Find("ScoreB").GetComponent<UnityEngine.UI.Text>().text = scoreB.ToString();
        }
        else if(name == "GoalRight")
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(-10*speed, 10*speed);
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
