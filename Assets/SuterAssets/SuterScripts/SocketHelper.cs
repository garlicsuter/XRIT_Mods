using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
///     Instructions:    
///     1) Attach this SocketHelper.cs to the Interactable GameObject (the thing you pick up)
///     2) Assign variables in Inspector
///     3) On the socket GameObject, set it's tag to "Socket"(You may need to create the tag, then set the tag)
/// </summary>

public class SocketHelper : MonoBehaviour
{
    public bool isEasing = false;
    public GameObject cheese;
    public GameObject fakeCheese;
    public GameObject theSocket;
    public bool inRange = false;
    private bool grabbedSomething = false;
    public float snapDuration = 2.0f;

    private InputData _inputData;

    public void Start()
    {
        _inputData = GetComponent<InputData>();
    }

    public void Update()
    {
        ////if grip is released (becomes false) AND inRange == true, then run EasePlease()
        //if (_inputData._leftController.TryGetFeatureValue(CommonUsages.gripButton, out bool leftGripButtonOut))
        //{
        //    //Debug.Log("leftGripButtonOut: " + leftGripButtonOut);
        //    if(leftGripButtonOut == false && inRange == true && grabbedSomething == true)
        //    {
        //        Debug.Log("EasePlease???");
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Socket"))
        {
            Debug.Log("Socket Hit");
            inRange = true;
            ///other thing is a socket
            theSocket = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Socket"))
        {
            inRange = false;
            Debug.Log("Socket Exited");
            ///other thing is a socket
            theSocket = null;
        }
    }

    //EasePlease() should ONLY run when BOTH the grip is released AND this object is triggerenter in the tagged "socket" gameobject. 
    public void EasePlease()
    {
        fakeCheese.SetActive(true);
        MatchPosition();
        cheese.SetActive(false);
        
        //Setting isEasing to true only for testing the function. It will be set on/off when starting the snapDuration
        isEasing = true;

        while (isEasing == true)
        {
            Debug.Log("Running EasePlease");
            snapDuration -= Time.deltaTime;
            Debug.Log("snapDuration: " + snapDuration);
            if(snapDuration <= 0.0f)
            {
                isEasing = false;
                Debug.Log("Time's up!");
            }
        }
        
    }

    public void MatchPosition()
    {
        fakeCheese.transform.position = cheese.transform.position;
        fakeCheese.transform.rotation = cheese.transform.rotation;
        fakeCheese.transform.localScale = cheese.transform.localScale;
        Debug.Log("Position Matched!");
    }

    public void GrabOn()
    {
        grabbedSomething = true;
        Debug.Log("Grab = On");
    }

    public void GrabOff()
    {
        if (inRange == true && grabbedSomething == true)
                {
                    Debug.Log("EasePlease??? " + "and grabbedSomething: " + grabbedSomething);
                    EasePlease();
                }
            grabbedSomething = false;
        Debug.Log("Grab = Off");
    }
}
