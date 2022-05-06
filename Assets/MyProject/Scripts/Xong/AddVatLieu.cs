using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
struct InfoGameObjectChild
{
   public string name;
   public Vector3 toaDo;
   public Vector3 goc;
};*/

public class AddVatLieu : MonoBehaviour
{
    [SerializeField]
    public GameObject model;
    public Material[] textures;
    //public List<InfoGameObjectChild> infoChild = new List<InfoGameObjectChild>();
    // Start is called before the first frame update
    void Start()
    {
        int textureCount = textures.Length;
        for (int i = 0; i < 1000; i++)
        {
            GameObject a = model.gameObject.transform.GetChild(i).gameObject;

            try
            {
                a.gameObject.GetComponent<Renderer>().material = textures[i % textureCount];
            }
            finally
            {

            }
            //InfoGameObjectChild b;
            //b.name = a.name;
            //b.toaDo = a.transform.position;
            //b.goc = a.transform.qua;
            //infoChild.Add(b);
        }


    }

    // Update is called once per frame
    void Update()
    {
    }
}
