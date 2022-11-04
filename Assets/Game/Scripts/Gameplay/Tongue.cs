using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tongue : MonoBehaviour
{
    [Header("Other Pieces")]
    public LineRenderer line;
    public Animator frogAnimator;

    [Header("Sounds")]
    public float soundThreshold;
    public float soundDelay;

    private bool soundPlayed = false;
    private bool soundReloaded = true;
    private Vector3 lastFramePosition;

    // Start is called before the first frame update
    void Start()
    {
        HandleCursor.HandleCursorVisibility(false);
    }

    // Update is called once per frame
    void Update()
    {
        frogAnimator.SetBool("Licking", true);

        transform.position = Vector3.Lerp(transform.position, GetMousePositionInWorldSpace.GetMousePosition() + new Vector3(0f, 0f, 2f), 0.1f);

        line.SetPosition(0, new Vector3(frogAnimator.gameObject.transform.position.x - 0.2f, frogAnimator.gameObject.transform.position.y + 0.3f, -1f));
        line.SetPosition(1, new Vector3(transform.position.x, transform.position.y, -1f));
        
        /*
        if(Vector2.Distance(transform.position, lastFramePosition) > soundThreshold && !soundPlayed)
        {
            FMODUnity.RuntimeManager.CreateInstance("event:/Glass").start();
            soundPlayed = true;
            soundReloaded = false;

            Invoke("ReloadSound", soundDelay);
        }
        else if(Vector2.Distance(transform.position, lastFramePosition) > 0.01f && soundReloaded)
        {
            soundPlayed = false;
        }

        Debug.Log(Vector2.Distance(transform.position, lastFramePosition));
        */
    }

    private void ReloadSound()
    {
        soundReloaded = true;
    }

    private void LateUpdate()
    {
        lastFramePosition = transform.position;
    }

    private void OnDestroy()
    {
        HandleCursor.HandleCursorVisibility(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Fly")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().gravityScale = 0f;
            collision.gameObject.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
            collision.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, collision.gameObject.transform.position.y, transform.position.z);
            collision.gameObject.GetComponent<Collider2D>().isTrigger = true;
            
            collision.gameObject.transform.parent = this.gameObject.transform;

            FMODUnity.RuntimeManager.CreateInstance("event:/Pop").start();
            Camera.main.gameObject.ShakePosition(new Vector3(0.1f, 0.1f, 0f), 0.1f, 0f);
        }
    }
}
