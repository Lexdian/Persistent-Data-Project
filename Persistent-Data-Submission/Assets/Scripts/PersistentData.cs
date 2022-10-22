using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PersistentData : MonoBehaviour
{
    public static PersistentData PD;
    public List<Score> ScoreBoard = new List<Score>();
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

        if (File.Exists(Application.persistentDataPath + "/Scores.json"))
        {
            Debug.Log("Existe");
            Load();
            Sort();
        }
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
    [System.Serializable]
    public class SavedScores
    {
        public List<Score> scores;
    }
    public void Save()
    {
        SavedScores ScoresToSave = new SavedScores{ scores = ScoreBoard };
        string save = JsonUtility.ToJson(ScoresToSave);
        File.WriteAllText(Application.persistentDataPath + "/Scores.json", save);
        Debug.Log("salvou");
    }
    public void Load()
    {
        SavedScores ScoresSaved = JsonUtility.FromJson<SavedScores>(File.ReadAllText(Application.persistentDataPath + "/Scores.json"));
        ScoreBoard = ScoresSaved.scores;
    }
    public void AddNewScore(string Name, int Points)
    {
        ScoreBoard.Add(new Score {Name = Name, Points = Points });
        Sort();
        if(ScoreBoard.Count > 5)
        {
            ScoreBoard.Remove(ScoreBoard[5]);
        }
    }
    public void Sort()
    {
            for (int i = 0; i < ScoreBoard.Count; i++)
            {
                for (int j = i + 1; j < ScoreBoard.Count; j++)
                {
                    if (ScoreBoard[j].Points > ScoreBoard[i].Points)
                    {
                        Score SC = ScoreBoard[i];
                        ScoreBoard[i] = ScoreBoard[j];
                        ScoreBoard[j] = SC;
                    }
                }
            }
    }
}
