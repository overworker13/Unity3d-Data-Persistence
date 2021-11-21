using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using System.IO;
using TMPro;
using UnityEngine.UI;

public class MenuUi : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI topPlayer;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        topPlayer.text = "Top Player: " + MainManager.Instance.topPlayerName + " has " + MainManager.Instance.topScore;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else 
Application.Quit();

#endif
    }
}
