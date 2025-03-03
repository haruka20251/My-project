using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : MonoBehaviour
{
    public float speed;
    private Transform targetPosR1;//右車1
    private Transform targetPosR2;//右車1
    private Transform targetPosR3;//右船1
    private Transform targetPosR4;//飛行機
    //public GameObject positionChange;
    //public Randomchest3 positionChangeScript;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.8f, 1.0f);
        targetPosR1 = GameObject.Find("LineR1").GetComponent<Transform>();//右車1
        targetPosR2 = GameObject.Find("LineR2").GetComponent<Transform>();//右車1
        targetPosR3 = GameObject.Find("LineR3").GetComponent<Transform>();//右船1
        targetPosR4 = GameObject.Find("LineR4").GetComponent<Transform>();//飛行機
        //positionChange = GameObject.Find("TreasureChestControl");
        //positionChangeScript = GetComponent<Randomchest3>();

    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();

        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "carR1"))
        {
            this.gameObject.transform.position = targetPosR1.position;
           //positionChangeScript.count5++;
        }

        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "carR2"))
        {
            this.gameObject.transform.position = targetPosR2.position;
           //positionChangeScript.count6++;
        }
        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "boatR1"))
        {
            this.gameObject.transform.position = targetPosR3.position;
           //positionChangeScript.count7++;
        }
        if ((other.gameObject.tag == "RightLine") && (this.gameObject.tag == "plane1"))
        {
            this.gameObject.transform.position = targetPosR4.position;
        }
    }
    void SetRandomSpeed()
    {
        speed = Random.Range(0.8f, 1.0f);
    }
}
