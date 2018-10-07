using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControllerManager : MonoBehaviour {
    public GameObject characterInstance;
    public static CharacterControllerManager singletonInstance;
    void Awake()
    { 
            singletonInstance = this;
    }     
}
