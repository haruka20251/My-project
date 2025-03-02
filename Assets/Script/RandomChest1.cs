using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class RandomChest1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] movingObjects; // 動くオブジェクトの配列
    public GameObject objectToGenerate; // 生成するオブジェクトのプレハブ
    public float generationDelay = 40f; // 生成までの遅延時間
    public Vector3 generationOffset = new Vector3(0, 0, 0); // 生成位置のオフセット
    public GameObject world;

    private float startTime;
   
    // Start is called before the first frame update
    void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        if ((Time.time - startTime >= generationDelay)&&( Time.time - startTime <= generationDelay+1.5f))
        {
            // 特定の位置に到達したかどうかの判定
            if (CheckMovingObjectsPosition())
            {
                GenerateObject();
                startTime = Time.time;
                Debug.Log("生成した！" + Time.time);
            }
        }
    }
    bool CheckMovingObjectsPosition()
    {
        foreach (GameObject obj in movingObjects)
        {
            // 特定の位置に到達したかどうかの判定ロジックを実装
            if (obj.transform.localPosition.x >= -85f && obj.transform.localPosition.x <= -22f)
            {
                return true;
            }
        }
        return false;
    }
    void GenerateObject()
    {
        int randomIndex = Random.Range(0, movingObjects.Length);
        GameObject selectedObject = movingObjects[randomIndex];

        Vector3 spawnPosition = selectedObject.transform.position + generationOffset;
        GameObject generatedObject = Instantiate(objectToGenerate, spawnPosition+Vector3.up*1.3f, Quaternion.identity);
        generatedObject.transform.SetParent(selectedObject.transform); // 動くオブジェクトの子にする
        
    }
}

