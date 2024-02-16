using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using TMPro;

[RequireComponent(typeof(InputData))]
public class DisplayInputData_MegaList : MonoBehaviour
{
    public TextMeshProUGUI leftGripDisplay;
    public TextMeshProUGUI leftGripBoolDisplay;
    public TextMeshProUGUI leftTriggerDisplay;
    public TextMeshProUGUI leftTriggerBoolDisplay;
    public TextMeshProUGUI leftXDisplay;
    public TextMeshProUGUI leftYDisplay;
    public TextMeshProUGUI rightGripDisplay;
    public TextMeshProUGUI rightGripBoolDisplay;
    public TextMeshProUGUI rightTriggerDisplay;
    public TextMeshProUGUI rightTriggerBoolDisplay;
    public TextMeshProUGUI rightADisplay;
    public TextMeshProUGUI rightBDisplay;

    private InputData _inputData;
    //private float _leftMaxScore = 0f;
    //private float _rightMaxScore = 0f;

    private void Start()
    {
        _inputData = GetComponent<InputData>();
    }
    // Update is called once per frame
    void Update()
    {
        //Left Hand
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.grip, out float leftGripDisplayOut))
        {
            leftGripDisplay.text = leftGripDisplayOut.ToString("0.00");
        }
        
        //if left grip is presssed, display boolean value (0 to .49 is false, .50 or higher is true)
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.gripButton, out bool leftGripButtonOut))
        {
            leftGripBoolDisplay.text = leftGripButtonOut.ToString();
        }
        
        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.trigger, out float leftTriggerDisplayOut))
        {
            leftTriggerDisplay.text = leftTriggerDisplayOut.ToString("0.00");
        }

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.triggerButton, out bool leftTriggerButtonOut))
        {
            leftTriggerBoolDisplay.text = leftTriggerButtonOut.ToString();
        }

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.primaryButton, out bool leftXOut))
        {
            leftXDisplay.text = leftXOut.ToString();
        }

        if (_inputData._leftController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool leftYOut))
        {
            leftYDisplay.text = leftYOut.ToString();
        }

        //Right Hand
        //if left grip is presssed, display float value
        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.grip, out float rightGripDisplayOut))
        {
            rightGripDisplay.text = rightGripDisplayOut.ToString("0.00");
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.gripButton, out bool rightGripButtonOut))
        {
            rightGripBoolDisplay.text = rightGripButtonOut.ToString();
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.trigger, out float rightTriggerDisplayOut))
        {
            rightTriggerDisplay.text = rightTriggerDisplayOut.ToString("0.00");
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.triggerButton, out bool rightTriggerButtonOut))
        {
            rightTriggerBoolDisplay.text = rightTriggerButtonOut.ToString();
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.primaryButton, out bool rightXOut))
        {
            rightADisplay.text = rightXOut.ToString();
        }

        if (_inputData._rightController.TryGetFeatureValue(CommonUsages.secondaryButton, out bool rightYOut))
        {
            rightBDisplay.text = rightYOut.ToString();
        }
    }
}
