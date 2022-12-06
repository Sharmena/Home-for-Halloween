using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AICards : MonoBehaviour
{
    public TextMeshProUGUI enemyMoveText;
    public List<string> enemyMoves;

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
            enemyMoveText.text = "Attack: 10HP";
                break;
            case "Defend":
            enemyMoveText.text = "Defend: 5HP";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
