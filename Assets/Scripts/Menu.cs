using System.Collections;

using System.Collections.Generic;

using UnityEngine;

using UnityEngine.SceneManagement;



public class Menu : MonoBehaviour

{



    SimpleGameManager GM;

    void Awake()

    {

        GM = SimpleGameManager.Instance;

        GM.OnStateChange += HandleOnStateChange;

        Debug.Log("CurrentGameState When Awake Boi: " + GM.gameState);

    }

    public void HandleOnStateChange()

    {

        Debug.Log("On State Change");

    }



    public void OnGUI()

    {

        GUI.BeginGroup(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 800));

        GUI.Box(new Rect(0, 0, 100, 100), "Menu");

        if (GUI.Button(new Rect(10, 40, 80, 30), "Start"))

        {

            StartGame();

        }

        if (GUI.Button(new Rect(10, 80, 80, 30), "Quit"))

        {

            Quit();

        }

        GUI.EndGroup();

    }

    public void StartGame()

    {

        GM.SetGameState(GameState.GAME);

        Debug.Log("Loading Game State: " + GM.gameState);

        SceneManager.LoadScene("GameScene");

    }

    public void Quit()

    {

        Debug.Log("Quit!");

        Application.Quit();

    }

}