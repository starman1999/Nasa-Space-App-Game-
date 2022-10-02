using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerChargeBar : MonoBehaviour
{


    public float currentCharge;
    public Slider slider;
    public playerMovement movement;
    AudioSource As;
    void Start()
    {
        currentCharge = 0f;
        As = GetComponent<AudioSource>();
    }

    // Update is called once per frame
  

   public AudioSource audioSource;
   public GameObject fireAnim;
   public AudioClip fireClip;
   public GameObject packs;
   public GameObject shield;
   
   float gravityBonus= 20f;
  
   public void addGravity(){
       Time.timeScale = 1f;
       gravityBonus +=10f ;
       packs.SetActive(false);
       shield.SetActive(false);
   }

   public void removeGravity(){
       Time.timeScale = 1f;
      
       packs.SetActive(false);
       shield.gameObject.SetActive(true);
   }
    
    void Update(){

        if(Input.GetKeyUp(KeyCode.Space)){

            Debug.Log("launch power is:" + currentCharge);
            //send currentCharge to playerMovement
            movement.addForce(currentCharge*2+ gravityBonus);
            audioSource.Stop();
            fireAnim.SetActive(true);
            As.PlayOneShot(fireClip);

    

         }


        if(Input.GetKeyDown(KeyCode.Space)){
            audioSource.Play();
            fireAnim.SetActive(false);
        }

        if(Input.GetKey(KeyCode.Space)){
            fireAnim.SetActive(false);
            
            currentCharge += 0.8f;
            if(currentCharge >= 150f){
                currentCharge = 0f;
            }
            slider.value = currentCharge;
        }else{

            
            currentCharge -= 0.8f;
            if(currentCharge<=0f){
                currentCharge = 0f;
            }
            slider.value = currentCharge;
            
        }


         
      
    }


}
