using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public bool isVulnerable;
    public int yourTurn;
    public int opponentTurn;
    public Text turnText;
    public int maxMana;
    public int totalAttack;
    public int totalDefend;

    public int currentMana;

    public GameObject endTurnButton;

	public GameObject endTutorialButton;
    public TextMeshProUGUI tutorialText;
    public GameManager gm;
    public AICards AICards;
    public HPValues HPValues;
    
    public Image SEBarImage;
  
    public Sprite SEBar3;
	public Sprite SEBar2;
    public Sprite SEBar1;
    public Sprite SEBar0;




    // Start is called before the first frame update
    void Start()
    {
       isYourTurn = true;
       yourTurn = 1;
       opponentTurn = 0;

       maxMana = 3;
       currentMana = 3; 
       AICards = FindObjectOfType<AICards>();
       HPValues = FindObjectOfType<HPValues>();
       gm = FindObjectOfType<GameManager>();
       tutorial();
       //gm.DrawCard();


		
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true) {
            turnText.text = "Your Turn";
        } else turnText.text = "Opponent Turn";
    }

    public void tutorial() {
        endTurnButton.SetActive(false);
		tutorialText.enabled = true;
		tutorialText.text = ("The enemy uses " + AICards.enemyMoveText.text + ". " + "Counter their move by selecting cards, then press End Turn. The blue SE bar determines how many cards you can play. <b>Cards are played <i>immediately</i> upon clicking</b> ");
	}

	public void endTutorial() {
		tutorialText.enabled = false;
		endTutorialButton.SetActive(false);
        endTurnButton.SetActive(true);
        gm.DrawMaxCards();
	}

    public void EndYourTurn(){
        isYourTurn = false;
        opponentTurn +=1;
        endTurnButton.SetActive(false);
        if (AICards.Bash == true) {
            HPValues.calculateBash();
        } else { 
            HPValues.calculateDefend();
        }
            if(AICards.Bash == true) {
                isVulnerable = true;
                HPValues.vulnerableText.enabled = true;
            }
        AICards.pickMove();
            if(AICards.Defend == true) {
                isVulnerable = false;
                HPValues.vulnerableText.enabled = false;
            }
        totalAttack = 0;
        totalDefend = 0;      
        Invoke(nameof(EndOpponentTurn), 2);
       
    }

    public void EndOpponentTurn() {
        isYourTurn = true;
        yourTurn +=1;
        endTurnButton.SetActive(true);
        currentMana = 3;
        updateSEBar();
        gm.Shuffle();
        gm.DrawMaxCards();
        Debug.Log("IS vulernable: " + isVulnerable);
    }

    public void updateSEBar() {
        
        switch (currentMana) {
            case 0:
                SEBarImage.sprite = SEBar0;
                Debug.Log("there is" + currentMana + "mana");
                break;
            case 1:
                SEBarImage.sprite = SEBar1;

                Debug.Log("there is" + currentMana + "mana");
                break;

            case 2:
                SEBarImage.sprite = SEBar2;
 
                Debug.Log("there is" + currentMana + "mana");
                break;

            case 3:
                SEBarImage.sprite = SEBar3;

                break;
        }
    }

}
