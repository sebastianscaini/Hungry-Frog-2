using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySourceWhenDone : MonoBehaviour {

    #region Private Variables
    private AudioSource source;
    #endregion

    private void Awake()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.parent == null)
        {
            DestroyWhenDone();
        }
    }

    /// <summary>
    /// Destroy source when done playing.
    /// </summary>
    private void DestroyWhenDone()
    {
        if (!source.isPlaying)
        {
            Destroy(this.gameObject);
        }
    }
}
