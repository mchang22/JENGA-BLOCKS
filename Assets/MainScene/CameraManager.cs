using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public static CameraManager Instance;
    public Vector3 desirePos;
    void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        desirePos = transform.position;
    }
    public void GoUp()
    {
        desirePos += Vector3.up;
    }
    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, desirePos, Time.deltaTime * 2);
    }
}
