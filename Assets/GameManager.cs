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

    // UI
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

    void Opening()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow)) SelectDifficulty(KeyCode.UpArrow);
        if(Input.GetKeyDown(KeyCode.DownArrow)) SelectDifficulty(KeyCode.DownArrow);
        if(Input.GetKeyDown(KeyCode.Return)) GameInitialize();
    }

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

    void Game()
    {

    }

    void Clear()
    {

    }

    void Initialize()
    {
        ball = GameObject.Find("Ball");
        winnerMessage = GameObject.Find("Winner").GetComponent<Text>();
        continueMessage = GameObject.Find("Message").GetComponent<Text>();
        btnMain = GameObject.Find("BtnMain").GetComponent<Button>();
    }

    void OpeningInitialize()
    {
        state = GameState.Opening;
        difficulty = GameDifficulty.Easy;
        ball.GetComponent<Renderer>().enabled = false;
        winnerMessage.enabled = false;
        continueMessage.enabled = false;
        btnMain.enabled = true;
    }

    void GameInitialize()
    {
        state = GameState.Game;
        scoreA = 0;
        scoreB = 0;
        speed = 0.3f * (int)difficulty;
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
                break;
            case "BtnDownA":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.DownArrow);
                break;
            case "BtnUpB":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.UpArrow);
                break;
            case "BtnDownB":
                if(state==GameState.Opening) SelectDifficulty(KeyCode.DownArrow);
                break;
            case "BtnMain":
                if(state==GameState.Opening) GameInitialize();
                if(state==GameState.Clear);
                break;
        }
    }
}
