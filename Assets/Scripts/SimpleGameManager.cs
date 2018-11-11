using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;





public enum GameState { MAIN_MENU, GAME, EXIT }

public delegate void OnStateChangeHandler();

public class SimpleGameManager : MonoBehaviour

{
    public float speed;

    public Text countText;

    private bool Quest1 = false;

    private bool Quest2 = false;

    private bool Quest3 = false;

    private bool Quest4 = false;

    private bool Quest5 = false;

    private bool Quest6 = false;
    private Dictionary<string, bool> questStates = new Dictionary<string, bool>();

    public Dictionary<string, string> questDescriptions = new Dictionary<string, string>();
    protected SimpleGameManager()
    {

        questStates.Add("Dummie 1", false);

        questDescriptions.Add("Dummie 1", "Killed the red-haired brute holding an axe!");

        questStates.Add("Dummie 2", false);

        questDescriptions.Add("Dummie 2", "Smoked the little imp!");

        questStates.Add("Dummie 3", false);

        questDescriptions.Add("Dummie 3", "Annihilated the alien trooper!");

        questStates.Add("Dummie 4", false);

        questDescriptions.Add("Dummie 4", "BOI DOWN!");

        questStates.Add("Dummie 5", false);

        questDescriptions.Add("Dummie 5", "Good Shooting");
        
        questStates.Add("Dummie 6", false);

        questDescriptions.Add("Dummie 6", "Dummie Downed!");

        Debug.Log("Added Quests for Dummie 1, Dummie 2, Dummie 3, and the rest.");

    }
    void SetCountText ()
    {
        int count = 0;
        foreach(bool quest in questStates.Values){
            if (quest){
                count ++;
            }
        }
        countText.text = "Kills: " + count.ToString();
    }
    

    private static SimpleGameManager instance = null;

    public event OnStateChangeHandler OnStateChange;

    public GameState gameState { get; private set; }

    public static SimpleGameManager Instance

    {

        get

        {

            if (SimpleGameManager.instance == null)

            {

                SimpleGameManager.instance = FindObjectOfType<SimpleGameManager>();

                if (SimpleGameManager.instance == null)
                {

                    GameObject go = new GameObject();

                    go.name = "SimpleGameManager";

                    SimpleGameManager.instance = go.AddComponent<SimpleGameManager>();

                    DontDestroyOnLoad(go);

                }

            }

            return SimpleGameManager.instance;

        }



    }

    void Awake()

    {

        if (instance == null)
        {

            instance = this;

            DontDestroyOnLoad(this.gameObject);

        }
        else
        {
            Destroy(gameObject);
        }

    }

    public void SetGameState(GameState state)

    {

        this.gameState = state;

        OnStateChange();

    }

    public void OnApplicationQuit()

    {

        SimpleGameManager.instance = null;

    }

    public void FinishQuest(string questName)
    {

        Debug.Log("Finishing Quest for " + questName);

        if (questStates.ContainsKey(questName))
        {

            questStates[questName] = true;
            

        }
        if (AreQuestsFinished ()){
            OpenTheGate();
        }
        SetCountText();
    }



    public string GetQuestDescription(string questName)
    {

        string desc = "";

        questDescriptions.TryGetValue(questName, out desc);

        return desc;

    }

    public bool AreQuestsFinished()
    {


        return !questStates.ContainsValue(false);
    }

    void OpenTheGate()
    {

        GameObject[] gates;

        gates = GameObject.FindGameObjectsWithTag("EndWall");

        Debug.Log("Got " + gates.Length + " gates");

        foreach (GameObject gate in gates)

        {

            Destroy(gate);

        }

    }

}