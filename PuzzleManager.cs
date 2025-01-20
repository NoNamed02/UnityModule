using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public enum Puzzle
    {
        Puzzle_Test,
    }
    public bool[] clearPuzzles;
    void Awake()
    {
        
    }
    public void ClearPuzzle(Puzzle puzzleName)
    {
        clearPuzzles[(int)puzzleName] = true;
    }

    public int GetClearPuzzleCount()
    {
        int count = 0;
        foreach (var puzzle in clearPuzzles)
            if (puzzle == true) count++;
        return count;
    }

    public float CountPercent()
    {
        int trueCount = clearPuzzles.Count(b => b);
        float percentage = (float)trueCount / clearPuzzles.Length * 100;
        Debug.Log($"True percentage: {percentage:F2}%");
        return percentage;
    }
}
