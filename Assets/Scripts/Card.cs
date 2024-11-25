using UnityEngine;
using UnityEngine.UI;
using CollectionsCardsNameSpace;
using System.Linq;
using System.Collections.Generic;
using System;



public class Card : MonoBehaviour
{
  public GameObject popap;
  public Image nameCard;
  public Image frameCard;
  public Image ImageCard;
  public GameObject lockIco;
  public GameObject[] conditional;
  public GameObject conditionalTitle;
  public GameObject PriceInvalidFrame;
  public GameObject PriceInvalidTxt;
  public GameObject ConditionalInvalidFrame;
  public GameObject ConditionalPanel;


  [NonSerialized] public string Text = "Text", Image = "Image";
  [NonSerialized] public CardsNameSpace.CardConfig CurrentCardConfig;

  public void Start()
  {
     
     CurrentCardConfig = GameDate.instansCard.First(g => g.GameObjectCard == gameObject).CardConfig;
    
    
     if (GameDate.CheckConditional(CurrentCardConfig).Count > 0)
     {
      DrawConditeonal();
     }
     else
     {
       if(GameDate.CheckPrice(CurrentCardConfig).Count > 0)
       DrawPrice();
     }


  }

  public void ButtonClick()
  {
    if(GameDate.CheckConditional(CurrentCardConfig).Count > 0)
    {
      ConditionalPanel.SetActive(true);
      frameCard.gameObject.SetActive(false);
      ConditionalInvalidFrame.SetActive(false);
    }
else
{
    var newPopap = Instantiate(popap, GameObject.Find("GeneralCanvas").transform, false);
    newPopap.transform.Find("BackGraundCard").Find("ContentTop").Find("TitlePanel").Find("CardName")
    .GetComponent<Text>().text = CurrentCardConfig.NameCard;
}

  }

  public void DrawConditeonal()
  {
   // conditionalTitle.SetActive(true);
    lockIco.SetActive(true);
    ConditionalInvalidFrame.SetActive(true);
    nameCard.GetComponent<Image>().color = Color.gray;
    frameCard.GetComponent<Image>().color = Color.gray;
    ImageCard.GetComponent<Image>().color =  Color.gray;


    for (int count = 0; count < CurrentCardConfig.ConditionsSkillCard.Count(); count++)
    {
        var skillCard = CurrentCardConfig.ConditionsSkillCard[count];
        var condit = conditional[count];
        condit.SetActive(true);
        
        var skill =  GameDataSkill.SkillList.First(n => n.CurrencyType == skillCard.type);
        condit.transform.Find(Text).GetComponent<Text>().text =

        skill.SkillName + " " + skillCard.count;

        condit.transform.Find(Image).GetComponent<Image>().sprite = 
        Resources.Load<Sprite>(GameDataSkill.GetPatchSpriteSkill(skillCard.type));
      }
    }

    public void RemoveConditeonal()
    {
    //conditionalTitle.SetActive(false);
    lockIco.SetActive(false);
    ConditionalInvalidFrame.SetActive(false);
    nameCard.GetComponent<Image>().color = new Color(1,1,1);
    frameCard.GetComponent<Image>().color = new Color(1,1,1);
    ImageCard.GetComponent<Image>().color =  new Color(1,1,1);

    foreach (var item in conditional)
    {
      item.SetActive(false);
    }

    }

    public void DrawPrice()
    {
      PriceInvalidFrame.SetActive(true);
      //PriceInvalidTxt.SetActive(true);

    }

        public void RemovePrice()
    {
      PriceInvalidFrame.SetActive(false);
     // PriceInvalidTxt.SetActive(false);

    }


}


