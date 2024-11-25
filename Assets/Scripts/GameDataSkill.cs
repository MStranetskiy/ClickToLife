using System.Collections.Generic;
using System.Linq;


public static class GameDataSkill
{
    public enum TypeSkill
    {

        Intellect,
        Power,
        Stamina,
        Speed,
        Charisma,
        Good,
        Evil,   
//СharacterSpecial
        Talk,
        Walk,
    }

    public static Skill Intellect = new() {CurrencyType = TypeSkill.Intellect, SkillCount = 0, SkillName="Интеллект", SkillPatchSprite="Sprites/Currency/IntellectIco", SkillSpecial=false};
    public static Skill Power = new() {CurrencyType = TypeSkill.Power, SkillCount = 0, SkillName="Сила", SkillPatchSprite="Sprites/Currency/PowerIco", SkillSpecial=false};
    public static Skill Stamina = new() {CurrencyType = TypeSkill.Stamina, SkillCount = 0, SkillName="Выносливость", SkillPatchSprite="Sprites/Currency/Stamina", SkillSpecial=false};
    public static Skill Speed = new() {CurrencyType = TypeSkill.Speed, SkillCount = 0, SkillName="Скорость", SkillPatchSprite="Sprites/Currency/Speed", SkillSpecial=false};
    public static Skill Charisma = new() {CurrencyType = TypeSkill.Charisma, SkillCount = 0, SkillName="Харизма", SkillPatchSprite="Sprites/Currency/Charisma", SkillSpecial=false};
    public static Skill Good = new() {CurrencyType = TypeSkill.Good, SkillCount = 0, SkillName="Добрый", SkillPatchSprite="Sprites/Currency/Good", SkillSpecial=false};
    public static Skill Evil = new() {CurrencyType = TypeSkill.Evil, SkillCount = 0, SkillName="Злой", SkillPatchSprite="Sprites/Currency/Evil", SkillSpecial=false};

    //СharacterSpecial
    public static Skill Talk = new() {CurrencyType = TypeSkill.Talk, SkillCount = 0, SkillName="Умение говорить", SkillPatchSprite="Sprites/Skill/talk", SkillSpecial=true};
    public static Skill Walk = new() {CurrencyType = TypeSkill.Walk, SkillCount = 0, SkillName="Умение ходить", SkillPatchSprite="Sprites/Skill/crawl", SkillSpecial=true};

    public static List<Skill> SkillList = new() {Intellect, Power, Stamina, Speed, Charisma, Good, Evil, Talk, Walk};


    public static string GetNameSkill(TypeSkill Type)
   {
      return SkillList.First(type => type.CurrencyType == Type).SkillName;
   }
      public static float GetCountSkill(TypeSkill Type)
   {
      return SkillList.First(type => type.CurrencyType == Type).SkillCount;
   }

   public static string GetPatchSpriteSkill(TypeSkill Type)
   {
      return SkillList.First(type => type.CurrencyType == Type).SkillPatchSprite;
   }

     public static bool IsSpecial(TypeSkill Type)
   {
      return SkillList.First(type => type.CurrencyType == Type).SkillSpecial;
   }
}

public class Skill
{

    public GameDataSkill.TypeSkill CurrencyType;
    public float SkillCount;
    public string SkillName;
    public string SkillPatchSprite;
    public bool SkillSpecial;

}