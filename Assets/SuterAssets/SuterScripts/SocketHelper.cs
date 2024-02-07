using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SocketHelper : MonoBehaviour
{
    public bool isEasing = false;
    public GameObject Cheese;
    public GameObject fakeCheese;
    public GameObject theSocket;

    [SerializeField]
    public float snapDuration = 2.0f;

    public void EasePlease()
    {
        MatchPosition();
        Cheese.SetActive(false);
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
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Socket"))
        {
            Debug.Log("Socket Hit");
        }
    }
}
