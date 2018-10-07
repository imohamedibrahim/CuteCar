using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterMovementController : MonoBehaviour {
    GameObject fpCar;
    GameObject wheels;
    List<GameObject> wheel = new List<GameObject>();
    List<WheelCollider> rearWheel = new List<WheelCollider>();
    List<WheelCollider> frontWheel = new List<WheelCollider>();
    public float maxSteerAngle;
    public float motorForce;
    public float horizontalInput = 1;
    public float verticalInput = 1;
    private float steerAngle;
    private void Start()
    {
        fpCar = CharacterControllerManager.singletonInstance.characterInstance;
        wheels = Utils.GetChildWithTag(fpCar, "Wheels");
        frontWheel = Utils.GetWheelCollidersWithTag(wheels, "FrontWheel");
        rearWheel = Utils.GetWheelCollidersWithTag(wheels, "RearWheel");
        steerAngle = 0;
    }

    private void Accelerate()
    {
        foreach (WheelCollider _tmp in rearWheel)
        {

            _tmp.motorTorque = 700;
        }
    }
    private void FixedUpdate()
    {
        Accelerate();
        Steer(maxSteerAngle);
    }

    public void TurnLeft()
    {
        Steer(-maxSteerAngle);
        StartCoroutine(wait());
        Steer(0);
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
        SteerHelper(-1,true);
    }

    private void SteerHelper(float _signFlagForSteer,bool _steerFlag)
    {
        if (_steerFlag && steerAngle < 1)
        {
            steerAngle = steerAngle + 0.2f;
        }
        Steer(_signFlagForSteer*steerAngle);
    }

    public void PointerExitOnLeft()
    {
        steerAngle = 0;
        Steer(steerAngle);
    }

    public void PointerEnterOnRight()
    {
        SteerHelper(1,true);
    }

    public void PointerExitOnRight()
    {
        steerAngle = 0;
        Steer(steerAngle);
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(1f);
    }

    public void TurnRight()
    {
        Steer(maxSteerAngle);
    }
}
