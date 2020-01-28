using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impl2 : templateThing
{
    public impl2()
    {
        id = 2;
        target = new Vector3(2, 2, 2);
    }

    public override void DoThisThing()
    {
        StartCoroutine(ThisTwo());
    }

    IEnumerator ThisTwo()
    {
        Debug.Log("this second");
        yield return null;
    }
}
