using Mono.Cecil.Cil;
using UnityEngine;

public class FishMove : MonoBehaviour
{
    [SerializeField]
    int speed = 10;
    float rightLimit = 8f;
    float leftLimit = -3f;
    int direction = -1;
    float timer;
    SpriteRenderer sprite;

    float timeToWait;

    bool waiting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < -10)
        {
            if (waiting)
            {
                timer += Time.deltaTime;
                if (timer > timeToWait)
                {
                    waiting = false;
                }
            }
            else
            {
                direction = 1;
                sprite.flipX = true;
                waiting = true;
                timeToWait = Random.Range(1,5);
            }
        }
        else if (transform.position.x > 10)
        {
            if (waiting)
            {
                timer += Time.deltaTime;
                if (timer > timeToWait)
                {
                    waiting = false;
                    timer = 0;
                }
            }
            else
            {
                direction = -1;
                sprite.flipX = false;
                waiting = true;
                timeToWait = Random.Range(1,5);
            }
        }

        if(!waiting)
            transform.position += new Vector3(direction * speed * Time.deltaTime, 0, 0);
    }
}
