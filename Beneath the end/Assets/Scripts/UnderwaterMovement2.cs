using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterMovement2 : MonoBehaviour
{
    public float sinkForce = 15;
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
    float sinkCountdown = .5f;

    Quaternion startRotation;
    Quaternion endRotation;
    float rotationProgress = -1;

    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        RotateFourPoles();
        swim = Input.GetKey(KeyCode.S);
        if (swim)
        {
            anim.SetBool("isSwimming", true);
        }
        else
        {
            anim.SetBool("isSwimming", false);
        }

        up = Input.GetKey(KeyCode.UpArrow);
        down = Input.GetKey(KeyCode.DownArrow);
        left = Input.GetKey(KeyCode.LeftArrow);
        right = Input.GetKey(KeyCode.RightArrow);

        //Debug.Log(transform.rotation.eulerAngles.z); //>180 for right, < for left

        if (rb.velocity.magnitude < speedForSink)
        {
            sinkTimer += Time.deltaTime;
            if (sinkTimer > sinkCountdown)
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
        Debug.Log(rb.transform.up);
        if (swim)
        {
            //rb.AddForce(rb.transform.up * swimSpeed * Time.fixedDeltaTime);
            rb.MovePosition(rb.transform.position + rb.transform.up * swimSpeed * Time.fixedDeltaTime);
            shouldSink = false;
        }

        if (rotationProgress < 1 && rotationProgress >= 0)
        {
            rotationProgress += Time.deltaTime * 5;

            // Here we assign the interpolated rotation to transform.rotation
            // It will range from startRotation (rotationProgress == 0) to endRotation (rotationProgress >= 1)
            transform.rotation = Quaternion.Lerp(startRotation, endRotation, rotationProgress);
        }

        if (shouldSink)
        {
            rb.AddForce(new Vector2(0, -sinkForce));
        }
    }

    private void LateUpdate()
    {
        if (transform.rotation.eulerAngles.z < 180 && m_FacingRight)
        {
            Flip();
        }
        if (transform.rotation.eulerAngles.z >= 180 && !m_FacingRight)
        {
            Flip();
        }
    }

    private void RotateFourPoles()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartRotating(0);
        }
        else if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            rotationProgress = -1;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartRotating(180);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            StartRotating(90);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            StartRotating(270);
        }

        //if (up)
        //{
        //    rb.MoveRotation(0);
        //}
        //if (down)
        //{
        //    rb.MoveRotation(180);
        //}
        //if (left)
        //{
        //    rb.MoveRotation(90);
        //}
        //if (right)
        //{
        //    rb.MoveRotation(270);
        //}
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

    void StartRotating(float zPosition)
    {

        // Here we cache the starting and target rotations
        startRotation = transform.rotation;
        endRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, zPosition);

        // This starts the rotation, but you can use a boolean flag if it's clearer for you
        rotationProgress = 0;
    }
}
