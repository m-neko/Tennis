using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

enum GameState
{
    Opening, Game, Clear
}

enum GameDifficulty{
    Easy = 1, Normal = 2, Difficult = 3
}

public class GameManager : MonoBehaviour
{
    // オブジェクト
    private GameObject ball;
    private GameObject playerA;
    private GameObject playerB;

    // UI
    private Text txtScoreA;
    private Text txtScoreB;
    private Text winnerMessage;
    private Text continueMessage;
    private Button btnMain;

    // ゲーム管理情報
    private GameState state;
    private int scoreA;
    private int scoreB;
    private float speed;
    private GameDifficulty difficulty;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        OpeningInitialize();
    }

    // Update is called once per frame
    void Update()
    {
        switch(state){
            case GameState.Opening:
                Opening();
                break;
            case GameState.Game:
                Game();
                break;
            case GameState.Clear:
                Clear();
                break;
        }
        if(Input.GetKeyDown(KeyCode.Escape)){
            Application.Quit();
        }
    }

    // オープニング画面の処理
    void Opening()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) SelectDifficulty(KeyCode.UpArrow);
        if(Input.GetKeyDown(KeyCode.DownArrow)) SelectDifficulty(KeyCode.DownArrow);
        if(Input.GetKeyDown(KeyCode.Return)) GameInitialize();
    }

    // 難易度の選択
    void SelectDifficulty(KeyCode key)
    {
        switch(key){
            case KeyCode.UpArrow:
                if(difficulty > GameDifficulty.Easy){
                    difficulty--;
                    GameObject.Find("Cursor").transform.position += new Vector3(0,1,0);
                }
                break;
            case KeyCode.DownArrow:
                if(difficulty < GameDifficulty.Difficult){
                    difficulty++;
                    GameObject.Find("Cursor").transform.position += new Vector3(0,-1,0);
                }
                break;
        }
    }

    // ゲーム中の処理
    void Game()
    {
        if(Input.GetKeyDown(KeyCode.Q)) MovePlayer(KeyCode.Q);
        if(Input.GetKeyDown(KeyCode.Z)) MovePlayer(KeyCode.Z);
        if(Input.GetKeyDown(KeyCode.O)) MovePlayer(KeyCode.O);
        if(Input.GetKeyDown(KeyCode.M)) MovePlayer(KeyCode.M);
    }

    // ラケットの移動
    void MovePlayer(KeyCode key)
    {
        switch(key){
            case KeyCode.Q:
                if(playerA.transform.position.y < 4.5f)
                    playerA.transform.position += new Vector3(0, 1.0f, 0);
                break;
            case KeyCode.Z:
                if(playerA.transform.position.y > -4.5f)
                    playerA.transform.position += new Vector3(0, -1.0f, 0);
                break;
            case KeyCode.O:
                if(playerB.transform.position.y < 4.5f)
                    playerB.transform.position += new Vector3(0, 1.0f, 0);
                break;
            case KeyCode.M:
                if(playerB.transform.position.y > -4.5f)
                    playerB.transform.position += new Vector3(0, -1.0f, 0);
                break;
        }
    }

    // ゲームクリア時の処理
    void Clear()
    {

    }

    // 初期化
    void Initialize()
    {
        ball = GameObject.Find("Ball");
        playerA = GameObject.Find("PlayerA");
        playerB = GameObject.Find("PlayerB");
        txtScoreA = GameObject.Find("ScoreA").GetComponent<Text>();
        txtScoreB = GameObject.Find("ScoreB").GetComponent<Text>();
        winnerMessage = GameObject.Find("Winner").GetComponent<Text>();
        continueMessage = GameObject.Find("Message").GetComponent<Text>();
        btnMain = GameObject.Find("BtnMain").GetComponent<Button>();
    }

    // オープニング画面の初期化
    void OpeningInitialize()
    {
        state = GameState.Opening;
        difficulty = GameDifficulty.Easy;
        ball.GetComponent<Renderer>().enabled = false;
        winnerMessage.enabled = false;
        continueMessage.enabled = false;
        btnMain.enabled = true;
    }

    // ゲーム開始時の初期化
    void GameInitialize()
    {
        state = GameState.Game;
        scoreA = 0;
        scoreB = 0;
        speed = 3.0f * (int)difficulty;
        ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
        GameObject.Find("Canvas").transform.Find("Opening").gameObject.SetActive(false);
        ball.GetComponent<Renderer>().enabled = true;
        winnerMessage.enabled = false;
        continueMessage.enabled = false;
        btnMain.enabled = false;
    }

    // UIボタン処理(入力があるとボタン側から呼び出される)
    public void InputUIButton(string btnName)
    {
        switch(btnName){
            case "BtnUpA":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.UpArrow);
                if(state==GameState.Game) MovePlayer(KeyCode.Q);
                break;
            case "BtnDownA":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.DownArrow);
                if(state==GameState.Game) MovePlayer(KeyCode.Z);
                break;
            case "BtnUpB":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.UpArrow);
                if(state==GameState.Game) MovePlayer(KeyCode.O);
                break;
            case "BtnDownB":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.DownArrow);
                if(state==GameState.Game) MovePlayer(KeyCode.M);
                break;
            case "BtnMain":
                if(state==GameState.Opening) GameInitialize();
                if(state==GameState.Clear);
                break;
        }
    }

    // ゴール処理
    public void Goal(string name)
    {
        StartCoroutine(BallInit(name));
    }

    // ゴール後時間をおいてからゲームを再開する
    IEnumerator BallInit(string name)
    {
        yield return new WaitForSeconds(2);
        ball.transform.position = new Vector3(0, 4, 0);
       if(name == "GoalLeft")
        {
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, speed);
            scoreB += 10;
            txtScoreB.text = scoreB.ToString();
        }
        else if(name == "GoalRight")
        {
            ball.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, speed);
            scoreA += 10;
            txtScoreA.text = scoreA.ToString();
        }

        // 先に100点を取った方が勝ち
        /*if(scoreA >= 100)
        {
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = "Player A Win!";
            GameClear();
        }
        else if(scoreB >= 100)
        {
            GameObject.Find("Winner").GetComponent<UnityEngine.UI.Text>().text = "Player B Win!";
            GameClear();

        }*/
    }

}
