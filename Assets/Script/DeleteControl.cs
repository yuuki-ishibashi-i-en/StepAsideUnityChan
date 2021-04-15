using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteControl : MonoBehaviour
{
    private GameObject unitychan;

    Vector3 UnityChanPos;

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
    }

    // Update is called once per frame
    void Update()
    {
        UnityChanPos = this.unitychan.transform.position;

        if(this.UnityChanPos.z-8>this.gameObject.transform.position.z)
        {
            Destroy(this.gameObject);
        }
    }
}
