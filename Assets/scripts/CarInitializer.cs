using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarInitializer : MonoBehaviour {
    List<GameObject> vehicleGroup;
    public GameObject vehiclesGroup;
    void Awake(){
        vehicleGroup = Utils.GetVehicle(vehiclesGroup);
        Debug.Log(PlayerPrefs.GetString("CarSelected"));
        CharacterControllerManager.singletonInstance.characterInstance = Utils.GetGameObjectWithName(vehicleGroup, PlayerPrefs.GetString("CarSelected"));
    }
}
