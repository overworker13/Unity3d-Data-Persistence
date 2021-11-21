using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public float ballSpeed;
    private Vector3 moveVector;
    private const float moveVectorX = 0;
    [SerializeField] private float moveVectorY = 1;
    [SerializeField] private float moveVectorZ = 0;
    private PlayerController playerControllerScript;
    private GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    private void Update()
    {
        moveVector = new Vector3(moveVectorX, moveVectorY, moveVectorZ);
        BallMove();
    }

    private void BallMove()
    {
        transform.Translate(moveVector * Time.deltaTime * ballSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            moveVectorY = 1;
            moveVectorZ = playerControllerScript.horizontalInput;
        }
        if (collision.gameObject.CompareTag("Brick"))
        {
            moveVectorY = -moveVectorY;
            moveVectorZ = -moveVectorZ;
        }
        if (collision.gameObject.CompareTag("TopBorder"))
        {
            moveVectorY = -1;
        }
        if (collision.gameObject.CompareTag("RightBorder"))
        {
            moveVectorZ = 1;
        }
        if (collision.gameObject.CompareTag("LeftBorder"))
        {
            moveVectorZ = -1;
        }
        if (collision.gameObject.CompareTag("BottomBorder"))
        {
            gameManagerScript.gameOver = true;
            Destroy(gameObject);
        }
    }
}
