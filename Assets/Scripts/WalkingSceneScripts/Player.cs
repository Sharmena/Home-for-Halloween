using UnityEngine;
using Fluent;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    private float MoveSpeed = 0.0f;

    public bool CanMove = true;
    public static Player Instance;

    void Awake()
    {
        Instance = this;
    }

	void Start () 
    {
	}
	
	void Update () 
    {
        if (!CanMove)
            return;


        transform.position += new Vector3(-Input.GetAxis("Horizontal") * Time.deltaTime * MoveSpeed, 0, -Input.GetAxis("Vertical") * Time.deltaTime * MoveSpeed);
	
	}

   private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Collision with " + other.transform.parent.name);

        if ((other.transform.parent.name == "ScarGhost" && DefeatManager.scarDefeat != true))
        {
            Debug.Log("Made it to Scar Conversation");
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        } else if (other.transform.parent.name == "WizardGhost" && DefeatManager.wizardDefeat != true)
        {
            Debug.Log("Made it to Wizard Conversation");
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        }
        else if (other.transform.parent.name == "DevilGhost" && DefeatManager.devilDefeat != true)
        {
            Debug.Log("Made it to Devil Conversation");
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        }
        else if (other.transform.parent.name == "CowboyGhost" && DefeatManager.cowboyDefeat != true)
        {
            Debug.Log("Made it to Cowboy Conversation");
            FluentManager.Instance.ExecuteClosestAction(gameObject);
        }

    } 
}
