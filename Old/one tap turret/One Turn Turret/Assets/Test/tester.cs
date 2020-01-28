using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tester : MonoBehaviour
{
    public GameObject impl1Obj;
    public GameObject impl2Obj;

    // Start is called before the first frame update
    void Start()
    {
        impl1Obj.GetComponent<templateThing>().DoThisThing();
        impl2Obj.GetComponent<templateThing>().DoThisThing();
    }
}
