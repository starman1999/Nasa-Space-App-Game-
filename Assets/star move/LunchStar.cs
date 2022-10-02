using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunchStar : MonoBehaviour
{
    public float Speed;
    public float AngularSpeed;
    protected Rigidbody2D rd;
    protected Transform tr;
    // Start is called before the first frame update
    void Start() {
        rd = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();

        Speed = rd.velocity.magnitude;
        AngularSpeed = rd.angularVelocity;

        if(rd.transform.position.x<5)
            rd.AddForce(transform.right * Random.Range(0f, 15f), ForceMode2D.Impulse);
        else 
            rd.AddForce(-transform.right * Random.Range(0f, 15f), ForceMode2D.Impulse);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "end_line")
        {
            Destroy(gameObject);
        }
    }

}
