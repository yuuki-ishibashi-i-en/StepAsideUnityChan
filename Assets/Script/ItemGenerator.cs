using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGenerator : MonoBehaviour
{
    public GameObject carPrefab;

    public GameObject coinPrefab;

    public GameObject conePrefab;

    private GameObject unitychan;

    Vector3 UnityChanPos;

    private int startPos = 50;

    private int goalPos = 80;

    private int OldPos = 40;

    private float posRange = 3.4f;


    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");

        Create(startPos, goalPos);
    }

    // Update is called once per frame
    void Update()
    {
        UnityChanPos = this.unitychan.transform.position;

        if ((int)UnityChanPos.z - OldPos >= 30)
        {

            startPos = (int)UnityChanPos.z + 40;
            goalPos = (int)UnityChanPos.z + 80;

            Create(startPos, goalPos);

            if (goalPos >= 380)
            {
                goalPos = 380;
            }

            OldPos = (int)UnityChanPos.z;
        }
    }

    void Create(int Start, int End)
    {
        for (int i = Start; i < End; i += 15)
        {
            int num = Random.Range(1, 11);
            if (num <= 2)
            {
                for (float j = -1; j <= 1; j += 0.4f)
                {
                    GameObject cone = Instantiate(conePrefab);
                    cone.transform.position = new Vector3(4 * j, cone.transform.position.y, i);
                }
            }

            else
            {
                for (int j = -1; j <= 1; j++)
                {
                    int item = Random.Range(1, 11);

                    int offsetZ = Random.Range(-5, 6);

                    if (1 <= item && item <= 6)
                    {
                        GameObject coin = Instantiate(coinPrefab);
                        coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, i + offsetZ);
                    }

                    else if (7 <= item && item <= 9)
                    {
                        GameObject car = Instantiate(carPrefab);
                        car.transform.position = new Vector3(posRange * j, car.transform.position.y, i + offsetZ);
                    }
                }
            }
        }
    }
}