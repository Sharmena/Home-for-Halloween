using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;


public class TurnSystem : MonoBehaviour
{
    public bool isYourTurn;
    public bool isVulnerable;
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
       attackValueText.enabled = false;
       blockValueText.enabled = false;

       if(startWithTutorial == true) {
        tutorial();
       } else {
        endTutorial();
       }
       
       
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
                    isVulnerable = false;
                    HPValues.vulnerableText.enabled = false;
                }
          }  else {
          WizCalculateDamage();
          AICards.WizardPickMove();
          }
          Debug.Log("This is a test");
        totalAttack = 0;
        totalDefend = 0;
        //playerAnimation.enabled = false;
       // opponentAnimation.enabled = true;      
        Invoke(nameof(EndOpponentTurn), 3);
       
    }

    public void calculateDamageWithVulnerable() {
        if (AICards.Bash == true) { //calculate damage applied if bash
            HPValues.calculateBash();
        } else if (AICards.Defend == true) { 
            HPValues.calculateDefend(); //calculate damage applied if defend
        }
            if(AICards.Bash == true) {
                isVulnerable = true;
                HPValues.vulnerableText.enabled = true;
            }

    }

    public void WizCalculateDamage() {
        if (AICards.Bash == true) { //calculate damage applied if bash
            HPValues.calculateBash();
        } else if (AICards.Defend == true) { 
            HPValues.calculateDefend(); //calculate damage applied if defend
        } else if (AICards.Heal == true) {
            HPValues.calculateHeal();
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

    public void playerWins() { 
        playerHasWon = true;
        SceneManager.LoadScene(sceneName:"NewCardScene");
    }

    public void opponentWins() {
        opponentHasWon = true;
        //TBA
    }

}
