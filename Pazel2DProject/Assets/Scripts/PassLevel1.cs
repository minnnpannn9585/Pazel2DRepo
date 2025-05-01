using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PassLevel1 : MonoBehaviour
{
    public int score = 0;
    
    private void Update()
    {
        if (score == 2)
        {
            SceneManager.LoadScene("Level2");
        }
    }
}
