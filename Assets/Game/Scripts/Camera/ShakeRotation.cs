using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeRotation : MonoBehaviour
{
    [Header("Parameters")]
    public Vector3 intensity;

    private void FixedUpdate()
    {
        gameObject.ShakeRotation(intensity, 0.1f, 0f);
    }
}
