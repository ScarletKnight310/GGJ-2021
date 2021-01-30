using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int targetFPS = 165;

    void Start()
    {
        // Make the game run as fast as possible
        Application.targetFrameRate = targetFPS;
    }
}