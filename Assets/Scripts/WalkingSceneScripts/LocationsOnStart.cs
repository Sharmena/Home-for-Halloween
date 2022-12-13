using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocationsOnStart : MonoBehaviour
{

    public GameObject scar;
    public GameObject wizard;
    public GameObject devil;
    public GameObject cowboy;

    // Start is called before the first frame update
    void Start()
    {
        if (DefeatManager.scarDefeat == true && DefeatManager.scarFollowing)
        {
            scar.transform.position = new Vector3(-2.17f, -0.65f, 0f);
        } else if (DefeatManager.scarDefeat == true && DefeatManager.scarFollowing != true)
        {
            scar.transform.position = new Vector3(2.357f, -0.65f, 0f);
            scar.GetComponent<Animator>().Play("ScarFollow");
            DefeatManager.scarFollowing = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
