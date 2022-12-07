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
    TurnSystem TurnSystem;


    // Start is called before the first frame update
    void Start()
    {
     playerHP = 30;
     enemyHP = 40;
     TurnSystem = FindObjectOfType<TurnSystem>();
    }

    public void calculateBash() {
        enemyHP -= TurnSystem.totalAttack;
        int playerDamageRec = 10;
        if (TurnSystem.totalDefend > 0) {
           playerDamageRec -= TurnSystem.totalDefend;
        }
            if (playerDamageRec > -1) {
                playerHP -= playerDamageRec;
                playerHPNum.text = playerHP.ToString();
            }

                enemyHPNum.text = enemyHP.ToString();
    }

    public void calculateDefend() {
        if (TurnSystem.totalAttack > 5) {
        enemyHP -= TurnSystem.totalAttack - 5;
            enemyHPNum.text = enemyHP.ToString();
        }
            }
        
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

