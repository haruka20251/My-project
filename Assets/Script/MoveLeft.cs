using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private float speed;
    private Transform targetPosition1;//船1
    private Transform targetPosition2;//船2
    private Transform targetPosition3;//車1
    private Transform targetPosition4;//車2
    private GameObject positionChange;
    private PositionChange positionChangeScript;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1.0f);
        targetPosition1 = GameObject.Find("Line").GetComponent<Transform>();//船1
        targetPosition2 = GameObject.Find("Line2").GetComponent<Transform>();//船2
        targetPosition3 =GameObject.Find("Line3"). GetComponent<Transform>();//車1
        targetPosition4 = GameObject.Find("Line4").GetComponent<Transform>();//車2
        positionChange = GameObject.Find("PositionCount");
        

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();

        if ((other.gameObject.tag == "LeftLine")&&(this.gameObject.tag=="boat1"))
        {
            this.gameObject.transform.position= targetPosition1.position;
           // positionChangeScript.count1++;

        }

        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "boat2"))
        {
            this.gameObject.transform.position = targetPosition2.position;
            //positionChangeScript.count2++;
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "car1"))
        {
            this.gameObject.transform.position = targetPosition3.position;
            //positionChangeScript.count3++;
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "car2"))
        {
            this.gameObject.transform.position = targetPosition4.position;
            //positionChangeScript.count4++;
        }
    }
     void SetRandomSpeed()
     {
        speed = Random.Range(0.8f, 1.0f);
    }
}
