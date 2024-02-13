using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
/// <summary>
///     Instructions:    
///     1) Attach this SocketHelper.cs to the Interactable GameObject (the thing you pick up)
///     2) Assign variables in Inspector
///     3) On the socket, set tag to "Socket".
/// </summary>


public class SocketHelper : MonoBehaviour
{
    public bool isEasing = false;
    public GameObject Cheese;
    public GameObject fakeCheese;
    public GameObject theSocket;
    public bool inRange = false;
    public float snapDuration = 2.0f;


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
        MatchPosition();
        //Cheese.SetActive(false);
        fakeCheese.SetActive(true);
        
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
        fakeCheese.transform.position = Cheese.transform.position;
        fakeCheese.transform.rotation = Cheese.transform.rotation;
        fakeCheese.transform.localScale = Cheese.transform.localScale;
        Debug.Log("Position Matched!");
    }
}
