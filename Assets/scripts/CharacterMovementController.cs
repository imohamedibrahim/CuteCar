using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementController: MonoBehaviour {
    GameObject fpCarTransform;
    GameObject wheels;
    List<GameObject> wheel = new List<GameObject>();
    List<WheelCollider> rearWheel = new List<WheelCollider>();
    List<WheelCollider> frontWheel = new List<WheelCollider>();
    public float maxSteerAngle;
    public float motorForce;
    public float horizontalInput = 1;
    public float verticalInput = 1;
    private float steerAngle;
    float signFlagForSteer;
    bool steerFlag;
    public InputField inputTorque;
    public InputField inputSteer;
    public Vector3 centreOfMass;
    private int reset;
    public int reset_value;
    private float screenCentre;
    private void Start()
    {
        screenCentre = Screen.width*0.5f;
        fpCarTransform = CharacterControllerManager.singletonInstance.characterInstance;
        wheels = Utils.GetChildWithTag(fpCarTransform, "Wheels");
        frontWheel = Utils.GetWheelCollidersWithTag(wheels, "FrontWheel");
        rearWheel = Utils.GetWheelCollidersWithTag(wheels, "RearWheel");
        steerAngle = 0;
        signFlagForSteer = 0;
        steerFlag = false;
        reset = 0; 
    }

    private void Accelerate()
    {
        foreach (WheelCollider _tmp in rearWheel)
        {

            _tmp.motorTorque = motorForce;
        }
    }
    private void FixedUpdate()
    {
        fpCarTransform.GetComponent<Rigidbody>().centerOfMass = centreOfMass;
        motorForce = float.Parse(inputTorque.text);
        maxSteerAngle = float.Parse(inputSteer.text);
        Accelerate();
        DetectAndApplyTouch();
    }

    public void DetectAndApplyTouch()
    {
        if (Input.touchCount > 0)
        {
            Touch firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Began)
            {
                if (firstTouch.position.x > screenCentre)
                {
                    if (signFlagForSteer != 1)
                    {
                        steerAngle = 0;
                        signFlagForSteer = 1;
                    }
                    SteerHelper();
                }
                if (firstTouch.position.x < screenCentre)
                {
                    if(signFlagForSteer != -1)
                    {
                        steerAngle = 0;
                        signFlagForSteer = -1;
                    }
                    SteerHelper();
                }
            }
        }
        else
        {
            steerAngle = 0;
            signFlagForSteer = 0;
            Steer(steerAngle);
        }
    }
    
    public void TurnLeft()
    {
        reset = 0;
        Steer(-maxSteerAngle*1);
        
    }

    private void Steer(float _angle)
    {
        foreach (WheelCollider _tmp in frontWheel)
        {
            _tmp.steerAngle = _angle*maxSteerAngle;
        }
    }

    public void PointerEnterOnLeft()
    {
        signFlagForSteer = -1;
        steerFlag = true;
    }

    private void SteerHelper()
    {
        if (steerAngle < 1)
        {
            steerAngle = steerAngle + 0.2f;
        }
        Steer(signFlagForSteer*steerAngle);
    }

    public void PointerExit()
    {
        steerAngle = 0;
        steerFlag = false;
        Steer(steerAngle);
    }

    public void PointerEnterOnRight()
    {
        steerFlag = true;
        signFlagForSteer = 1;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }

    public void TurnRight()
    {
        reset = 0;
        Steer(maxSteerAngle*1);
    }
}
