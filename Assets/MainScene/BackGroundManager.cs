using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour {
    public GameObject Wall1;
    public GameObject Wall2;


    void Update()
    {
        if (Camera.main.transform.position.y > Wall1.transform.position.y)
        {
            GameObject t1 = Instantiate(Wall1, Wall1.transform.position + Vector3.up * 100, Wall1.transform.rotation);
            GameObject t2 = Instantiate(Wall2, Wall2.transform.position + Vector3.up * 100, Wall2.transform.rotation);
            Wall1 = t1;
            Wall2 = t2;
        }
    }
}
