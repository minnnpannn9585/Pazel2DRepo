using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevel1 : MonoBehaviour
{
    public int score = 0;
    public int nextLevelIndex;
    private void Update()
    {
        if (score == 2)
        {
            SceneManager.LoadScene(nextLevelIndex);
        }
    }
}
