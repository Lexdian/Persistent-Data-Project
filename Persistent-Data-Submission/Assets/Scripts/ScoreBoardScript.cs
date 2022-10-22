using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoardScript : MonoBehaviour
{
    public GameObject SCTemplate, Container;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < PersistentData.PD.ScoreBoard.Count; i++)
        {
            GameObject Ins = Instantiate(SCTemplate);
            Ins.transform.SetParent(Container.transform);
            Ins.transform.Find("Nome").GetComponent<TextMeshProUGUI>().text = PersistentData.PD.ScoreBoard[i].Name;
            Ins.transform.Find("Pontos").GetComponent<TextMeshProUGUI>().text = PersistentData.PD.ScoreBoard[i].Points.ToString();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
