using UnityEngine;
using Fluent;

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
        FluentManager.Instance.ExecuteClosestAction(gameObject);
    } 
}
