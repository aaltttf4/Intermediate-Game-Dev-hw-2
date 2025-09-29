using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class Particle : MonoBehaviour
{
    ParticleSystem particles;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        particles = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ball")
        {
            particles.Play();
        }
    }
}
