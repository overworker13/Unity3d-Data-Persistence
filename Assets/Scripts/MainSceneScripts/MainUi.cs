using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class MainUi : MonoBehaviour
{
    [SerializeField] private TMP_InputField playerName;
    [SerializeField] private TextMeshProUGUI bestScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        bestScoreText.text = "BestScore: " + MainManager.Instance.topPlayerName + " has " + MainManager.Instance.topScore;
    }
    public void Save()
    {
        MainManager.Instance.SaveTopPlayerScore();
    }
    public void GetName()
    {
        MainManager.Instance.topPlayerName = playerName.text;
    }
    
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
