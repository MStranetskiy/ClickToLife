using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image LifeProgressBar;
    public float progressbar;
    public GameObject ParamPopop;
    public Transform ParamBlock;
    public Transform ParamPanel;
    public Transform SkillPanel;
    public Transform Content;
    public Transform CurrencyPanel;
    public Text HappyStatus, PlayerName; 


    public List<GameObject> contentList = new();
    public int distance = 0;

    public string ParamTxt="ParamTxt", ParamImage="Image", ItemSkill="ItemSkill", ItemParam="ItemParam", itenCurrency= "itenCurrency";


    void Update()
    {
        if (GameDate.CheckToLife() == false)
        {
            return;
        }
             
        UpdateLifeProgressBar();
    }

    private void UpdateLifeProgressBar()
    {
        progressbar = (GameDate.livedTo / 100) - GameDate.livedTo; 
        progressbar = (progressbar / GameDate.lived) + 1;
        LifeProgressBar.fillAmount =  progressbar; 
    }

    public void ParamButton(){
        ParamPopop.SetActive(true);

        PlayerName.text = GameDate.PlayerName;
        DrawParamContent(ParamPanel, false, ItemParam);
        distance = 0;
        DrawParamContent(SkillPanel, true, ItemSkill);
        distance = 0;
        DrawCurrency(itenCurrency);

        HappyStatus.text = GameDate.HappyStatus;
        HappyStatus.color = GameDate.HappyColor;
    }

    public void  DrawParamContent(Transform content, bool special, string item)
    {
        content.Find(item).gameObject.SetActive(true);

        foreach (var itemSkillList in  GameDataSkill.SkillList)
        {

            if (special== true && itemSkillList.SkillSpecial == false)
                continue;

            if (special== false && itemSkillList.SkillSpecial == true)
                continue;

            var paramName = itemSkillList.SkillName;
            var newParamBlock = Instantiate(content.Find(item), content.transform, false);
            newParamBlock.transform.position += new Vector3(0, -distance, 0);
            var ParamText = newParamBlock.Find(ParamTxt).GetComponent<Text>();
            ParamText.text = paramName + ": " + itemSkillList.SkillCount;

            newParamBlock.Find(ParamImage).GetComponent<Image>().sprite = Resources.Load<Sprite>(itemSkillList.SkillPatchSprite);
            distance = distance - -120;
            contentList.Add(newParamBlock.gameObject);
        }

       //Destroy(content.Find(item).gameObject);
       content.Find(item).gameObject.SetActive(false);
    }


    public void DrawCurrency(string item){
            
        CurrencyPanel.Find(item).gameObject.SetActive(true);

        foreach (var itemCurrensy in  GameDate.AllCurrensy )
        {
            if (!itemCurrensy.Special)
            continue; 

            var paramName = itemCurrensy.CurrencyName;
            var newParamBlock = Instantiate(CurrencyPanel.Find(item), CurrencyPanel.transform, false);
            newParamBlock.transform.position += new Vector3(0, -distance, 0);
            var ParamText = newParamBlock.Find(ParamTxt).GetComponent<Text>();
            ParamText.text = paramName + ": " + itemCurrensy.CurrencyCount;

            newParamBlock.Find(ParamImage).GetComponent<Image>().sprite = Resources.Load<Sprite>(itemCurrensy.CurrencyPatchSprite);
            distance = distance - -95;
            contentList.Add(newParamBlock.gameObject);
        }

       CurrencyPanel.Find(item).gameObject.SetActive(false);
    }

    public void ClosseButton()
    {
        foreach (var item in contentList)
        {
            Destroy(item);
        }
        contentList.Clear();
        distance=0;
    }
}
