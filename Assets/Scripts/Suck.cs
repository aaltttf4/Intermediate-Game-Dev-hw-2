using UnityEngine;

public class Suck : MonoBehaviour
{
    float timer;
    [SerializeField] float suckStrength;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<PointEffector2D>() == true)
        {
            timer += Time.deltaTime;
        }

        if (timer > 3)
        {
            GetComponent<PointEffector2D>().enabled = false;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            GetComponent<PointEffector2D>().enabled = true;
        }
    }

    float suckTimer = 0;
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            if (suckTimer < 3)
            {
                Vector2 dir = collision.transform.position - transform.position;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(-dir * Time.deltaTime * suckStrength);
            }
            suckTimer += Time.deltaTime;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ball"))
        {
            suckTimer = 0;
        }
    }
}
