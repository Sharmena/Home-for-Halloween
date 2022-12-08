using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    public float speed;
    private float x;
    public float playerInput;
    public GameObject ghost;
    public DefeatManager defeatManager;
    public bool defeated;




    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        playerInput = Input.GetAxis("Horizontal");

        if (Player.Instance.CanMove == true && defeated == false)
        {
            x = transform.position.x;
            x += speed * Time.deltaTime * playerInput;
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        if (this.name == "ScarGhost")
        {
            defeated = defeatManager.scarDefeat;
        }
        if (this.name == "WizardGhost")
        {
            defeated = defeatManager.wizardDefeat;
        }
        if (this.name == "DevilGhost")
        {
            defeated = defeatManager.devilDefeat;
        }
        if (this.name == "CowboyGhost")
        {
            defeated = defeatManager.cowboyDefeat;
        }
    }
}
