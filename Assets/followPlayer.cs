using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform player;

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3 (player.transform.position.x, player.transform.position.y, -10);
    }
}
