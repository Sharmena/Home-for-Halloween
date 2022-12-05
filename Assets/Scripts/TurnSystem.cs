using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public int yourTurn;
    public int opponentTurn;
    public Text turnText;

    public int maxMana;
    public int currentMana;



    // Start is called before the first frame update
    void Start()
    {
       isYourTurn = true;
       yourTurn = 1;
       opponentTurn = 0;

       maxMana = 3;
       currentMana = 3; 
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true) {
            turnText.text = "Your Turn";
        } else turnText.text = "Opponent Turn";
    }

    public void EndYourTurn(){
        isYourTurn = false;
        opponentTurn +=1;
    }

    public void EndOpponentTurn() {
        isYourTurn = true;
        yourTurn +=1;

        currentMana = 3;
    }

}
