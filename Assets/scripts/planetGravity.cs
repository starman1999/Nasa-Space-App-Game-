using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class planetGravity : MonoBehaviour
{

    public GameObject planet;

    
    public GameObject planets;
    private Transform closestPlanet;

    Rigidbody2D rb;
    public float gravityForce;
    public float gravityDistance;
    bool rotate = false;

    float lookAngle;
    Vector3 lookDirection;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        closestPlanet = planet.transform;
    }

    // Update is called once per frame
    void Update()
    {
        FindClosestPlanet();
        
        float dist = Vector2.Distance(closestPlanet.transform.position, transform.position);
        Vector3 v = closestPlanet.transform.position -  transform.position;
         
        if (dist < gravityDistance){
            rb.AddForce(v.normalized * (1.0f - dist / gravityDistance) * gravityForce);
        }
        
         
        lookDirection = closestPlanet.transform.position - transform.position;
        lookAngle = 90+ Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, lookAngle);
    }


    private void FindClosestPlanet() {
        var altPlanet = closestPlanet;

        float minDist = float.MaxValue;
        foreach(Transform child in planets.transform) {
            float dist = Vector3.Distance(child.position, transform.position);
            if(dist < minDist) {
                minDist = dist;
                closestPlanet = child;
                if(closestPlanet.name == "earth"){
                    gravityDistance = 5;
                }else{
                     if(closestPlanet.name == "moon"){
                         gravityDistance = 1;
                         gravityForce = 1f;
                     }else{
                          if(closestPlanet.name == "planet02"){
                            gravityDistance = 20;
                            gravityForce = 2.9f;
                          }else{
                              if(closestPlanet.name == "planet03"){
                                  gravityDistance = 2;
                              }
                          }
                     }
                }
            }
        }


       
    }
}
