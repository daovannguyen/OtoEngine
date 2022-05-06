using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speedTranslate;
    public float speedRotate;
    public GameObject gameObjectControl;
    int controlType;
    private void Start()
    {
        speedTranslate = 3;
        speedRotate = 60f;
    }
    private void ChangeControlType()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            controlType = (int)ControlType.TRANSLATE;
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            controlType = (int)ControlType.ROTATE;
        }
    }
    Vector3 GetInputTranslationDirection()
    {
        Vector3 direction = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector3.right;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector3.down;
        }
        if (Input.GetKey(KeyCode.Q))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.E))
        {
            direction += Vector3.up;
        }
        return direction;
    }
    private void Update()
    {
        var selection = GetComponent<SelectObject>();
        if (selection.selectObject != null)
        {
            gameObjectControl = selection.selectObject;
            ChangeControlType();
            if (controlType == (int)ControlType.TRANSLATE)
            {
                gameObjectControl.transform.Translate(GetInputTranslationDirection() * Time.deltaTime * speedTranslate, Space.World);
            }
            if (controlType == (int)ControlType.ROTATE)
            {
                gameObjectControl.transform.Rotate(GetInputTranslationDirection() * Time.deltaTime * speedRotate, Space.World);
            }
        }
    }
}
