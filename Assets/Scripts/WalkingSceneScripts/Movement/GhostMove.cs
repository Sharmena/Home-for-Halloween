using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostMove : MonoBehaviour
{

    public float speed;
    private float x;
    public float playerInput;
    public bool defeated;

    // Start is called before the first frame update
    void Start()
    {
        defeated = false;
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
    }
}
