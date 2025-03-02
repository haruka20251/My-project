using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCloud : MonoBehaviour
{
    private float speed;
    private float randomRangeZ1 = 3;//â_1ÇÃZé≤ê∂ê¨îÕàÕ
    private float randomRangeZ2 = 4;//â_2ÇÃZé≤ê∂ê¨îÕàÕ
    //private float xPos;//Xé≤ÇÃå≈íËíl
    private float randomRangeY=1;//Yé≤ê∂ê¨îÕàÕ
    private Transform targetPosC1;//â_1
    private Transform targetPosC2;//â_2
    private Vector3 initialPosC1;//â_1ÇÃèâä˙íl
    private Vector3 initialPosC2;//â_2ÇÃèâä˙íl
    public GameObject world;


    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.5f, 1.0f);
        targetPosC1=GameObject.Find("cloud_1").GetComponent<Transform>();
        targetPosC2 = GameObject.Find("cloud_2").GetComponent<Transform>();
        initialPosC1 = targetPosC1.position;
        initialPosC2 = targetPosC2.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left*speed*Time.deltaTime,Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();
        

        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "cloud1"))
        {
            float xPos = initialPosC1.x + 8f;
            float randomZ = initialPosC1.z + Random.Range(-randomRangeZ1, randomRangeZ1);
            float randomY= initialPosC1.y + Random.Range(-randomRangeY, randomRangeY);
            this.gameObject.transform.position = new Vector3(xPos, randomY, randomZ);
            this.gameObject.transform.localScale = world.transform.localScale;
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "cloud2"))
        {
            float xPos = initialPosC2.x + 8f;
            float randomZ = initialPosC2.z + Random.Range(-randomRangeZ2, randomRangeZ2);
            float randomY = initialPosC2.y + Random.Range(-randomRangeY, randomRangeY);
            this.gameObject.transform.position = new Vector3(xPos, randomY, randomZ);
            this.gameObject.transform.localScale = world.transform.localScale;
        }

    }
    void SetRandomSpeed()
    {
        speed = Random.Range(0.8f, 1.0f);
    }
}
