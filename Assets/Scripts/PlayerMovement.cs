using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce = 8000f;
    public float sidewaysForce = 100f;

    private bool isMovingLeft = false;
    private bool isMovingRight = false;

    void Update()
    {
        // Go right
        if (Input.GetKey("d"))
        {
            isMovingRight = true;
        }
        else
        {
            isMovingRight = false;
        }

        // Go left
        if (Input.GetKey("a"))
        {
            isMovingLeft = true;
        }
        else
        {
            isMovingLeft = false;
        }
    }

    void FixedUpdate()
    {
        rb.AddForce(0, 0, forwardForce * Time.deltaTime);

        // Go right
        if (isMovingRight)
        {
            rb.AddForce(sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // Go left
        if (isMovingLeft)
        {
            rb.AddForce(-sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        // End game if player falls
        if (rb.position.y < -1f)
        {
            FindObjectOfType<GameController>().EndGame();
        }
    }
}
