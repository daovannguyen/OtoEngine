using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaoHeToaDo : MonoBehaviour
{
    
    public float size;
    public float lenght;
    public GameObject x;
    public GameObject y;
    public GameObject z;
    // Start is called before the first frame update
    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        x.transform.position = new Vector3(lenght / 2, 0, 0);
        x.transform.localScale = new Vector3(lenght, size, size);

        y.transform.position = new Vector3(0, lenght / 2, 0);
        y.transform.localScale = new Vector3(size, lenght, size);

        z.transform.position = new Vector3(0, 0, lenght / 2);
        z.transform.localScale = new Vector3(size,size , lenght);
    }
}
