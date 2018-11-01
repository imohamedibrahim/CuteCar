using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VehicleSelector : MonoBehaviour {
    List<GameObject> vehicleGroup;
    public GameObject vehiclesGroup;
	// Use this for initialization
	void Start () {
        vehicleGroup = Utils.GetVehicle(vehiclesGroup); 	
	}	
	// Update is called once per frame
	void Update () {
        foreach (Touch touch in Input.touches)
        {
            if (touch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit = new RaycastHit();
                if (Physics.Raycast(ray, out hit, 1000.0f))
                {
                    if (hit.collider.gameObject && DetectGameObject(hit.collider.gameObject))
                    {
                        PlayerPrefs.SetString("CarSelected",hit.collider.gameObject.name);
                        Debug.Log(PlayerPrefs.GetString("CarSelected"));
                        SceneManager.LoadScene("Scene1");
                    }
                }
            }
        }
    }

    private bool DetectGameObject(GameObject _collidedGameObject)
    {

        foreach(GameObject _tmpGameObject in vehicleGroup)
        {
           // Debug.Log(_tmpGameObject);
            if (_tmpGameObject.name == _collidedGameObject.name)
            {
                return true;
            }
        }
        return false;

    }
}
