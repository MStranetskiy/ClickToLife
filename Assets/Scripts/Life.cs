using UnityEngine;

public class Life : MonoBehaviour
{

     public  GameObject GameOver;


    void Start()
    {
        GameDate.livedTo += GameDate.livedToBonus;
    
    }


    public void SetGameOverPrefab()
    {
        GameOver.SetActive(true);
    }
}
