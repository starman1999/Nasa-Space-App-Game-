using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backgroundLoop : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(-0.5f * Time.deltaTime, 0);

        if(transform.position.x < -22){
            transform.position = new Vector3(22, transform.position.y);
        }
    }
}
