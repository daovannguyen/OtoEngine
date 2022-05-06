using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MouseMoveType
{
    X, Y, Z
}

public class MouseMove : MonoBehaviour
{
    public GameObject heToaDo;
    SelectObject selectObject;
    int moveType;
    Vector3 vector3;
    float speed;

    private void Init()
    {
        speed = 2f;
        selectObject = GetComponent<SelectObject>();
        heToaDo.SetActive(false);
    }

    void DisplayHeToaDo()
    {
        if(selectObject.selectObject != null)
        {
            heToaDo.transform.position = selectObject.selectObject.transform.localPosition;
            heToaDo.transform.rotation = selectObject.selectObject.transform.localRotation;
            heToaDo.SetActive(true);
        }
        else
        {
        }
    }  
    
    void RayCastChooseTruc()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            
            if (hit.transform.tag == "HeToaDo")
            {
                switch(hit.transform.gameObject.name)
                {
                    case "x":
                        moveType = (int)MouseMoveType.X;
                        vector3 = new Vector3(1, 0, 0);
                        break;
                    case "y":
                        moveType = (int)MouseMoveType.Y;
                        vector3 = new Vector3(0, 1, 0);
                        break;
                    case "z":
                        moveType = (int)MouseMoveType.Z;
                        vector3 = new Vector3(0, 0, 1);
                        break;
                }    
            }
            
        }
    }

    
    // Start is called before the first frame update
    void Start()
    {
        Init();
    }

    // Update is called once per frame
    void Update()
    {

        DisplayHeToaDo();
        RayCastChooseTruc();
        float input = Input.GetAxis("Vertical");
        //Debug.Log(input);
        try
        {
            selectObject.selectObject.transform.Translate(input * vector3 * Time.deltaTime * speed);
        }
        catch { }
        //Debug.Log(input * vector3 * Time.deltaTime * speed);

    }
}
