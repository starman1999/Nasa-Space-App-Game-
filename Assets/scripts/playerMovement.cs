using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{


    Rigidbody2D rb;
    public float speed = 10f;
    public GameObject arrow;
    Vector3 lookDirection;
    float lookAngle;

    // Start is called before the first frame update
    void Start()
    {
         rb = GetComponent<Rigidbody2D>();
         
    }

    // Update is called once per frame




    public void addForce(float force){
       /* Vector3 posInScreen = Camera.main.WorldToScreenPoint(transform.position);
        Vector3 dirToMouse = transform.position - posInScreen;
        dirToMouse.Normalize();
        rb.AddForce(dirToMouse * force);*/
       //rb.velocity = Vector3.zero;
       rb.AddForce(arrow.transform.right* force);
        //rb.velocity = new Vector3 (0, 1, 0);
        Debug.Log("added force:" + force);


    }
    void Update()
    {
        if(Input.GetKey("left")){
            transform.Translate(Vector2.right * (Time.deltaTime * speed), Space.Self);
        }else if (Input.GetKey("right"))
        {
            transform.Translate(Vector2.left * (Time.deltaTime * speed), Space.Self);
        }
        else{
            transform.Translate(Vector2.zero , Space.Self);
        }
    }


      
}
