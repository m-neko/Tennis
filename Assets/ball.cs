using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class ball : MonoBehaviour
{

    private GameManager manager;

    void Start()
    {
        manager = GameObject.Find("Frame").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {

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
        // ボールがゴールに入ったことをGameManagerに通知する
        GameObject.Find("SoundBeep").GetComponent<AudioSource>().Play();
        manager.Goal(other.name);
    }

}
