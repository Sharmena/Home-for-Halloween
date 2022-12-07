using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

	public List<Card> deck;
	public TextMeshProUGUI deckSizeText;
	public TextMeshProUGUI tutorialText;
	public Transform[] cardSlots;
	public bool[] availableCardSlots;

	public List<Card> discardPile;
	public TextMeshProUGUI discardPileSizeText;
	public List<Card> allcards;

	private Animator camAnim;
	public int numCardsInHand;
	public int maxCardsInHand;
	public Card randomCard;

	private void Start()
	{
		camAnim = Camera.main.GetComponent<Animator>();
		maxCardsInHand = 5;
		numCardsInHand = 0;
		
	}

	
	
	public void DrawCard()
	{
		 
		if (deck.Count >= 1)
		{
			
			camAnim.SetTrigger("shake");
			Card randomCard = deck[Random.Range(0, deck.Count)];
			
			for (int i = 0; i < availableCardSlots.Length; i++)
			{
				
				if (availableCardSlots[i] == true)
				{
					Debug.Log("deck count " + deck.Count);
					randomCard.gameObject.SetActive(true);
					randomCard.handIndex = i;
					randomCard.transform.position = cardSlots[i].position;
					randomCard.hasBeenPlayed = false;
					deck.Remove(randomCard);
					availableCardSlots[i] = false;
					numCardsInHand++;
					return;
				}
			
			}
			
		} 
	}
	
	public void DrawMaxCards() {
		
		for(int i = numCardsInHand; i < maxCardsInHand; i++) {
			DrawCard();
		}
	}
	

	public void Shuffle()
	{
		if (discardPile.Count >= 1)
		{
			foreach (Card card in discardPile)
			{
				deck.Add(card);
			}
			discardPile.Clear();
		}
	}

	/* public void MoveToDiscardPile()
	{
		foreach (Card randomCard in deck) {
			if (hasBeenPlayed == true) {
		//Instantiate(effect, transform.position, Quaternion.identity);
		discardPile.Add(randomCard);
		randomCard.SetActive(false);
			}
		}
	} */

	private void Update()
	{
		deckSizeText.text = deck.Count.ToString();
		discardPileSizeText.text = discardPile.Count.ToString();
	}

}
