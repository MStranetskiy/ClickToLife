using System;
using System.Collections.Generic;
using System.Linq;
using CardsNameSpace;
using CollectionsCardsNameSpace;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class CardPopap : MonoBehaviour
{

    public GameObject cardPopap;
    public Text CurrentNameCard;
    [NonSerialized] public CardConfig CurrentCard;
    public Transform itemDown;
    public Transform itemTop;
    public Transform contentTop;
    public Transform contentDown;
    public Image cardImage;

    [NonSerialized] public List<GameObject> DestrouGO = new();

    [NonSerialized] public InstansCard CurrentInstans;

    public CollectionsCardConfig CardConfigs;

    [NonSerialized] public int distance = 0;

    [NonSerialized] public string currencyBlock = "CurrencyBlock", txt = "Text", image = "Image";

    void Start()
    {
        CurrentInstans = GameDate.instansCard.First(n => n.NameCard == CurrentNameCard.text);
        CurrentCard = CurrentInstans.CardConfig;
        cardImage.GetComponent<Image>().sprite = CurrentCard.cardImage;

        DrawCurrency(CurrentCard.RewardsCurrensyCard, itemDown, contentDown, true);
        DrawSkill(CurrentCard.RewardsSkillCard, itemDown, contentDown, true);
        distance = 0;
        DrawCurrency(CurrentCard.PriceCurrensyCard, itemTop, contentTop, false);

        foreach (var item in GameDate.purchasedCards)
        {
            if (item == CurrentCard)
            {
                Destroy(gameObject.transform.Find("BackGraundCard").Find("ContentDown").Find("BuyButton").gameObject);
                return;
            }
        }
    }

    public void DrawCurrency(CardsNameSpace.Currensy[] currensies, Transform itemCurrensy, Transform content, bool Reward)
    {
        var txt = Reward ? " + " : ": ";
        itemCurrensy.gameObject.SetActive(true);

        foreach (var item in currensies)
        {
            var rewardName = GameDate.GetNameCurrency(item.type);
            var newCurrensyItem = Instantiate(itemCurrensy, content, false);

            var itemtext = newCurrensyItem.Find(this.txt).GetComponent<Text>();
            if (!Reward)
            {
                DestrouGO.Add(newCurrensyItem.gameObject);
                if (item.count > GameDate.GetCountCurrency(item.type))
                {
                    itemtext.color = new Color(1f, 0, 0);
                }
            }

            newCurrensyItem.transform.position += new Vector3(0, -distance, 0);
            itemtext.text = rewardName + txt + item.count;
            newCurrensyItem.Find(image).GetComponent<Image>().sprite = Resources.Load<Sprite>(GameDate.GetPatchSpriteCurrency(item.type));
            distance = distance - -100;
        }

        itemCurrensy.gameObject.SetActive(false);

    }

    public void DestroyCardPopap()
    {
        Destroy(cardPopap);
    }

    public void DrawSkill(CardsNameSpace.Skill[] skills, Transform itemSkill, Transform content, bool Reward)
    {
        var txt = Reward ? " + " : "нужно иметь ";

        itemSkill.gameObject.SetActive(true);

        foreach (var item in skills)
        {
            var rewardName = GameDataSkill.GetNameSkill(item.type);
            var newSkillItem = Instantiate(itemSkill, content, false);

            if (!Reward)
                DestrouGO.Add(newSkillItem.gameObject);

            newSkillItem.transform.position += new Vector3(0, -distance, 0);
            var itemText = newSkillItem.Find(this.txt).GetComponent<Text>();

            if (GameDataSkill.IsSpecial(item.type))
            {
                itemText.color = new Color(0.5f, 0.5f, 0);
                itemText.text = rewardName + " " + "(Особенность)";
            }

            else
            {
                itemText.text = rewardName + " " + txt + item.count;
            }

            newSkillItem.Find(image).GetComponent<Image>().sprite = Resources.Load<Sprite>(GameDataSkill.GetPatchSpriteSkill(item.type));
            distance = distance - -100;
        }
        itemSkill.gameObject.SetActive(false);

    }

    public void BuyButton()
    {
        var missSkill = 0;
        var missPrice = 0;

        foreach (var item in CurrentCard.ConditionsSkillCard)
        {
            if (item.count > GameDataSkill.SkillList.First(t => t.CurrencyType == item.type).SkillCount)
            {
                missSkill++;
            }
        }

        foreach (var item in CurrentCard.PriceCurrensyCard)
        {
            if (item.count > GameDate.AllCurrensy.First(t => t.CurrencyType == item.type).CurrencyCount)
            {
                missPrice++;
            }
        }

        if (missSkill == 0 && missPrice == 0)
        {
            Debug.Log("Купил");
            GameDate.purchasedCards.Add(CurrentCard);
            AddRewards();
        }
        else
        {
            Debug.Log("Требования не выполнены");
        }
    }
    public void AddRewards()
    {
        foreach (var item in CurrentCard.RewardsCurrensyCard)
        {
            GameDate.AllCurrensy.First(t => t.CurrencyType == item.type).CurrencyCount += item.count;
            Debug.Log(item.type + " " + GameDate.AllCurrensy.First(t => t.CurrencyType == item.type).CurrencyCount);
        }

        foreach (var item in CurrentCard.RewardsSkillCard)
        {
            GameDataSkill.SkillList.First(t => t.CurrencyType == item.type).SkillCount += item.count;
            Debug.Log(item.type + " " + GameDataSkill.SkillList.First(t => t.CurrencyType == item.type).SkillCount);
        }

        CurrentInstans.GameObjectCard.transform.Find("buyBadge").gameObject.SetActive(true);
        CurrentInstans.GameObjectCard.transform.Find("frame").GetComponent<Image>().color = new Color(0.5136614f, 0.9150943f, 0.6178658f, 0.6f);
        CurrentInstans.GameObjectCard.transform.Find("CardImage").GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);


        foreach (var item in GameDate.instansCard)
        {
            if (GameDate.CheckConditional(item.CardConfig).Count() > 0)
            {
                item.GameObjectCard.GetComponent<Card>().DrawConditeonal();
            }
            else
            {
                item.GameObjectCard.GetComponent<Card>().RemoveConditeonal();
            }
        }
        DestroyCardPopap();
    }
}
