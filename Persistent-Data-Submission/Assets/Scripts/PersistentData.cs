using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentData : MonoBehaviour
{
    public static PersistentData PD;
    public List<Score> ScoreBoard = new List<Score>();
    public int Pontos;
    // Start is called before the first frame update
    void Start()
    {
        if (PD != null)
        {
            Destroy(this);
            return;
        }
        PD = this;
        DontDestroyOnLoad(gameObject);

        ScoreBoard.Add(new Score { Name = "Carlos", Points = 12 });
    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Serializable]
    public class Score
    {
        public string Name;
        public float Points;
    }
    public class SavedScores
    {
        List<Score> ScoreBoard = new List<Score>();
    }
    public void SaveScore()
    {

    }
}
