using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveClouds : MonoBehaviour
{
    private GameObject areac;
    private float speed;
    public GameObject world;
    private GameObject cloud1;
    private GameObject cloud2;

    // Start is called before the first frame update
    void Start()
    {
        speed = Random.Range(0.8f, 1.0f);
        cloud1 = GameObject.Find("cloud_1");
        cloud2 = GameObject.Find("cloud_2");
        areac = GameObject.Find("CloudLine");
    }


    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);

    }
    private void OnTriggerEnter(Collider other)
    {
        SetRandomSpeed();
        if ((other.gameObject.tag == "LeftLine") &&(this.gameObject.tag == "cloud1"))
        {
            Vector3 randomPosition = GetRandomPositionInArea(areac);
            cloud1.transform.position = randomPosition;
        }
        if ((other.gameObject.tag == "LeftLine") && (this.gameObject.tag == "cloud2"))
        {
            Vector3 randomPosition = GetRandomPositionInArea(areac);
            cloud2.transform.position = randomPosition;
        }
    }
    void SetRandomSpeed()
    {
        speed = Random.Range(0.8f, 1.0f);
    }
    Vector3 GetRandomPositionInArea(GameObject areac)
    {
        // エリアのColliderの範囲内でランダムな位置を生成
        Collider areaCollider = areac.GetComponent<Collider>();
        Vector3 minBounds = areaCollider.bounds.min;
        Vector3 maxBounds = areaCollider.bounds.max;
        return new Vector3(Random.Range(minBounds.x, maxBounds.x), Random.Range(minBounds.y, maxBounds.y), Random.Range(minBounds.z, maxBounds.z));
    }

}
