using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private GameManager gameManagerScritpt;
    [SerializeField] private int pointsForPunch;
    [SerializeField] private int bonusPointsForDestruction;
    [SerializeField] private float objectHealth;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScritpt = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (objectHealth > 0)
        {
            gameManagerScritpt.score += pointsForPunch;
            objectHealth--;
        }
        else
        {
            gameManagerScritpt.score += bonusPointsForDestruction;
            Destroy(gameObject);
        }
    }
}
