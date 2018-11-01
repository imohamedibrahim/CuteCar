using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{

    public Vector3 offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;
    public bool noRotation = false;
    private GameObject fpCar;
    private GameObject cameraInstance;
    private Transform fpCarTransform;



    void Start()
    {
        fpCar = CharacterControllerManager.singletonInstance.characterInstance;
        cameraInstance = CameraManager.singletonInstance.characterInstance;
        fpCarTransform = fpCar.transform;
    }

    public void LookAtTarget()
    {
        Vector3 _lookDirection = fpCarTransform.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * 2 * Time.deltaTime);
    }

    public void MoveToTarget()
    {
        Vector3 _targetPos = fpCarTransform.position +
                             fpCarTransform.forward * offset.z +
                             fpCarTransform.right * offset.x +
                             fpCarTransform.up * offset.y;
        transform.position = Vector3.Lerp(transform.position, _targetPos, followSpeed * Time.deltaTime);
    }

    private void NoRotation()
    {
        cameraInstance.transform.position = fpCarTransform.position + (offset.x * Vector3.right) + (offset.y * Vector3.up) + (offset.z * Vector3.forward);
    }

    private void FixedUpdate()
    {
        if (noRotation)
        {
            NoRotation();
        }
        else
        {
            LookAtTarget();
            MoveToTarget();
        }
    }
}