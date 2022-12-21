using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AICards : MonoBehaviour
{
    public TextMeshProUGUI enemyMoveText;
    
    public List<string> ScarEnemyMoves;
    public List<string> WizardEnemyMoves;
    
    public string randomMove;
    public string OpponentName;
    public bool Bash;
    public bool Defend;
    public bool Heal;
    public int BashValue;
    public int DefendValue;
    public int HealValue;
    public bool fireBall;
    public int fireBallValue;
    

    // Start is called before the first frame update
    void Start()
    {
        
        //add moves to movelist
       WizardEnemyMoves.Add("WizBash");
       WizardEnemyMoves.Add("WizDefend");
       WizardEnemyMoves.Add("WizHeal");
       WizardEnemyMoves.Add("fireBall");
       ScarEnemyMoves.Add("Bash"); 
       ScarEnemyMoves.Add("Defend");

       //determine opponent, pick move from their deck
       switch (OpponentName) {
            case "Scar":
            ScarPickMove();
                break;
            case "Wizard":
            WizardPickMove();
            break;
       }
    }
    

//randomly picks a move for Scar, set enemy move text box, set defend or bash to t/f
    
    public void ScarPickMove() {
        string randomMove = ScarEnemyMoves[Random.Range(0, ScarEnemyMoves.Count)];
        BashValue = 10;
        DefendValue = 5;
        switch (randomMove) {
            case "Bash":
            enemyMoveText.color = Color.red;
            enemyMoveText.text = "Attack: 10HP + Vulnerability";
            Defend = false;
            Bash = true;
            
                break;
            case "Defend":
            enemyMoveText.color = Color.green;
            enemyMoveText.text = "Defend: 5HP";   
            Bash = false;
            Defend = true;
                break;
        }
    }

//randomly picks a move for Scar, set enemy move text box, set defend, bash, or heal to t/f
    public void WizardPickMove() {
        string randomMove = WizardEnemyMoves[Random.Range(0, WizardEnemyMoves.Count)];
        BashValue = 15;
        DefendValue = 15;
        HealValue = 10;
        fireBallValue = 15;
        switch (randomMove) {
            case "WizBash":
            enemyMoveText.color = Color.red;
            enemyMoveText.text = "Attack: 15HP";
            Defend = false;
            Heal = false;
            fireBall = false;
            Bash = true;
            
                break;
            case "WizDefend":
            enemyMoveText.color = Color.green;
            enemyMoveText.text = "Defend: 15HP";   
            Bash = false;
            Heal = false;
            fireBall = false;
            Defend = true;
                break;
            case "WizHeal":
            enemyMoveText.color = Color.green;
            enemyMoveText.text = "Heal: 10HP";   
            Bash = false;
            Defend = false;
            fireBall = false;
            Heal = true;
                break;   

            case "fireBall":
            enemyMoveText.color = Color.red;
            enemyMoveText.text = "Attack: 15 HP + Burn";
            Defend = false;
            Heal = false;
            Bash = false;
            fireBall = true;
                break; 
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
