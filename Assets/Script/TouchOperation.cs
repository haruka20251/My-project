using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchOperation : MonoBehaviour
{
    public GameObject generateScript; // RandomCoin�X�N���v�g���A�^�b�`���ꂽGameObject
    private int initialCoinCount; // �ŏ��ɐ������ꂽ�R�C���̐�
    private int coinLayerMask;// Coin���C���[�}�X�N
    private GameManager gameManager;
    private GameObject coin;
    private AudioSource coinSound;
    private GameObject chest;
    private AudioSource chestAudio;

    void Start()
    {
        gameManager =GameObject.Find("GameManager"). GetComponent<GameManager>();
        
        // �R�C���𐶐�
        GenerateCoins();

        // �ŏ��ɐ������ꂽ�R�C���̐���ۑ�
        initialCoinCount = GameObject.FindGameObjectsWithTag("Coin").Length;
        coinLayerMask = LayerMask.GetMask("Coin");
    }

    void Update()
    {
        if (!gameManager.timeStop)
        {
            if (Input.touchCount > 0)
            {
                Debug.Log("Touch detected."); // �ǉ�

                Touch touch = Input.GetTouch(0);
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                // Raycast�Ƀ��C���[�}�X�N��K�p
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, coinLayerMask))
                {
                    Debug.Log("Raycast hit: " + hit.collider.gameObject.name); // �ǉ�
                    if (hit.collider.gameObject.tag == "Coin")
                    {
                        Debug.Log("Coin tag detected."); // �ǉ�

                        if (!gameManager.timeStop) // timeStop �̊m�F
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
                        yield return null; // 1�t���[���ҋ@
                                           // �R�C�������ׂď�������Đ���
                        if (GameObject.FindGameObjectsWithTag("Coin").Length == 0)
                        {
                            Debug.Log("No coins left."); // �ǉ�
                            GenerateCoins();
                        }
                    }
                    if (hit.collider.gameObject.tag == "Chest")
                    {
                        Debug.Log("Chest tag detected."); // �ǉ�
                        if (!gameManager.timeStop) // timeStop �̊m�F
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
        // RandomCoin�X�N���v�g���擾
        RandomCoin script1 = generateScript.GetComponent<RandomCoin>();

        // RandomCoin�X�N���v�g�����݂���ꍇ
        if (script1 != null)
        {
            Debug.Log("Reset specificAreaGenerated");
            script1.specificAreaGenerated = false;
            // �R�C���𐶐�
            script1.PlaceObjects();
        }
        else
        {
            Debug.LogError("GenerateScript��������܂���B");
        }
    }
}
