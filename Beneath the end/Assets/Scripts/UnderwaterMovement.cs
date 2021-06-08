using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterMovement : MonoBehaviour
{
    Rigidbody2D rb;
    bool swim = false;
    bool up = false;
    bool right = false;
    bool left = false;
    bool down = false;
    public float rotSpeed = 100;
    public float swimSpeed = 100;
    private bool m_FacingRight = true;  // For determining which way the player is currently facing.
    private bool shouldSink = false;
    [SerializeField] float speedForSink = 0.5f;
    [SerializeField] float _sinkSpeed = 0.5f;
    float sinkTimer = 0;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        swim = Input.GetKey(KeyCode.S);
        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        if (rb.velocity.magnitude < speedForSink)
        {
            sinkTimer += Time.fixedDeltaTime;
            if (sinkTimer > 1f)
            {
                shouldSink = true;
            }
        }
        else
        {
            sinkTimer = 0;
            shouldSink = false;
        }

    }

    private void FixedUpdate()
    {
        //RotateFourPoles();
        if (up)
        {
            rb.MoveRotation(rb.rotation + rotSpeed * Time.fixedDeltaTime);
        }
        if (down)
        {
            rb.MoveRotation(rb.rotation - rotSpeed * Time.fixedDeltaTime);
        }

        if (swim)
        {
            rb.AddForce(rb.transform.up * swimSpeed * Time.fixedDeltaTime);
            shouldSink = false;
        }

        if (shouldSink)
        {
            //float sinkSpeed = rb.velocity.y;
            //sinkSpeed -= _sinkSpeed * Time.fixedDeltaTime;
            //rb.velocity = new Vector2(rb.velocity.x, -_sinkSpeed);
            rb.AddForce(new Vector2(0, -25));
        }
        //if (rb.rotation > 0 && !m_FacingRight)
        //{
        //    Flip();
        //}
        //else if (rb.rotation < 180 && m_FacingRight)
        //{
        //    Flip();
        //}
    }

    private void RotateFourPoles()
    {
        if (up)
        {
            rb.MoveRotation(0);
        }
        if (down)
        {
            rb.MoveRotation(180);
        }
        if (left)
        {
            rb.MoveRotation(90);
        }
        if (right)
        {
            rb.MoveRotation(270);
        }
    }

    private void Flip()
    {
        // Switch the way the player is labelled as facing.
        m_FacingRight = !m_FacingRight;

        // Multiply the player's x local scale by -1.
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }
}
