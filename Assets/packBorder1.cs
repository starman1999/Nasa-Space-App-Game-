using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class packBorder1 : MonoBehaviour
{

    public AudioSource audioSource;
    public GameObject packs;
    public AudioClip popUp;

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "Player"){
       

            Debug.Log("collision");
            packs.SetActive(true);
            audioSource.PlayOneShot(popUp);
            Time.timeScale = 0.01f;
            Destroy(gameObject);
            
        }
    }
  
}
