using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChuyenVeGia : MonoBehaviour
{
    public GameObject model;
    // Start is called before the first frame update
    void Start()
    {
        int[] arr = { -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5 };
        int chilCount = model.transform.childCount;
        for (int i=0; i<chilCount; i++)
        {
            GameObject child = model.transform.GetChild(i).gameObject;
            child.transform.position = new Vector3(arr[i % 10] * 3, 1, 0);
            child.AddComponent<Rigidbody>();
        }    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
