using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public GameObject planets;
    private Transform closestPlanet;
    private GameObject turret;


    public float moveAccel;
    public float maxMoveSpeed;
    public float moveDrag;

    public float jumpAccel;
    public float maxJumpSpeed;
    public float gravity;

    private float moveVelo;
    private float jumpVelo;
    
    public float bulletStartVelo;
    public float bulletGravityMag;

    private bool isOnPlanet = false;

	void Reset() {
        moveAccel = 0.6f;
        maxMoveSpeed = 1f;
        moveDrag = 0.01f;
        jumpAccel = 150f;
        maxJumpSpeed = 150f;
        gravity = 0.1f;
        moveVelo = 0f;
        jumpVelo = 0f;
        bulletStartVelo = 10f;
        bulletGravityMag = 1f;

        closestPlanet = planets.transform.GetChild(0);
        transform.position = closestPlanet.position + new Vector3(0, closestPlanet.localScale.y / 2 + transform.localScale.y / 2);
        isOnPlanet = true;
        AlignForwardWithClosestPlanetTangent();
    }

	// Start is called before the first frame update
	void Start()
    {

        Reset();
    }

    // Update is called once per frame
    void Update()
    {

       

        FindClosestPlanet();
		AlignForwardWithClosestPlanetTangent();

		float h = Input.GetAxisRaw("Horizontal");
		float v = Input.GetAxisRaw("Vertical");

		moveVelo += h * moveAccel * Time.fixedDeltaTime;
		if(isOnPlanet) jumpVelo += v * jumpAccel * Time.fixedDeltaTime;

		transform.RotateAround(closestPlanet.localPosition, Vector3.back, moveVelo);
		transform.position += (transform.localPosition - closestPlanet.localPosition) * jumpVelo * Time.fixedDeltaTime;

        Collider2D closestPlanetCollider = closestPlanet.transform.GetComponent<Collider2D>();
        isOnPlanet = GetComponent<Collider2D>().IsTouching(closestPlanetCollider);

		if(!isOnPlanet) transform.position -= (transform.localPosition - closestPlanet.localPosition) * gravity * Time.fixedDeltaTime;

		if(moveVelo < 0) {
			moveVelo += moveDrag;
			if(moveVelo > 0) moveVelo = 0;
			else if(moveVelo < -1 * maxMoveSpeed) moveVelo = -1 * maxMoveSpeed;
		} else if(moveVelo > 0) {
			moveVelo -= moveDrag;
			if(moveVelo < 0) moveVelo = 0;
			else if(moveVelo > maxMoveSpeed) moveVelo = maxMoveSpeed;
		}

		if(isOnPlanet) jumpVelo = 0;
		else {
			jumpVelo -= gravity;
			if(jumpVelo < 0) {
				if(jumpVelo < -1 * maxJumpSpeed) jumpVelo = -1 * maxJumpSpeed;
			} else if(moveVelo > 0) {
				if(jumpVelo > maxJumpSpeed) jumpVelo = maxJumpSpeed;
			}
		}
	}


    private void FindClosestPlanet() {
        float minDist = float.MaxValue;
        foreach(Transform child in planets.transform) {
            float dist = Vector3.Distance(child.position, transform.position);
            if(dist < minDist) {
                minDist = dist;
                closestPlanet = child;
            }
        }
    }

  

    private void AlignForwardWithClosestPlanetTangent() {
        Vector3 normal = Vector3.Normalize(closestPlanet.position - transform.position);
        Vector3 tangent = new Vector3(-normal.y, normal.x);
        float angle = Vector3.SignedAngle(Vector3.right, tangent, Vector3.forward);
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    //private void OnCollisionEnter2D(Collision2D collision) {

    //}
    //private void OnCollisionExit2D(Collision2D collision) {

    //}
}