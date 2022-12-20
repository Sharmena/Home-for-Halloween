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


    public void restartBattle() {
        if (DefeatManager.scarHasWon == true) {
            SceneManager.LoadScene(sceneName: "Deck System");
            DefeatManager.scarHasWon = false;
        } else if (DefeatManager.wizardHasWon == true) {
            SceneManager.LoadScene(sceneName: "Deck System Wizard");
            DefeatManager.wizardHasWon = false;
        }
    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
