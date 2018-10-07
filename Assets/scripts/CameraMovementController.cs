using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementController : MonoBehaviour
{
    private GameObject cameraInstance;
    private GameObject fpCar;
    void Start()
    {
        fpCar = CharacterControllerManager.singletonInstance.characterInstance;
        cameraInstance = CameraManager.singletonInstance.characterInstance;
    }

    // Update is called once per frame
    void Update()
    {
        cameraInstance.transform.position = fpCar.transform.position;
    }
}
