using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePlayer : MonoBehaviour
{
    public float force;
    protected Rigidbody2D rd;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown("space"))
        // {
        //     rd.AddForce(transform.up * force);
        // }
        
        // Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        if(Input.GetKey(KeyCode.LeftArrow)){
            transform.Rotate(new Vector3(0, 0, 100) * Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.RightArrow)){
            transform.Rotate(new Vector3(0, 0, -100) * Time.deltaTime);
        }
        else if(Input.GetKeyDown("space")){
            rd.AddForce(transform.up * force);
        }
    }
}
