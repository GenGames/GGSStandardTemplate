using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTarget : MonoBehaviour
{
    public Transform target;
    public Transform fovStartPoint;
    public float lookSpeed;
    public float maxAngle;

    private Quaternion targetRotation;
    private Quaternion lookAt;

    public bool aimTimeout = true;
    public float resetTime;

    public void AssignTarget(Transform newTarget)
    {
        target = newTarget;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 direction = (target.position - transform.position).normalized;
            if (EnemyInFieldOfView(fovStartPoint))
            {
                Quaternion targetRotation = Quaternion.LookRotation(direction);
                Quaternion lookAt = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * lookSpeed);
                transform.rotation = lookAt;
            }
            if (aimTimeout)
            {
                StartCoroutine(TimeoutAim());
            }
        }
        if (target == null)
        {
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    public bool EnemyInFieldOfView(Transform fovtarget)
    {
        Vector3 targetDir = target.position - transform.position;
        float angle = Vector3.Angle(targetDir, fovtarget.forward);

        if (angle < maxAngle)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    IEnumerator TimeoutAim()
    {
        yield return new WaitForSecondsRealtime(resetTime);
        target = null;
    }
}
