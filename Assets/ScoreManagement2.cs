using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[CreateAssetMenu (fileName = "new Score", menuName = "ScriptableObject/Score")]
public class ScoreManagement2 : ScriptableObject
{
    List<Score> scoreBoard = new List<Score>();

    public List<Score> ScoreBoard => scoreBoard;

    public void AddScore(int value)
    {
        int month = System.DateTime.Now.Month;
        int day = System.DateTime.Now.Day;
        int hours = System.DateTime.Now.Hour;
        int min = System.DateTime.Now.Minute;

        if (scoreBoard.Count == 0)
        {
            scoreBoard.Add(new Score(value, hours, min, month, day));
            return;
        }

        bool hasBeenAdded = false;
        for (int i = 0; i < scoreBoard.Count; i++)
        {
            if (scoreBoard[i].score < value)
            {
                scoreBoard.Insert(i, new Score(value, hours, min, month, day));
                hasBeenAdded = true;
            }
        }

        if (!hasBeenAdded)
        {
            scoreBoard.Add(new Score(value, hours, min, month, day));
        }

        if (scoreBoard.Count > 4)
        {
            scoreBoard.RemoveAt(4);
        }
    }

    public struct Score
    {
        public Score(int a, int b, int c, int d, int e)
        {
            score = a;
            hour = b;
            min = c;
            month = d;
            day = e;
        }

        public int score;
        public int hour;
        public int min;
        public int month;
        public int day;
    }
}
