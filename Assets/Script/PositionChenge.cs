using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionChange : MonoBehaviour
{
    public int count1;
    public int count2;
    public int count3;
    public int count4;
    public int count5;
    public int count6;
    public int count7;
    public GameObject[] movingObjects; // �����I�u�W�F�N�g�̔z��
    public GameObject objectToGenerate; // ��������I�u�W�F�N�g�̃v���n�u
    public Vector3 generationOffset = new Vector3(0, 0, 0); // �����ʒu�̃I�t�Z�b�g

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        int totalCount = count1 + count2 + count3 + count4 + count5 + count6 + count7;

    }
}
