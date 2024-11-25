using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using CardsNameSpace;


public static class GameDate
{
   public static int lived = 0;
   public static int livedTo = 0;
   public static int livedToBonus = 968;
   public static int CurrensyLivingCost = 10; // сложность жизни(покупка следующего дня)
   public static string HappyStatus;
   public static Color HappyColor;
   public static List<CardConfig> purchasedCards = new();
   public static List<InstansCard> instansCard = new();
   public static string PlayerName;

   public enum TypeCurrensy
   {
      Life,
      Money,
      Health,
      AccumulationLife,
      AccumulationMoney,
      AccumulationHealth,
      CurrensyHappy,
      ForcePressMoney,
      ForcePressLife,
      ForcePressHealth,
      MultiplePressMoney,
      MultiplePressLife,
      MultiplePressHealth
   }
   public static Currensy LifeCurrensy = new() { CurrencyType = TypeCurrensy.Life, CurrencyCount = 0, CurrencyName = "Цель", CurrencyPatchSprite = "Sprites/Currency/Life3", Special = true };
   public static Currensy HealthCurrensy = new() { CurrencyType = TypeCurrensy.Health, CurrencyCount = 0, CurrencyName = "Здоровье", CurrencyPatchSprite = "Sprites/Currency/Health", Special = true };
   public static Currensy MoneyCurrensy = new() { CurrencyType = TypeCurrensy.Money, CurrencyCount = 0, CurrencyName = "Деньги", CurrencyPatchSprite = "Sprites/Currency/Money", Special = true };
   public static Currensy DeltaDayLife = new() { CurrencyType = TypeCurrensy.Money, CurrencyCount = 0, CurrencyName = "Цели в день" };
   public static Currensy DeltaDayHealth = new() { CurrencyType = TypeCurrensy.Money, CurrencyCount = 0, CurrencyName = "Здоровье в день" };
   public static Currensy DeltaDayMoney = new() { CurrencyType = TypeCurrensy.Money, CurrencyCount = 0, CurrencyName = "Деьги в день" };
   public static Currensy ForcePressLife = new() { CurrencyType = TypeCurrensy.ForcePressLife, CurrencyCount = 1, CurrencyName = "Сила нажатия на кнопку Цели", CurrencyPatchSprite = "Sprites/Currency/ForcePress" };
   public static Currensy ForcePressHealth = new() { CurrencyType = TypeCurrensy.ForcePressHealth, CurrencyCount = 1, CurrencyName = "Сила нажатия на кнопку Здоровье" , CurrencyPatchSprite = "Sprites/Currency/ForcePress"  };
   public static Currensy ForcePressMoney = new() { CurrencyType = TypeCurrensy.ForcePressMoney, CurrencyCount = 1, CurrencyName = "Сила нажатия на кнопку Деньги" , CurrencyPatchSprite = "Sprites/Currency/ForcePress" };
   public static Currensy MultiplePressLife = new() { CurrencyType = TypeCurrensy.MultiplePressLife, CurrencyCount = 1, CurrencyName = "Множетель нажатия на кнопку Цель" ,CurrencyPatchSprite = "Sprites/Currency/MultiplePress." };
   public static Currensy MultiplePressHealth = new() { CurrencyType = TypeCurrensy.MultiplePressHealth, CurrencyCount = 1, CurrencyName = "Множетель нажатия на кнопку Здоровье",CurrencyPatchSprite = "Sprites/Currency/MultiplePress."};
   public static Currensy MultiplePressMoney = new() { CurrencyType = TypeCurrensy.MultiplePressMoney, CurrencyCount = 1, CurrencyName = "Множетель нажатия на кнопку Деньги" ,CurrencyPatchSprite = "Sprites/Currency/MultiplePress."};
   public static Currensy HappyCurrensy = new() { CurrencyType = TypeCurrensy.CurrensyHappy, CurrencyCount = 100, CurrencyName = "Счастье", CurrencyPatchSprite = "Sprites/Currency/CurrensyHappy" };
   public static List<Currensy> AllCurrensy = new() {LifeCurrensy,HealthCurrensy,MoneyCurrensy,DeltaDayLife,DeltaDayHealth,DeltaDayMoney,
   ForcePressLife,ForcePressHealth,ForcePressMoney,MultiplePressLife,MultiplePressHealth,MultiplePressMoney,HappyCurrensy};

   public static bool CheckToLife()
   {
      if (livedTo <= 0)
      {
         return false;
      }

      return true;
   }

   public static string GetNameCurrency(TypeCurrensy Type)
   {
      return AllCurrensy.First(type => type.CurrencyType == Type).CurrencyName;
   }

   public static float GetCountCurrency(TypeCurrensy Type)
   {
      return AllCurrensy.First(type => type.CurrencyType == Type).CurrencyCount;
   }


   public static string GetPatchSpriteCurrency(TypeCurrensy Type)
   {
      return AllCurrensy.First(type => type.CurrencyType == Type).CurrencyPatchSprite;
   }

   public static List<CardsNameSpace.Skill> CheckConditional(CardConfig cardConfig)
   {
      List<CardsNameSpace.Skill> unavailableSkill = new();

      foreach (var skillGameData in GameDataSkill.SkillList)
      {
         foreach (var skillCard in cardConfig.ConditionsSkillCard)
         {
            if (skillGameData.CurrencyType == skillCard.type)
            {
               if (skillGameData.SkillCount < skillCard.count)
               {
                  unavailableSkill.Add(skillCard);
               }
            }
         }
      }
      return unavailableSkill;
   }

   public static List<CardsNameSpace.Currensy> CheckPrice(CardConfig cardConfig)
   {
      List<CardsNameSpace.Currensy> unavailableCurrensy = new();

      foreach (var allCurrensy in GameDate.AllCurrensy)
      {
         foreach (var priceCurrensyCard in cardConfig.PriceCurrensyCard)
         {
            if (allCurrensy.CurrencyType == priceCurrensyCard.type)
            {
               if (allCurrensy.CurrencyCount < priceCurrensyCard.count)
               {
                  unavailableCurrensy.Add(priceCurrensyCard);
               }
            }
         }
      }
      
      return unavailableCurrensy;
   }


}
public class Currensy
{
   public GameDate.TypeCurrensy CurrencyType;
   public float CurrencyCount;
   public string CurrencyName;
   public string CurrencyPatchSprite;
   public bool Special;
}

public class InstansCard
{
   public GameObject GameObjectCard;
   public string NameCard;
   public CardConfig CardConfig;
}



