using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTwo : MonoBehaviour
{
    public Vector3 targetRotation;
    public Transform startTransform;
    public Transform endTransform;
    public Quaternion startQuat;
    public Quaternion endQuat;

    void Start()
    {
        //targetRotation = EndTransform;
        startQuat = startTransform.gameObject.transform.rotation;
        endQuat = endTransform.gameObject.transform.rotation;
        targetRotation = endQuat.eulerAngles;
        Debug.Log("tr: " + targetRotation);
        StartCoroutine(LerpFunction(Quaternion.Euler(targetRotation), 5));
    }

    IEnumerator LerpFunction(Quaternion endValue, float duration)
    {
        float time = 0;
        Quaternion startValue = transform.rotation;

        while (time < duration)
        {
            transform.rotation = Quaternion.Lerp(startValue, endValue, time / duration);
            time += Time.deltaTime;
            yield return null;
        }
        transform.rotation = endValue;
    }
}
