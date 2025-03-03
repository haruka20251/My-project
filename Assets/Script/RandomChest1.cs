using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class RandomChest1 : MonoBehaviour
{
    public GameObject[] movingObjects;
    public GameObject objectToGenerate;
    public float generationDelay = 35f;
    public GameObject world;
    public GameObject area6;
    public Vector3 generationOffset = new Vector3(0, 0, 0);

    private float startTime;

    void Start()
    {
        startTime = Time.time; // Time.time を使用
    }

    void Update()
    {
        if (Time.time - startTime >= generationDelay) // Time.time を使用
        {
            if (CheckMovingObjectsPosition())
            {
                GenerateObject();
                startTime = Time.time; // Time.time を使用してリセット
                Debug.Log("生成した！" + transform.position);
            }
        }
    }

    bool CheckMovingObjectsPosition()
    {
        foreach (GameObject obj in movingObjects)
        {
            Vector3 localPosition = area6.transform.InverseTransformPoint(obj.transform.position);
            if (localPosition.x >= -5f && localPosition.x <= 5f && localPosition.y >= -5.0f && localPosition.y <= 5.0f)
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
        GameObject generatedObject = Instantiate(objectToGenerate, spawnPosition + selectedObject.transform.up * 0.2f, Quaternion.identity, world.transform);
        generatedObject.transform.SetParent(selectedObject.transform);
    }
}
