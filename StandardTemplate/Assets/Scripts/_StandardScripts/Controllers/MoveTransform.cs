using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    public Vector3 positionStart;
    public Vector3 positionEnd;
    public float speed = 0;
    public bool doesResetQuaterion;
    public Quaternion objectQuaternion;
    public float snapDistance = .3f;
    private bool isMoving;
    public float timeOut = 10;
    private float currentTime;

    private void Start()
    {
        isMoving = false;
        currentTime = 0;
    }

    public void SetPositions(Vector3 newStartPosition, Vector3 newEndPosition, bool startMovementImmediately)
    {
        transform.position = newStartPosition;
        positionStart = newStartPosition;
        positionEnd = newEndPosition;

        if (startMovementImmediately)
        {
            InitiateMovement();
        }
    }

    public void InitiateMovement()
    {
        isMoving = true;
        if (doesResetQuaterion)
        {
            transform.rotation = objectQuaternion;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && speed != 0 && currentTime < timeOut)
        {
            transform.Translate((positionEnd - transform.position ).normalized * Time.deltaTime * speed, Space.World);

            currentTime += Time.deltaTime;

            if ((positionEnd - transform.position).magnitude < snapDistance)
            {
                transform.position = positionEnd;
                isMoving = false;
                UponMovementSuccess();
            }
        } 
        else if(currentTime > timeOut)
        {
            transform.position = positionEnd;
            isMoving = false;
            UponMovementSuccess();
        }
    }


    public void UponMovementSuccess()
    {
        currentTime = 0;
    }
}
