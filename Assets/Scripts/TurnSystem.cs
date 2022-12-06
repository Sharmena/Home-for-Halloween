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

    public GameObject endTurnButton;
    public AICards AICards;



    // Start is called before the first frame update
    void Start()
    {
       isYourTurn = true;
       yourTurn = 1;
       opponentTurn = 0;

       maxMana = 3;
       currentMana = 3; 
       AICards = FindObjectOfType<AICards>();
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
        endTurnButton.SetActive(false);
        AICards.pickMove();
        Invoke(nameof(EndOpponentTurn), 2);
       
    }

    public void EndOpponentTurn() {
        isYourTurn = true;
        yourTurn +=1;
        endTurnButton.SetActive(true);
        currentMana = 3;
    }

}
