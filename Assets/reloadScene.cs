using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class reloadScene : MonoBehaviour
{
    public void RestartScene(){
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
