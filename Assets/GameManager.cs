using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    Opening, Game, Clear
}

public class GameManager : MonoBehaviour
{
    // オブジェクト
    private GameObject ball;
    private GameObject winnerMessage;
    private GameObject continueMessage;

    // UI
    private Button btnMain;

    // ゲーム管理情報
    private GameState state;
    private int scoreA;
    private int scoreB;
    private float speed = 0.3f;
    private float difficulty = 1.0f;

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
    }

    void Opening()
    {

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
        winnerMessage = GameObject.Find("Winner");
        continueMessage = GameObject.Find("Message");
        btnMain = GameObject.Find("BtnMain").GetComponent<Button>();
    }

    void OpeningInitialize()
    {
        state = GameState.Opening;
        ball.GetComponent<Renderer>().enabled = false;
        winnerMessage.GetComponent<Text>().enabled = false;
        continueMessage.GetComponent<Text>().enabled = false;
        btnMain.enabled = true;
    }

    void GameInitialize()
    {
        state = GameState.Game;
        scoreA = 0;
        scoreB = 0;
    }

    public void InputUIButton(string btnName)
    {
        switch(btnName){
            case "BtnUpA":
                break;
            case "BtnDownA":
                break;
            case "BtnUpB":
                break;
            case "BtnDownB":
                break;
            case "BtnMain":
                if(state==GameState.Opening);
                else if(state==GameState.Clear);
                break;
        }
    }
}
