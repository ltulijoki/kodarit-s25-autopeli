using UnityEngine;

public class PlayerLoopCheck : MonoBehaviour
{
    public int checkPointCount = 13;

    private bool[] visited;

    private int visitedCount;

    void Awake()
    {
        ResetLap();
    }

    public void ResetLap()
    {
        visited = new bool[checkPointCount];
        visitedCount = 0;
    }

    public void MarkVisited(int index)
    {
        if (!visited[index])
        {
            visited[index] = true;
            visitedCount++;
        }
    }

    public bool AllVisitedThisLap => visitedCount == checkPointCount;
}
