using UnityEngine;

public class PinballFlipper : MonoBehaviour
{

    [SerializeField]
    KeyCode flipKey;

    [SerializeField]
    Rigidbody2D myBody;

    [SerializeField]
    float flipPower; 

    void Start()
    {
        
    }

    void Update()
    {

        if (Input.GetKeyDown(flipKey))
        {
            myBody.AddForce(transform.up * flipPower);
        }
    }
}
