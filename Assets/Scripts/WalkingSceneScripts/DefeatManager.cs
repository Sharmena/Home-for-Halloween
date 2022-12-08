using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefeatManager : MonoBehaviour
{
    public bool scarDefeat;
    public bool devilDefeat;
    public bool wizardDefeat;
    public bool cowboyDefeat;

    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
