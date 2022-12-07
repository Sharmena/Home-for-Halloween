using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public class Card : MonoBehaviour
{
	public bool hasBeenPlayed;
	public int handIndex;


    GameManager gm;
	TurnSystem TurnSystem;

	private Animator anim;
	private Animator camAnim;

	public GameObject effect;
	public GameObject hollowCircle;

	

	public int id;
	public string cardName;
	public int cost;
	public int power;
	public string cardDescription;

	void Start()
    {
        gm = FindObjectOfType<GameManager>();
		anim = GetComponent<Animator>();
		camAnim = Camera.main.GetComponent<Animator>();
		TurnSystem = FindObjectOfType<TurnSystem>();

		//totalAttack = 0;
		//totalDefend = 0;
    }

	public Card(int Id, string CardName, int Cost, int Power, string cardDescriptionText)
	{
		id = Id;
		cardName = CardName;
		cost = Cost;
		power = Power;
		cardDescription = cardDescriptionText;
	}

	
	private void OnMouseDown()
	{
		if (!hasBeenPlayed)
			if (TurnSystem.isYourTurn == true) 
				if (TurnSystem.currentMana > 0)
					if(gm.tutorialText.enabled == false)
		{
			{
				{
					{
			Instantiate(hollowCircle, transform.position, Quaternion.identity);
			
			camAnim.SetTrigger("shake");
			anim.SetTrigger("move");

			transform.position += Vector3.up * 3f;
			hasBeenPlayed = true;
			TurnSystem.currentMana -= this.cost;
			TurnSystem.updateSEBar();
				if (this.id == 0) {
					TurnSystem.totalAttack += this.power;
					}	else {
					TurnSystem.totalDefend += this.power;
						}
			Debug.Log("Total Attack is" + TurnSystem.totalAttack);
			Debug.Log("Total Defend is" + TurnSystem.totalDefend);
			gm.availableCardSlots[handIndex] = true;
			Invoke("MoveToDiscardPile", 2f);
			}
			}
			}
			
		}
	}

	void MoveToDiscardPile()
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		gm.discardPile.Add(this);
		gameObject.SetActive(false);
	  
	}

	
}