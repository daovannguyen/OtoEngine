using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPivot : MonoBehaviour
{
    //GameObject
    //float x, y;
    private void Start()
    {
        //x = transform.position.y;
        //transform.Rotate(0, 180, 0);
        //y = transform.position.y;
        //float z = (x + y) / 2;
        //Debug.Log(z);
        Debug.Log("Inspector" + GetComponent<Transform>().position.x);
        Debug.Log("Gobal" + transform.position.x);
        Debug.Log("Local" + transform.localPosition.x);
    }
    void Update()
    {
    }
}
