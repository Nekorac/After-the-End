using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblePush : MonoBehaviour
{
    public float pushStrength = 200;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.attachedRigidbody.AddForce(new Vector2(0, pushStrength));
        collision.GetComponent<UnderwaterMovement>().cantSwim();
    }
}
