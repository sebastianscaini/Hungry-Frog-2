using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour {

	// Use this for initialization
	void Awake () {
        //Don't destroy this gameObject on load
        DontDestroyOnLoad(this.gameObject);
	}
}
