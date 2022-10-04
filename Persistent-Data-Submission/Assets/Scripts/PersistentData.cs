using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    }

    // Update is called once per frame
    void Update()
    {

    }
    [System.Serializable]
    public class Score
    {
        string Name;
        float Points;
    }
    public class SavedScores
    {
        List<Score> ScoreBoard = new List<Score>();
    }
    public void SaveScore()
    {

    }
}
