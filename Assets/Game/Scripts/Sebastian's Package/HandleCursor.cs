using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCursor : MonoBehaviour {

    /// <summary>
    /// Handle hiding and locking the cursor.
    /// </summary>
    /// <param name="visible"></param>
    /// <param name="locked"></param>
    public static void HandleCursorVisibility(bool visible, CursorLockMode locked = CursorLockMode.None)
    {
        Cursor.visible = visible;
        Cursor.lockState = locked;
    }

}
