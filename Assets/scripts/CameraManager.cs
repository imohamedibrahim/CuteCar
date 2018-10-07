using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject characterInstance;
    public static CameraManager singletonInstance;
    void Awake()
    {
        singletonInstance = this;
    }
}
