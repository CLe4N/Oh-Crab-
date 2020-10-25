using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameExit : MonoBehaviour
{
    public void Game_Quit()
    {
        Debug.Log("Good bye");
        Application.Quit();
    }
}
