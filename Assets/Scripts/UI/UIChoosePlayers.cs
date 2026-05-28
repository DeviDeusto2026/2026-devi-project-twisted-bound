using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIChoosePlayers : MonoBehaviour
{
    [Header("Texts")]
    [SerializeField] private TMP_Text p1Text;
    [SerializeField] private TMP_Text p2Text;

    [SerializeField] private string notReadyText;
    [SerializeField] private string readyText;

    [Header("Player 1 images")]
    [SerializeField] private Image p1Image;
    [SerializeField] private Sprite p1NotReady;
    [SerializeField] private Sprite p1Ready;
    
    [Header("Player 2 images")]
    [SerializeField] private Image p2Image;
    [SerializeField] private Sprite p2NotReady;
    [SerializeField] private Sprite p2Ready;

    [Header("Button panel")]
    [SerializeField] private GameObject buttonPanel;

    [Header("Player joiner manager")]
    [SerializeField] private PlayerJoinerManager joinerManager;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ChoosePlayers();   
    }



    private void ChoosePlayers()
    {
        StartCoroutine(StartPlayerChoose());
    }

    private IEnumerator StartPlayerChoose()
    {
        p1Text.text = "P1 " + notReadyText;
        p2Text.text = "P2 " + notReadyText;

        p1Image.sprite = p1NotReady;
        p2Image.sprite = p2NotReady;

        buttonPanel.SetActive(false);

        yield return new WaitUntil(() => joinerManager.player1Joined);

        p1Text.text = "P1 " + readyText;
        p1Image.sprite = p1Ready;


        yield return new WaitUntil(() => joinerManager.player2Joined);

        p2Text.text = "P2 " + readyText;
        p2Image.sprite = p2Ready;

        buttonPanel.SetActive(true);
    }


    public void StartGame()
    {
        //POner el timeSale a 1 --> IMPORTANTE hay que poner el timeScale a 0 al empezar

        //Mandar mensaje de empieza el juego (SendMessage o similares)



        UIManager.Instance.StartGame();
    }


    public void ResetPlayerChoose()
    {
        joinerManager.ResetPlayerJoiner();
        ChoosePlayers();
    }

}
