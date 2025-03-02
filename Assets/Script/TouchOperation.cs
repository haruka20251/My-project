using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOperation : MonoBehaviour
{
    public GameObject generateScript; // RandomCoinスクリプトがアタッチされたGameObject
    private int initialCoinCount; // 最初に生成されたコインの数
    private int coinLayerMask;// Coinレイヤーマスク
    private GameManager gameManager;
    private GameObject coin;
    private AudioSource coinSound;
    private GameObject chest;
    private AudioSource chestAudio;

    void Start()
    {
        gameManager =GameObject.Find("GameManager"). GetComponent<GameManager>();
        
        // コインを生成
        GenerateCoins();

        // 最初に生成されたコインの数を保存
        initialCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        coinLayerMask = LayerMask.GetMask("Coin");
    }

    void Update()
    {
        if (!gameManager.timeStop)
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("Touch detected."); // 追加

                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Raycastにレイヤーマスクを適用
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, coinLayerMask))
                {
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name); // 追加
                    if (hit.collider.gameObject.tag == "Coin")
                    {
                        Debug.Log("Coin tag detected."); // 追加

                        if (!gameManager.timeStop) // timeStop の確認
                        {
                            gameManager.score++;
                        }
                        coin = GameObject.Find("CoinBGM");
                        coinSound = coin.GetComponent<AudioSource>();
                        coinSound.Play();
                        
                        Destroy(hit.collider.gameObject);
                        StartCoroutine(RegenerateAfterDelay());
                    }
                    IEnumerator RegenerateAfterDelay()
                    {
                        yield return null; // 1フレーム待機
                                           // コインがすべて消えたら再生成
                        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
                        {
                            Debug.Log("No coins left."); // 追加
                            GenerateCoins();
                        }
                    }
                    if (hit.collider.gameObject.tag == "Chest")
                    {
                        Debug.Log("Chest tag detected."); // 追加
                        if (!gameManager.timeStop) // timeStop の確認
                        {
                            gameManager.score += 5;
                        }
                        chest = GameObject.Find("ChestBGM");
                        chestAudio = chest.GetComponent<AudioSource>();
                        chestAudio.Play();

                        Destroy(hit.collider.gameObject);
                        StartCoroutine(RegenerateAfterDelay());
                    }
                }
            }
        }
    }

    void GenerateCoins()
    {
        // RandomCoinスクリプトを取得
        RandomCoin script1 = generateScript.GetComponent<RandomCoin>();

        // RandomCoinスクリプトが存在する場合
        if (script1 != null)
        {
            Debug.Log("Reset specificAreaGenerated");
            script1.specificAreaGenerated = false;
            // コインを生成
            script1.PlaceObjects();
        }
        else
        {
            Debug.LogError("GenerateScriptが見つかりません。");
        }
    }
}
