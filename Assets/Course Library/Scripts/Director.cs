using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Director : MonoBehaviour
{
    //Comentário GitHub
    //private bool gameStart;
    private List<Bus> inimigos = new List<Bus>();
    private PlayerController player1;
    private PlayerController2 player2;
    private TextMeshProUGUI textPointsPlayer1;
    private TextMeshProUGUI textPointsPlayer2;
    private TextMeshProUGUI textVictoryPlayer;
    
    [SerializeField]
    public GameObject textPointPlayer1;
    [SerializeField] 
    private GameObject textPointPlayer2;
    [SerializeField]
    public GameObject gameTitle;
    [SerializeField]
    public GameObject gameUserIterface;
    [SerializeField]
    public GameObject textVictory;
    


    // Start is called before the first frame update
    void Start()
    {
        
        foreach (var bus in GameObject.FindObjectsOfType<Bus>())
        {
            inimigos.Add(bus);
        }

        player1 = GameObject.FindObjectOfType<PlayerController>();

        player2 = GameObject.FindObjectOfType<PlayerController2>();

        textPointsPlayer1 = textPointPlayer1.GetComponent<TextMeshProUGUI>();

        textPointsPlayer2 = textPointPlayer2.GetComponent<TextMeshProUGUI>();

        textVictoryPlayer = textVictory.GetComponent<TextMeshProUGUI>(); 

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            
            gameTitle.SetActive(false);

            gameUserIterface.SetActive(true);

            foreach (var bus in inimigos)
            {
                bus.SetStartEnemies(true);
            }

            player1.SetStartPlayer(true);

            player2.SetStartPlayer(true);

        }

        textPointsPlayer1.text = player1.GetPointsPlayer().ToString();

        textPointsPlayer2.text = player2.GetPointsPlayer().ToString();

        if(player1.GetCollision())
        {
            textVictoryPlayer.text = "Player1 Win!";

            textVictoryPlayer.enabled = true;

            player1.SetStartPlayer(false);

            player2.SetStartPlayer(false);

            foreach (var bus in inimigos)
            {
                bus.SetStartEnemies(false);
            }

        }

        if (player2.GetCollision())
        {
            textVictoryPlayer.text = "Player2 Win!";

            textVictoryPlayer.enabled = true;

            player1.SetStartPlayer(false);

            player2.SetStartPlayer(false);

            foreach (var bus in inimigos)
            {
                bus.SetStartEnemies(false);
            }

        }

        if(player1.GetPointsPlayer() == player2.GetPointsPlayer() && player1.GetPointsPlayer() != 0 && player2.GetPointsPlayer() !=0)
        {
            textVictoryPlayer.text = "Draw Game!";

            textVictoryPlayer.enabled = true;

            player1.SetStartPlayer(false);

            player2.SetStartPlayer(false);

            foreach (var bus in inimigos)
            {
                bus.SetStartEnemies(false);
            }
        }
    }
}
