using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wavy : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //transform.rotation = Quaternion.Euler(transform.rotation.x, transform.rotation.y, transform.rotation.z + Mathf.PingPong(Time.time * 4, 6));
        transform.rotation = Quaternion.AngleAxis(Mathf.PingPong(Time.time * 4, 20), Vector3.forward);
    }
}
