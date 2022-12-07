using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HPValues : MonoBehaviour
{
    public int playerHP;
    public int enemyHP;
    public int playerMaxHP;
    public int enemyMaxHP;
    public TextMeshProUGUI playerHPNum;
    public TextMeshProUGUI enemyHPNum;
    public TextMeshProUGUI vulnerableText;
    
    TurnSystem TurnSystem;


    // Start is called before the first frame update
    void Start()
    {
     playerHP = 30;
     enemyHP = 40;
     TurnSystem = FindObjectOfType<TurnSystem>();
     vulnerableText.enabled = false;
    }

    
    public void calculateBash() {   //calculates damage inflicted to player and enemy when enemy bashes
        enemyHP -= TurnSystem.totalAttack;
        int playerDamageRec = 10;
        if (TurnSystem.isVulnerable == true) {
            playerDamageRec = (int)(playerDamageRec * 1.5);
        }
        if (TurnSystem.totalDefend > 0) {
           playerDamageRec -= TurnSystem.totalDefend;
        }
            if (playerDamageRec > -1) {
                playerHP -= playerDamageRec;
                playerHPNum.text = playerHP.ToString();
            }

                enemyHPNum.text = enemyHP.ToString();
                TurnSystem.isVulnerable = false;
                vulnerableText.enabled = false;
    }

    public void calculateDefend() { // //calculates damage inflicted to player and enemy when enemy defends
        if (TurnSystem.totalAttack > 5) {
        enemyHP -= TurnSystem.totalAttack - 5;
            enemyHPNum.text = enemyHP.ToString();
        }
            TurnSystem.isVulnerable = false;
            vulnerableText.enabled = false;
            }
        
    
    // Update is called once per frame
    void Update()
    {
        if (enemyHP <= 0) {
            Debug.Log("You win!");
        } else if (playerHP <= 0) {
        Debug.Log("You lose :(");
    }
}
}

