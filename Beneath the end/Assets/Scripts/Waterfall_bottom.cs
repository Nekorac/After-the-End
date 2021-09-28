using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waterfall_bottom : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<UnderwaterMovement>().toggleCanSwim();
    }
}
