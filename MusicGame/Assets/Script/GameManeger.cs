using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum MusicButton
{
    Up,
    Right,
    Left,
    Down
}

public enum MusicResult { 
    Perfect = 5,
    Good =3,
    bad = 1,
    Miss = -1
}

public class GameManeger : MonoBehaviour
{

    [SerializeField] Canvas canvas;
    [SerializeField] GameObject ButtonPrefeb;

    Vector3 initialPosition;
    GameObject startPanel;
    GameObject gamimgPanel;
    AudioManager player;

    static GameManeger instance;

    int score;
    public static float Endz = -70f;
    public static float End_Dis = 0f;

    private void Start()
    {
        score = 0;

        startPanel = canvas.transform.Find("StartPanel").gameObject;
        gamimgPanel = canvas.transform.Find("GamimgPanel").gameObject;
        instance = this;
        initialPosition = new Vector3(0.92f, 0.5f, 73f);
       
    }

    public void startgame() {
        Debug.Log("pressed.");
        startPanel.SetActive(false);
        gamimgPanel.SetActive(true);

        player = this.GetComponent<AudioManager>();

        player.Play(0f);
        
    }

    public static void CreateButton(MusicButton type) {
        var button = Instantiate(instance.ButtonPrefeb);
        button.tag = type.ToString();

        switch (type) {
            case MusicButton.Up:
                instance.initialPosition.x = 0.92f;
                break;
                
            case MusicButton.Right:
                instance.initialPosition.x = 10.8f;
                //Debug.Log(2);
                break;
                
            case MusicButton.Left:
                instance.initialPosition.x = 22.63f;
                //Debug.Log(3);
                break;

            case MusicButton.Down:
                instance.initialPosition.x = 34.1f;
                //Debug.Log(4);
                break;
        }
        button.transform.position = instance.initialPosition;
    }

    public static void UpdateScore(MusicResult type) {
        instance.score += (int)type;
        instance.gamimgPanel.GetComponentInChildren<Text>().text = "Score: " + instance.score;
    }
}
