using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class FlashUI : MonoBehaviour {

	// Use this for initialization
	void Start () {
        InvokeRepeating("Flash", 0f, 1f);
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    private void Flash()
    {
        if (GetComponent<CanvasGroup>().alpha == 0)
        {
            GetComponent<CanvasGroup>().alpha = 1;
        }
        else
        {
            GetComponent<CanvasGroup>().alpha = 0;
        }
    }
}
