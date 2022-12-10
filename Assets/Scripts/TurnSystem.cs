using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public bool PlayerIsVulnerable;
    public bool OpponentIsVulnerable;
    public bool playerSelectedVulnerable; //player selected a card with vulnerability
    public bool startWithTutorial;

    public int yourTurn;
    public int opponentTurn;
    public Text turnText;
    public int maxMana;
    public int totalAttack;
    public int totalDefend;

    public Animator playerAnimation;
    public Animator opponentAnimation;


    public bool playerHasWon;
    public bool opponentHasWon;

    public int currentMana;

    public GameObject endTurnButton;

	public GameObject endTutorialButton;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI attackValueText;
    public TextMeshProUGUI blockValueText;
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
        startGame();
        
       isYourTurn = true;
       yourTurn = 1;
       opponentTurn = 0;

    

       playerHasWon = false;
       opponentHasWon = false;

       playerAnimation.enabled = true;
       opponentAnimation.enabled = false;

       maxMana = 3;
       currentMana = 3; 
       AICards = FindObjectOfType<AICards>();
       HPValues = FindObjectOfType<HPValues>();
       gm = FindObjectOfType<GameManager>();
       
   



		
    }

    // Update is called once per frame
    void Update()
    {
        if(isYourTurn == true) {
            turnText.text = "Your Turn";
        } else turnText.text = "Opponent Turn";
    }

        //starts game with or without tutorial. This is called in Start() of HPValues
    public void startGame() {
        attackValueText.enabled = false;
       blockValueText.enabled = false;
       if(startWithTutorial == true) {
        tutorial();
       } else {
            endTutorial();
        }
    }
    public void tutorial() {
        endTurnButton.SetActive(false);
        Debug.Log("From the tutorial");
		tutorialText.enabled = true;
            if (AICards.Bash == true) {
		tutorialText.text = ("The enemy uses " + "<color=red>Attack: 10HP + Vulnerability. </color>" + "Counter their move by selecting cards, then press End Turn. The blue SE bar determines how many cards you can play. <b>Cards are played <i>immediately</i> upon clicking</b> ");
            } else {
        tutorialText.text = ("The enemy uses " + "<color=green>Defend: 5HP. </color>" + "Counter their move by selecting cards, then press End Turn. The blue SE bar determines how many cards you can play. <b>Cards are played <i>immediately</i> upon clicking</b> ");
            }

	}

	public void endTutorial() {
		tutorialText.enabled = false;
		endTutorialButton.SetActive(false);
        endTurnButton.SetActive(true);
        gm.DrawMaxCards();
        
	}

    public void updateActionBox() {
        attackValueText.text = ("Attacking for: " + totalAttack.ToString() + " HP");
        blockValueText.text = ("Blocking for: " + totalDefend.ToString() + " HP");
        attackValueText.enabled = true;
        blockValueText.enabled = true;
    }

    public void clearActionBox() {
        attackValueText.enabled = false;
        blockValueText.enabled = false;
        attackValueText.text = ("");
        blockValueText.text = ("");
    }

    public void EndYourTurn(){
        isYourTurn = false;
        opponentTurn +=1;
        endTurnButton.SetActive(false);
        clearActionBox();
        

        if (AICards.OpponentName == "Scar") { 
            calculateDamageWithVulnerable();
            AICards.ScarPickMove();
                if(AICards.Defend == true) {
                    PlayerIsVulnerable = false;
                    HPValues.vulnerableText.enabled = false;
                }
          }  else {
          WizCalculateDamage();
          AICards.WizardPickMove();
          }
        totalAttack = 0;
        totalDefend = 0;
        playerSelectedVulnerable = false;
        //playerAnimation.enabled = false;
       // opponentAnimation.enabled = true;      
        Invoke(nameof(EndOpponentTurn), 3);
       
    }

    public void calculateDamageWithVulnerable() {
        if (AICards.Bash == true) { //calculate damage applied if AI bash
            HPValues.calculateBash();
        } else if (AICards.Defend == true) { 
            HPValues.calculateDefend(); //calculate damage applied if AI defend
        }
            if(AICards.Bash == true) { 
                PlayerIsVulnerable = true;
                HPValues.vulnerableText.enabled = true;
            }

    }

    public void WizCalculateDamage() {
        if (AICards.Bash == true) { //calculate damage applied if AI bash
            HPValues.calculateBash();
        } else if (AICards.Defend == true) { 
            HPValues.calculateDefend(); //calculate damage applied if AI defend
        } else if (AICards.Heal == true) { //calculate damage applied if AI heal
            HPValues.calculateHeal();
        }
        if (playerSelectedVulnerable == true) {
            OpponentIsVulnerable = true;
        }
        if (OpponentIsVulnerable == true) {
            HPValues.EnemyVulnerableText.enabled = true;
        }
    }

    public void EndOpponentTurn() {
        isYourTurn = true;
        yourTurn +=1;
        endTurnButton.SetActive(true);
        currentMana = 3;
        Debug.Log("This is a test END OPPONENT");
        updateSEBar();
        gm.Shuffle();
        gm.DrawMaxCards();
        playerAnimation.enabled = true;
        opponentAnimation.enabled = false;    
        Debug.Log("IS vulernable: " + PlayerIsVulnerable);
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

    public void playerWins() { 
        playerHasWon = true;
        SceneManager.LoadScene(sceneName:"NewCardScene");
    }

    public void opponentWins() {
        opponentHasWon = true;
        //TBA
    }

}
