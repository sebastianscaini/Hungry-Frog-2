using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ParticleSystem))]
public class DestroyParticleSystemWhenDone : MonoBehaviour {

    #region Private Variables
    private ParticleSystem ps;
    #endregion

    private void Awake()
    {
        ps = GetComponent<ParticleSystem>();
    }

    // Use this for initialization
    void Start() {
        Debug.Log(this.gameObject.name);
        Destroy(this.gameObject, ps.main.duration);
    }

    // Update is called once per frame
    void Update() {
        
    }
    
}
