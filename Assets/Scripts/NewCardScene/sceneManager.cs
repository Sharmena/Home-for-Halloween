using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneManager : MonoBehaviour
{
    public GameObject continueButton;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void switchToWalking() {
        SceneManager.LoadScene(sceneName: "WalkingScene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
