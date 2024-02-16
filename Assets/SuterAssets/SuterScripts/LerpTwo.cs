using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTwo : MonoBehaviour
{
    public Vector3 targetRotation;
    public Transform startTransform;
    public Transform endTransform;
    public Vector3 startVector3;
    public Vector3 endVector3;

    void Start()
    {
        targetRotation = endTransform.eulerAngles;
        startVector3 = startTransform.transform.position;
        endVector3 = endTransform.transform.position;
        //startQuat = startTransform.gameObject.transform.rotation;
        //endQuat = endTransform.gameObject.transform.rotation;
        //targetRotation = endQuat.eulerAngles;
        Debug.Log("tr: " + targetRotation);
        StartCoroutine(LerpRotation(Quaternion.Euler(targetRotation), 3));
        StartCoroutine(LerpPosition(endVector3, 3.0f));
    }

    IEnumerator LerpRotation(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            //transform.position = Vector3.Lerp(startVector3, endVector3, 3.0f);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endValue;
    }

    IEnumerator LerpPosition(Vector3 targetPosition, float duration)
    {
        float time = 0;
        Vector3 startPosition = transform.position;

        while (time < duration)
        {
            transform.position = Vector3.Lerp(startPosition, targetPosition, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.position = targetPosition;
    }
}

