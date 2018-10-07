using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static GameObject GetChildWithTag(GameObject tmp, string tag)
    {
        foreach (Transform t in tmp.transform)
        {
            if (t.tag == tag)
            {
                return t.gameObject;
            }
        }
        return null;
    }

    public static List<GameObject> GetChildrenWithTag(GameObject tmp, string tag)
    {
        List<GameObject> tmpList = new List<GameObject>();
        foreach (Transform t in tmp.transform)
        {
            if (t.tag == tag)
            {
                tmpList.Add(t.gameObject);
            }
        }
        return tmpList;
    }

    public static List<WheelCollider> GetWheelCollidersWithTag(GameObject tmp,string tag)
    {
        List<WheelCollider> tmpWheels = new List<WheelCollider>();
        foreach(Transform t in tmp.transform)
        {
            if(t.tag == tag)
            {
                tmpWheels.Add(t.GetComponent<WheelCollider>());
            }
        }
        return tmpWheels;
    }

}
