using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class Destrictible : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject obj;
    public GameObject parent;

    public void DestroyObj()
    {
        Instantiate(obj, parent.transform);
        Destroy(gameObject);
    }
}
