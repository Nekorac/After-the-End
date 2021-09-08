using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour
{
    int health = 1;
    bool dead = false;
    public GameObject deathParticles;

    // Update is called once per frame
    void Update()
    {
        if (health <= 0 && !dead)
        {
            Debug.Log("Dead");
            dead = true;
            gameObject.SetActive(false);
            Instantiate(deathParticles, gameObject.transform.position, deathParticles.transform.rotation);
            Invoke("reloadScene", 5);

        }
    }

    void reloadScene()
    {
        SceneManager.LoadScene("Linda's scene");
    }

    public void removeHealth()
    {
        health--;
    }
}
