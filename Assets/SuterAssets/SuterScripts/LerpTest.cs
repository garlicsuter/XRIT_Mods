using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    // Transforms to act as start and end markers for the journey.
    public Transform startMarker;
    public Transform endMarker;

    // Movement speed in units per second.
    public float speed = 1.0F;

    // Time when the movement started.
    private float startTime;

    // Total distance between the markers.
    private float journeyLength;

    public Transform startTransform;
    public Transform endTransform;
    public float timeCount = 1.0f;

    void Start()
    {
        // Keep a note of the time the movement started.
        startTime = Time.time;

        // Calculate the journey length.
        journeyLength = Vector3.Distance(startMarker.position, endMarker.position);
        RotateIt();
        //startEuler = Quaternion.Euler(startMarker.rotation.x, startMarker.rotation.y, startMarker.rotation.z);
        //endEuler = Quaternion.Euler(endMarker.rotation.x, endMarker.rotation.y, endMarker.rotation.z);
        //differenceEuler = Quaternion.Euler(startMarker.rotation.x - endMarker.rotation.x, startMarker.rotation.y - endMarker.rotation.y, startMarker.rotation.z - endMarker.rotation.z);
    }

    // Move to the target end position.
    void Update()
    {
        // Distance moved equals elapsed time times speed..
        float distCovered = (Time.time - startTime) * speed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        // Set our position as a fraction of the distance between the markers.
        transform.position = Vector3.Lerp(startMarker.position, endMarker.position, fractionOfJourney);
        Debug.Log("timecount: " + timeCount);
    }

    public void RotateIt()
    {
       
        transform.rotation = Quaternion.Lerp(startTransform.rotation, endTransform.rotation, timeCount * speed);
        timeCount = timeCount + Time.deltaTime;
        Debug.Log("timecount: " + timeCount);
    }
}
