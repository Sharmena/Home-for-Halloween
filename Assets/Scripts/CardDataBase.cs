using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardDataBase : MonoBehaviour
{
    public static List<Card> cardList;

    void Awake ()
    {
        cardList.Add (new Card (0, "Cheer", 1, 6, "Deal 6 Happiness"));
        cardList.Add (new Card (1, "Persevere", 1, 5, "Block 5 Sadness"));
        cardList.Add (new Card (2, "BOO", 2, 10,"Deal 10 Happiness + Vulnerability"));
    }
}