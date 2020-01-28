using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class templateThing : MonoBehaviour
{
    public int id;
    public Vector3 target;

    public abstract void DoThisThing();
}
