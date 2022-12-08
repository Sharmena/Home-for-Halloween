using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AICards : MonoBehaviour
{
    public TextMeshProUGUI enemyMoveText;
    
    public List<string> enemyMoves;
    
    public string randomMove;
    public bool Bash;
    public bool Defend;
    

    // Start is called before the first frame update
    void Start()
    {
        //add moves to movelist, pick a move
       enemyMoves.Add("Bash"); 
       enemyMoves.Add("Defend");
       pickMove();
    }
    

//randomly picks a move, set enemy move text box, set defend or bash to t/f
    public void pickMove() {
        string randomMove = enemyMoves[Random.Range(0, enemyMoves.Count)];
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
