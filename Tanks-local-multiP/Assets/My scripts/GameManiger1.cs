using UnityEngine;

public class GameManiger1 : MonoBehaviour
{

    public static GameManager instance;


    public GameObject introCam;
    public int playerCount = 0;

    public Color player1;
    public Color player2;

    
    public void DisableInroCam()
    {
        introCam.SetActive(false);
    }
   
}
