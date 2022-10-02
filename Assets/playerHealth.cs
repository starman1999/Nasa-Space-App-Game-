using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerHealth : MonoBehaviour
{

    public Slider slider;
    public Slider slider_dna;
    private IEnumerator coroutine;
    
    float currentHealth = 100f;
    float currentDNA = 10f;
    AudioSource audioSource;
    public AudioClip dna_clip;
    public GameObject shield;
    public GameObject superHeroPanel;
    public GameObject gameOverPanel;
    float timer = 20f;
    float rate = 5f;
    public GameObject damage;
    void Start(){
        audioSource = GetComponent<AudioSource>();
    }

   
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Planet02")
        {
      
             currentHealth -= 1f;
             
            
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.tag == "dna"){
            audioSource.PlayOneShot(dna_clip);
            currentDNA += 5f;
            slider_dna.value = currentDNA;

            if(currentDNA >=100f){
                superHeroPanel.SetActive(true);
            }
            
            other.gameObject.SetActive(false);
        }

        if(other.gameObject.tag == "radiation"){

            if(shield.activeSelf == true){
               currentHealth -= 1f;
               slider.value = currentHealth;
             
            }else{

                currentHealth -= 5f;
                slider.value = currentHealth;

            }
            
            
        }
    }

     void Update(){
        slider.value = currentHealth;
    }

}
