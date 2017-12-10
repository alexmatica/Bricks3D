using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[RequireComponent (typeof(Rigidbody))]
public class BallController : MonoBehaviour {

    public GameObject levelController;

    float velocityX = 7f;
    float velocityY = 5f;
    float velocityZ = 8f;
    float minVelocity = 4f;
    new Rigidbody rigidbody;

    AudioSource brickAudio;
    AudioSource casualAudio;

	void Awake()
    {
        AudioSource[] allSources = GetComponents<AudioSource>();
        brickAudio = allSources[0];
        casualAudio = allSources[1];
    }

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        resetRBVelocity();
    }
	
	void FixedUpdate()
    {
        if (transform.position.z - transform.localScale.z / 2 <= -7)
        {
            transform.position = Vector3.zero;
            resetRBVelocity();
        }

        Vector3 velo = rigidbody.velocity;
        if (Mathf.Abs(velo.x) < minVelocity)
            rigidbody.velocity = new Vector3(velo.x * 2f, velo.y, velo.z);
        if (Mathf.Abs(velo.y) < minVelocity)
            rigidbody.velocity = new Vector3(velo.x, velo.y * 2f, velo.z);
        if (Mathf.Abs(velo.z) < minVelocity)
            rigidbody.velocity = new Vector3(velo.x, velo.y, velo.z * 2f);
    }

    void Update()
    {
        if (Input.GetKeyDown("space"))
            rigidbody.velocity *= 2f;
        else if (Input.GetKeyUp("space"))
            rigidbody.velocity /= 2f;
    }

    void resetRBVelocity()
    {
        rigidbody.velocity = new Vector3(
                Mathf.Sign(Random.Range(-1f, 1f)) * velocityX,
                Mathf.Sign(Random.Range(-1f, 1f)) * velocityY,
                velocityZ);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Brick"))
        {
            brickAudio.Play();
            levelController.GetComponent<BricksController>().BrickDestroyed();
            Destroy(collision.gameObject);
        }
        else
        {
            casualAudio.Play();
        }
    }
}
