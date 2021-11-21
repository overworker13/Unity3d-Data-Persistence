using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    public float horizontalInput;
    private float zBorder1 = 17;
    private float zBorder2 = 27;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        if (gameManagerScript.gameOver == false)
        {
            horizontalInput = Input.GetAxis("Horizontal");

            transform.Translate(Vector3.forward * Time.deltaTime * horizontalInput * speed);

            if (transform.position.z > zBorder1)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, zBorder1);
            }
            if (transform.position.z < -zBorder2)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, -zBorder2);
            }
        }
        
    }
}
