using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fly : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D collision;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        collision = GetComponent<Collider2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb.AddTorque(Random.Range(-1f, 1f), ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        if (collision.isTrigger)
        {
            if(Vector2.Distance(transform.position, new Vector3(-0.2f, 0.3f)) < 0.5f)
            {
                Camera.main.gameObject.ShakePosition(new Vector3(0.2f, 0.2f, 0f), 0.2f, 0f);
                FMODUnity.RuntimeManager.CreateInstance("event:/Crunch").start();

                FindObjectOfType<Manager>().currentHunger += 5f;
                FindObjectOfType<Manager>().AddScore();

                Destroy(this.gameObject);
            }
        }

        if(transform.position.y < -15f)
        {
            Destroy(this.gameObject);
        }
    }
}
