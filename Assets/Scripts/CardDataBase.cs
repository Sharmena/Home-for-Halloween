using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList = new List<Card> ();

    void Awake ()
    {
        cardList.Add (new Card (0, "Cheer", 1, 6, "Deal 6 Happiness"));
        cardList.Add (new Card (1, "Persevere", 1, 5, "Block 5 Sadness"));
    }
}
