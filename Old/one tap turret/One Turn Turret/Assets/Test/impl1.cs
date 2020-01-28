using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impl1 : templateThing
{
    public impl1()
    {
        id = 1;
        target = new Vector3(1, 1, 1);
    }

    public override void DoThisThing()
    {
        StartCoroutine(ThisOne());
    }

    IEnumerator ThisOne()
    {
        Debug.Log("this first");
        yield return null;
    }
}
