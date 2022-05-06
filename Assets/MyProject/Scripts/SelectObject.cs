using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObject : MonoBehaviour
{
    [SerializeField]
    public Material hightlightMaterial;
    Material defaultMaterial;
    Transform selection;
    public GameObject selectObject;
    public bool isCamera = false;

    void ChooseObject()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            selectObject = null;
        }
        if (selection != null)
        {
            try
            {
                selection.GetComponent<Renderer>().material = defaultMaterial;
            }
            catch { }
            selection = null;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {

            selection = hit.transform;
            // thua
            if (selection.tag == "ChiTiet")
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = hightlightMaterial;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    selectObject = selection.parent.gameObject;
                }
            }
            else if (selection.parent.tag == "ENGINE")
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                defaultMaterial = selectionRenderer.material;
                if (selectionRenderer != null)
                {
                    selectionRenderer.material = hightlightMaterial;
                }
                if (Input.GetMouseButtonDown(0))
                {
                    selectObject = selection.gameObject;
                }
            }

            
            //string name = selection.name;


            //HIHI.GetComponent<MoveToPosition>().gameObjectControl = gameObjectControl;
        }
    }
    void ChooseCamera()
    {
        selectObject = Camera.main.gameObject;
    }

    private void Update()
    {
        if (isCamera)
        {
            ChooseCamera();
        }
        else
        {
            ChooseObject();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            isCamera = false;
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            isCamera = true;
        }

    }

}
