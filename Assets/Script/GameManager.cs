using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score;
    private Text scoreText;
    private Text timer;
    public float countdownTime = 90f;
    private float currentTime;
    private Text timeUp;
    public bool timeStop=false;
    public AudioSource bgmAudio;
    private GameObject count;
    private AudioSource countAudio;
    private float nextPlayTime;

    // Start is called before the first frame update
    void Start()
    {
        scoreText =GameObject.Find("ScoreText").GetComponent<Text>();
        timer = GameObject.Find("Timer").GetComponent<Text>();
        timeUp= GameObject.Find("TimeUp").GetComponent<Text>();
        currentTime = countdownTime;
        nextPlayTime = Time.time + 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(!timeStop)
        {
            scoreText.text = "Score:" + score;
            currentTime -= Time.deltaTime;
            if (currentTime <= 0)
            {
                currentTime = 0; // 0未満にならないようにする
                                 // カウントダウン終了時の処理
                timeStop = true;
                Debug.Log("カウントダウン終了！");
                bgmAudio.Stop();
                timeUp.text = "TIME UP\nScore:"+score;
            }
            if (currentTime <= 11f && currentTime > 1f)
            {
                if (Time.time >= nextPlayTime)
                {
                    count = GameObject.Find("CountBGM");
                    countAudio = count.GetComponent<AudioSource>();
                    countAudio.Play();
                    nextPlayTime = Time.time + 1f;
                }
            }
           if (currentTime <= 1f && currentTime > 0f)
            {
                if (Time.time >= nextPlayTime)
                {
                    count = GameObject.Find("LastBGM");
                    countAudio = count.GetComponent<AudioSource>();
                    countAudio.Play();
                    nextPlayTime = Time.time + 1f;
                }
            }
            float seconds = currentTime;

            timer.text = "残り時間：" + Mathf.FloorToInt(currentTime).ToString() + "秒"; // 秒数のみ表示

        }
        
    }
}

