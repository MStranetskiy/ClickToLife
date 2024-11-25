using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class Data : MonoBehaviour
{
    public GameObject dataTxt;
    public int currentDay=1;
    public int currentMonth=1;
    public int currentYear=2000;
    public float DurationDay;
    public float counterSec = 0;

    public float speedTime = 0;

    public GameObject buttonHappy;
    public Sprite HappyMax;
    public Sprite HappyMidle;
    public Sprite HappyLow;

    public GameObject happyText;

    public Life life= new Life(); 
    public ConnectDB ConnectDB;
    
    private Dictionary<int, string> txtMonth = new Dictionary<int, string>()
    {
    { 1, "Январь"},
    { 2, "Февраль"},
    { 3, "Март"},
    { 4, "Апрель"},
    { 5, "Май"},
    { 6, "Июнь"},
    { 7, "Июль"},
    { 8, "Август"},
    { 9, "Сентябрь"},
    { 10, "Октябрь"},
    { 11, "Ноябрь"},
    { 12, "Декабрь"}
};

    void Start()
   
    {
        
        DrawTime();
    }

    void Update()
    {
        MoveTime();     
        HappyControler(); 
    }

public void CheckAvailabilityCard()
{

    foreach (var instansCard in GameDate.instansCard)
    {
       if (GameDate.purchasedCards.Any(p=>p == instansCard.CardConfig))
            continue;

        if (GameDate.CheckConditional(instansCard.CardConfig).Count>0)
            continue;
        
        
        if(GameDate.CheckPrice(instansCard.CardConfig).Count>0)
        {
          instansCard.GameObjectCard.GetComponent<Card>().DrawPrice();
        }
        else
        {
         instansCard.GameObjectCard.GetComponent<Card>().RemovePrice();
        }
    }
}
    private void HappyControler()
    {
        var currensyHappy=  GameDate.AllCurrensy
        .First(t=>t.CurrencyType == GameDate.TypeCurrensy.CurrensyHappy).CurrencyCount;

        switch (currensyHappy)
        {
            case >=70 and <= 100:
            GameDate.HappyStatus="Счастлив";
            GameDate.HappyColor= new Color(1f,0.9044871f,0f);
                break;

            case >30 and <70:
             GameDate.HappyStatus="Грустный";
             GameDate.HappyColor= new Color(1f,0.5f,0f);
                break;

            case <=30 and > 0:
             GameDate.HappyStatus="Несчастен";
             GameDate.HappyColor= new Color(0f,0f,0f);
                break;

            case > 100:
             GameDate.HappyStatus="Эйфория";
                break;

            case < 0:
             GameDate.HappyStatus="Несчастен";
                break;
        
        }

    }


     private void MoveTime()
    {

        counterSec += speedTime * Time.deltaTime;

        if (counterSec >= DurationDay)
        {
            counterSec=0;
            currentDay++;
            GameDate.lived ++;
            GameDate.livedTo--;

            if (GameDate.CheckToLife() == false)
            {
                life.SetGameOverPrefab();
                ConnectDB.AddRequest();
                ConnectDB.SelectRequest();
                speedTime = 0;
            }
            
            if (currentDay == 30)
            {   
                    currentDay = 1;
                    currentMonth++;
            }

            if(currentMonth == 12) 
            {
                currentMonth=1;
                currentYear++;
                GameDate.AllCurrensy
                .First(t=>t.CurrencyType == GameDate.TypeCurrensy.CurrensyHappy).CurrencyCount -= 15;
                GameDate.CurrensyLivingCost *= 2;
            }
           
            DrawTime();
            CheckAvailabilityCard();
        }
    }

    public void DrawTime()
    {
        var drawDataTxt = currentDay.ToString() + " " + txtMonth[currentMonth] + " " + currentYear.ToString();
        dataTxt.GetComponent<Text>().text = drawDataTxt;
    }

public void PauseButton()
{
    speedTime = 0;
}

public void PlayButton()
{
    speedTime = 1;
}

public void RewindButton()
{
    speedTime = 100;
}

}

