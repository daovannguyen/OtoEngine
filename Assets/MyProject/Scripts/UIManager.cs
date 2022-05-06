using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject parentObject;
    GameObject nowObject;
    Button chooseParent_Btn;
    TMP_Text parentObjectName_Text;
    TMP_Text status_Text;
    TMP_Text name_Text;
    public float distanceAllow;
    public float rotationAllow;
    SelectObject selectObject;

    private void Init()
    {
        distanceAllow = 0.5f; 
        rotationAllow = 0.5f;

        chooseParent_Btn = GameObject.Find("Parent/chooseParent_Btn").GetComponent<Button>();
        parentObjectName_Text = transform.Find("Parent/parentObjectName_Text").GetComponent<TMP_Text>();
        status_Text = transform.Find("Now/status_Text").GetComponent<TMP_Text>();
        name_Text = transform.Find("Now/name_Text").GetComponent<TMP_Text>();

        chooseParent_Btn.onClick.AddListener(OnClickButtonChooseParent);

        selectObject = GameObject.Find("ENGINEControl").GetComponent<SelectObject>();

        parentObjectName_Text.text = "";
        status_Text.text = "Chua chon goc";
        name_Text.text = "";
    }

    void OnClickButtonChooseParent()
    {
        try
        {
            if (selectObject.selectObject == null)
            {
                parentObjectName_Text.text = "Chua chon doi tuong";
            }
            else
            {
                parentObject = selectObject.selectObject;
                parentObjectName_Text.text = parentObject.name;
            }
        }
        catch { }
            
    }
    void UpdateStatusNowObject()
    {
        if (selectObject.selectObject == null)
        {
            name_Text.text = "";
            status_Text.text = "";
        }
        else
        {
            name_Text.text = selectObject.selectObject.name;
            if (parentObject == null)
            {
                status_Text.text = "Chua chon goc!";
            }    
            else if (CheckDistaneAllow())
            {
                    status_Text.text = "Dung vi tri";
            }   
            else
            {
                status_Text.text = "Sai vi tri";
            }    
        }
    }
    bool CheckDistaneAllow()
    {
        Vector3 target = parentObject.transform.position - nowObject.transform.position;
        bool x = Mathf.Abs(target.x) < distanceAllow;
        bool y = Mathf.Abs(target.y) < distanceAllow;
        bool z = Mathf.Abs(target.z) < distanceAllow;
        var checkPositon = x && y && z;
        Vector3 rotionParent = new Vector3(parentObject.transform.rotation.x, parentObject.transform.rotation.y, parentObject.transform.rotation.z);
        Vector3 rotionNow = new Vector3(nowObject.transform.rotation.x, nowObject.transform.rotation.y, nowObject.transform.rotation.z);
        target = rotionParent - rotionNow; 
        x = Mathf.Abs(target.x) < rotationAllow;
        y = Mathf.Abs(target.y) < rotationAllow;
        z = Mathf.Abs(target.z) < rotationAllow;
        var checkRotation = x && y && z;

        Debug.Log(target);
        if (checkPositon && checkRotation)
        {
            return true;
        }    
        else
        {
            return false;
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
            if (nowObject != selectObject.selectObject)
            {
                nowObject = selectObject.selectObject;
                UpdateStatusNowObject();
            }
    }
}
