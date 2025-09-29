using UnityEngine;

public class Force : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("RotateDir", 0.5f, 0.5f);
    }

    void RotateDir()
    {
        transform.Rotate(0, 0, 0);
    }
}
