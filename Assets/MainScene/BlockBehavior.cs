using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockBehavior : MonoBehaviour
{

    public Vector3 Center;
    public Vector3 MoveDirection;
    public bool Moving = false;
    public float MovingSpeed = 10;

    private float StartTime;
    private float StartPositionOffset = 8;

    void Start()
    {
        StartTime = Time.time;
    }

    public void Init(Vector3 center, Vector3 moveDirection, Vector3 scale)
    {
        this.Center = center;
        this.MoveDirection = moveDirection;

        Moving = true;

        transform.localScale = scale;
        transform.position = Center - MoveDirection * StartPositionOffset;
    }

    public IEnumerator Recover(Vector3 recoverScale, Vector3 recoverCenter)
    {
        float recoverTime = Time.time;
        Vector3 scaleDifference = recoverScale - transform.localScale;
        Vector3 posDifference = recoverCenter - transform.position;

        while ((Time.time - recoverTime) < 0.25f)
        {
            transform.localScale += scaleDifference * Time.deltaTime * 4;
            transform.position += posDifference * Time.deltaTime * 4;
            yield return null;
        }

        transform.localScale = recoverScale;
        transform.position = recoverCenter;
    }

    void Update()
    {
        if (Moving)
        {
            if (MoveDirection == Vector3.forward)
                transform.position = new Vector3(transform.position.x, transform.position.y, Mathf.PingPong((Time.time - StartTime) * MovingSpeed, 16) - 8);
            if (MoveDirection == Vector3.right)
                transform.position = new Vector3(Mathf.PingPong((Time.time - StartTime) * MovingSpeed, 16) - 8, transform.position.y, transform.position.z);
        }
    }
}
