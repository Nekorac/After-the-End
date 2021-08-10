using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    int health = 1;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            Debug.Log("Dead");
            gameObject.SetActive(false);
        }
    }

    public void removeHealth()
    {
        health--;
    }
}
