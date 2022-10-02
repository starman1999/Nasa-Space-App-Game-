using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class gameOver : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider slider;
    public GameObject gameOverPanel;

    // Update is called once per frame
    void Update()
    {
        if(slider.value <= 0f ){
            Time.timeScale = 0f;
            gameOverPanel.SetActive(true);
        }
    }
}
