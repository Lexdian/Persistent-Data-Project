using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUiControler : MonoBehaviour
{
    public TMP_InputField InpF;
    public GameObject GameOver;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Return()
    {
        SceneManager.LoadScene(0);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
    public void ScoreBoard()
    {
        SceneManager.LoadScene(2);
    }
    public void Quit()
    {
        PersistentData.PD.Save();
        Application.Quit();
    }
    public void NewScore(GameObject palyer)
    {
        PersistentData.PD.AddNewScore(InpF.text, palyer.GetComponent<PlayerControler>().Pontos);
        ScoreBoard();
    }
    public void Show()
    {
        GameOver.SetActive(true);
        InpF.characterLimit = 3;
        InpF.characterValidation = TMP_InputField.CharacterValidation.Alphanumeric;
        InpF.Select();
    }
}
