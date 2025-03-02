using System.Collections;
using System.Collections.Generic;
//using Unity.VisualScripting;
using UnityEngine;

public class RandomChest1 : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] movingObjects; // �����I�u�W�F�N�g�̔z��
    public GameObject objectToGenerate; // ��������I�u�W�F�N�g�̃v���n�u
    public float generationDelay = 40f; // �����܂ł̒x������
    public Vector3 generationOffset = new Vector3(0, 0, 0); // �����ʒu�̃I�t�Z�b�g
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
            // ����̈ʒu�ɓ��B�������ǂ����̔���
            if (CheckMovingObjectsPosition())
            {
                GenerateObject();
                startTime = Time.time;
                Debug.Log("���������I" + Time.time);
            }
        }
    }
    bool CheckMovingObjectsPosition()
    {
        foreach (GameObject obj in movingObjects)
        {
            // ����̈ʒu�ɓ��B�������ǂ����̔��胍�W�b�N������
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
        generatedObject.transform.SetParent(selectedObject.transform); // �����I�u�W�F�N�g�̎q�ɂ���
        
    }
}

