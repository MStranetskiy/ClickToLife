using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;


public class ScenaControler : MonoBehaviour
{
    public Text CurrencyCountTxt; 
    [NonSerialized] public GameDate.TypeCurrensy ScenaType= GameDate.TypeCurrensy.Life;
    [NonSerialized] public GameDate.TypeCurrensy ForcePress= GameDate.TypeCurrensy.ForcePressLife;
    [NonSerialized] public GameDate.TypeCurrensy MultiplePress= GameDate.TypeCurrensy.MultiplePressLife;

    public GameObject LeftButton,RightButton,CentrButton,CardsLife,CardsMoney,CardsHealth;
    public Image LeftButtonImage,RightButtonImage,CentrButtonImage,ScenaImage, CurrencyImage;
    public PlayerControler PlayerControler;
    public Data PlayerData;
    public Sprite LifeIco, HelthIco, MoneyIco, ScenaImageLife, ScenaImageHelth, ScenaImageMoney;
    [NonSerialized] int pozition =1;

     void Start()
    {
        DrawCurrentCurrency();
    }


     public void ClickCentrButton()
    {
      GameDate.AllCurrensy.First(t=>t.CurrencyType == ScenaType).CurrencyCount 
      += GameDate.GetCountCurrency(ForcePress) * GameDate.GetCountCurrency(MultiplePress);

      DrawCurrentCurrency();
      PlayerData.CheckAvailabilityCard();
    }        

      public void ChangeScena()
    {
      switch (pozition)
      {
        case 0:
        ScenaType= GameDate.TypeCurrensy.Money;
        CentrButtonImage.sprite = MoneyIco;
        LeftButton.SetActive(false);
        RightButtonImage.sprite = LifeIco;
        CurrencyImage.sprite= CentrButtonImage.sprite;
        CardsLife.SetActive(false);
        CardsMoney.SetActive(true);
        CardsHealth.SetActive(false);
        PlayerControler.player = CardsMoney.transform;
        ForcePress= GameDate.TypeCurrensy.ForcePressMoney;
        MultiplePress= GameDate.TypeCurrensy.MultiplePressMoney;
        ScenaImage.sprite = ScenaImageMoney;
        DrawCurrentCurrency();
        PlayerData.CheckAvailabilityCard();

        break;
        case 1:
        ScenaType= GameDate.TypeCurrensy.Life;
        RightButton.SetActive(true);
        LeftButton.SetActive(true);
        CentrButtonImage.sprite = LifeIco;
        LeftButtonImage.sprite = MoneyIco;
        RightButtonImage.sprite = HelthIco;
        CurrencyImage.sprite= CentrButtonImage.sprite;
        CardsLife.SetActive(true);
        CardsMoney.SetActive(false);
        CardsHealth.SetActive(false);
        PlayerControler.player = CardsLife.transform;
        ForcePress= GameDate.TypeCurrensy.ForcePressLife;
        MultiplePress= GameDate.TypeCurrensy.MultiplePressLife;
        ScenaImage.sprite = ScenaImageLife;
        DrawCurrentCurrency();
        PlayerData.CheckAvailabilityCard();

        break;
        case 2:
        ScenaType= GameDate.TypeCurrensy.Health;
        CentrButtonImage.sprite = HelthIco;
        RightButton.SetActive(false);
        LeftButtonImage.sprite = LifeIco;
        CurrencyImage.sprite= CentrButtonImage.sprite;
        CardsLife.SetActive(false);
        CardsMoney.SetActive(false);
        CardsHealth.SetActive(true);
        PlayerControler.player = CardsHealth.transform;
        ForcePress= GameDate.TypeCurrensy.ForcePressHealth;
        MultiplePress= GameDate.TypeCurrensy.MultiplePressHealth;
        ScenaImage.sprite = ScenaImageHelth;
        DrawCurrentCurrency();
        PlayerData.CheckAvailabilityCard();
        break;
      }
    }        
    public void ClickLeftButton()
    {
      if(pozition > 0)
      {
        pozition--;
        ChangeScena();
      }
    }
    public void ClickRightButton()
    {
      if(pozition < 2)
      {
        pozition++;
        ChangeScena();
      }
    }

    private void DrawCurrentCurrency()
    {
        CurrencyCountTxt.text =
        GameDate.GetCountCurrency(ScenaType).ToString();
    }
}
