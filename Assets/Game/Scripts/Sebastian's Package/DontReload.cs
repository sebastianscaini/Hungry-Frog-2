using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontReload : MonoBehaviour {

    //Array of other objects not to reload.

    DontReload[] dupes;
    // Use this for initialization
    void Awake()
    {
        //find all objects set to not reload
        dupes = FindObjectsOfType<DontReload>();

        int count = 0;

        //check if a duplicate exists of the gameObject the script is attached to.
        foreach (DontReload dupe in dupes)
        {
            if (dupe.gameObject.name == this.gameObject.name)
            {
                if (count != 0)
                {
                    //Destroy duplicates
                    Destroy(dupe.gameObject);
                }
                else
                {
                    count++;
                }
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}
