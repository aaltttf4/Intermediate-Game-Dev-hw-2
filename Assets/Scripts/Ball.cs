//using System.Numerics;
using NUnit.Compatibility;
using UnityEditor.Rendering;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    //serialize field gives lets me set the variable in the inspector
    //without having to make that variable public
    [SerializeField]
    Rigidbody2D myBody; //var ref to this game object's rigidbody

    AudioSource myAudioSource;

    [SerializeField]
    AudioClip bumperClip, wallClip, flipperClip, hookClip;

    Vector2 lastVel;

    [SerializeField]
    PinballManager myManager;

    bool hooked = false;
    [SerializeField]GameObject hook;
    float hookTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //myBody = GetComponent<Rigidbody2D>();
        myAudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (myBody.linearVelocityY > 0)
        {
            myBody.gravityScale = 0.7f;
        }
        else
        {
            myBody.gravityScale = 0.5f;
        }

        if (hooked)
        {
            transform.position += new Vector3(0, Time.deltaTime * 5);
            hook.transform.rotation = Quaternion.Euler(0, 0, 0);
            if (transform.position.y > 10)
            {
                hooked = false;
                hook.transform.parent = null;
                myBody.bodyType = RigidbodyType2D.Dynamic;
                transform.position = new Vector3(Random.Range(0.4f, 5), 3.5f, 0);
            }
        }
        else
        {
            hookTime += Time.deltaTime;
            if (hookTime > 3)
            {
                hookTime = 0;
                hook.transform.position = new Vector3(3.5f, 2.8f, 0f);
                hook.transform.eulerAngles = Vector3.zero;
            }
        }
    }

    //calls when a collision first occurs
    void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bumper":
                myAudioSource.PlayOneShot(bumperClip);
                break;
            case "Collision":
                myAudioSource.PlayOneShot(wallClip);
                break;
            case "Flipper":
                myAudioSource.PlayOneShot(flipperClip);
                break;
            case "Hook":
                myAudioSource.PlayOneShot(hookClip);
                break;
        }

        if (collision.gameObject.tag == "Collision")
        {
            myManager.AddScore();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Bumper"))
        {
            myManager.AddScore();
            //Vector2 dirVec = new Vector2(collision.gameObject.transform.up.x, collision.gameObject.transform.up.y);
            myBody.linearVelocity += (Vector2)collision.gameObject.transform.up * 20;
        }

        if (collision.CompareTag("Hook"))
        {
            myManager.AddScore();
            hooked = true;
            hook = collision.gameObject;
            hook.transform.parent = transform;
            myBody.bodyType = RigidbodyType2D.Kinematic;
            myBody.linearVelocity = Vector2.zero;
        }
    }
}
