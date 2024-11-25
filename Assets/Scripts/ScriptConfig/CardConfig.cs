
using UnityEngine;
using System;

namespace CardsNameSpace
{
  [CreateAssetMenu(fileName = "NewCards", menuName = "Cards", order = 1)]
  public class CardConfig : ScriptableObject
  {
    [SerializeField]
      public string NameCard;
      public GameObject CardsGameObject;
      public float rotate;
      public Sprite cardImage;
      [SerializeField] public Currensy[] PriceCurrensyCard;
      [SerializeField] public Skill[] ConditionsSkillCard;
      [SerializeField] public Currensy[] RewardsCurrensyCard;
      [SerializeField] public Skill[] RewardsSkillCard;

    }

    [Serializable]
    public class Currensy
    {
      public GameDate.TypeCurrensy type;
      public float count;
    }
    [Serializable]
    public class Skill
    {
      public GameDataSkill.TypeSkill type;
      public float count;
    }
  }
