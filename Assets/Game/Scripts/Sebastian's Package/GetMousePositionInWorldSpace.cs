using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetMousePositionInWorldSpace : MonoBehaviour {

    /// <summary>
    /// Get the mouse position in world space.
    /// </summary>
    /// <returns></returns>
	public static Vector3 GetMousePosition()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        return mousePosition;
    }
}
