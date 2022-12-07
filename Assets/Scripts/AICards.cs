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
       enemyMoves.Add("Bash"); 
       enemyMoves.Add("Defend");
       pickMove();
    
    }

    public void pickMove() {
        string randomMove = enemyMoves[Random.Range(0, enemyMoves.Count)];
        switch (randomMove) {
            case "Bash":
            enemyMoveText.color = Color.red;
            enemyMoveText.text = "Attack: 10HP";
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
