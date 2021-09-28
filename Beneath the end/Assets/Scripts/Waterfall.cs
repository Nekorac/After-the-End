using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall : MonoBehaviour
{
    bool hasCollided = false;
    public float pushStrength = 500;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!hasCollided)
        {
            hasCollided = true;
            collision.attachedRigidbody.AddForce(new Vector2(0, -pushStrength));
            collision.GetComponent<UnderwaterMovement>().toggleCanSwim();
        }
    }
}
