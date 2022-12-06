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
		{
			Instantiate(hollowCircle, transform.position, Quaternion.identity);
			
			camAnim.SetTrigger("shake");
			anim.SetTrigger("move");

			transform.position += Vector3.up * 3f;
			hasBeenPlayed = true;
			gm.availableCardSlots[handIndex] = true;
			Invoke("MoveToDiscardPile", 2f);

			
		}
	}

	void MoveToDiscardPile()
	{
		Instantiate(effect, transform.position, Quaternion.identity);
		gm.discardPile.Add(this);
		gameObject.SetActive(false);
	}
	
	
}
