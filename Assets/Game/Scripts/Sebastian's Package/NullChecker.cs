using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NullChecker : MonoBehaviour {

    /// <summary>
    /// Throw an exception when the thing is null.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="thing"></param>
    /// <param name="name"></param>
    public static void CheckNull<T>(T thing, string name = "Something")
    {
        if(thing == null)
        {
            throw new System.NullReferenceException(name + " is null!");
        }
    }
}
