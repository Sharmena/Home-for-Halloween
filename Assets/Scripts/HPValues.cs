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
    public TextMeshProUGUI EnemyVulnerableText;
    
    TurnSystem TurnSystem;
    AICards AICards;


    // Start is called before the first frame update
    void Start()
    {
        //initializes player and enemy HP value
     
     TurnSystem = FindObjectOfType<TurnSystem>();
     AICards = FindObjectOfType<AICards>();
     vulnerableText.enabled = false;
     EnemyVulnerableText.enabled = false;
    // TurnSystem.startGame();
    }

    
    public void calculateBash() {   //calculates damage inflicted to player and enemy when enemy bashes
        
        if (TurnSystem.OpponentIsVulnerable == true) { 
            TurnSystem.totalAttack = (int)(TurnSystem.totalAttack * 1.5);
        }
        
        enemyHP -= TurnSystem.totalAttack;
        int playerDamageRec = AICards.BashValue;
        if (TurnSystem.PlayerIsVulnerable == true) {
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
                TurnSystem.PlayerIsVulnerable = false;
                vulnerableText.enabled = false;

                TurnSystem.OpponentIsVulnerable = false;
                EnemyVulnerableText.enabled = false;
    }



    public void calculateDefend() { // //calculates damage inflicted to player and enemy when enemy defends
        
        if (TurnSystem.OpponentIsVulnerable == true) { 
            TurnSystem.totalAttack = (int)(TurnSystem.totalAttack * 1.5);
        }

        if (TurnSystem.totalAttack > AICards.DefendValue) {
        enemyHP -= TurnSystem.totalAttack - AICards.DefendValue;
            enemyHPNum.text = enemyHP.ToString();
        }
            TurnSystem.PlayerIsVulnerable = false;
            vulnerableText.enabled = false;

            TurnSystem.OpponentIsVulnerable = false;
                EnemyVulnerableText.enabled = false;
            }

    
    public void calculateHeal() {

        if (TurnSystem.OpponentIsVulnerable == true) { 
            TurnSystem.totalAttack = (int)(TurnSystem.totalAttack * 1.5);
        }

        int healAmt = AICards.HealValue - TurnSystem.totalAttack;
        if (healAmt > -1) {
            enemyHP += healAmt;
        } else
            enemyHP -= TurnSystem.totalAttack - AICards.HealValue;
        enemyHPNum.text = enemyHP.ToString();

        TurnSystem.OpponentIsVulnerable = false;
                EnemyVulnerableText.enabled = false;
    }
        
    
    // Update is called once per frame
    void Update()
    {
        //track if someone has won
        if (enemyHP <= 0) { //if player wins
            TurnSystem.playerWins();
            Debug.Log("You win!");
        } else if (playerHP <= 0) { //if enemy wins
        TurnSystem.opponentWins();
        Debug.Log("You lose :(");
    }
}
}

