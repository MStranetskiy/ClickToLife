using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class ScreenSetings : MonoBehaviour
{
    public int CountCardOnScreen;
    public float ScaleCard=1;
    public float distantopnSpawnCard;
    void Start()
    {
      if (Screen.width < 1000)
      {
        CountCardOnScreen=2;
        ScaleCard=1f;
        distantopnSpawnCard = 300;

      }
        if (Screen.width > 1000 && Screen.width < 1400)
      {
        CountCardOnScreen=2;
        ScaleCard=1f;
        distantopnSpawnCard = 500;

      }
        if (Screen.width > 1400)
      {
        CountCardOnScreen=2;
        ScaleCard=1f;
        distantopnSpawnCard = 600;

      }
      Debug.Log(Screen.width);

    }


}
