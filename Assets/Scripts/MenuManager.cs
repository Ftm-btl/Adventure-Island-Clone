using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject data;
    

    public void PlayButton()
    {
        SceneManager.LoadScene(1);
    }

}
