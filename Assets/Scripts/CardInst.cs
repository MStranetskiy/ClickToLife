using CollectionsCardsNameSpace;
using UnityEngine;
using UnityEngine.UI;


public class CardInst : MonoBehaviour
{

  public Transform handTransformLife;
  public Transform handTransformHealth;
  public Transform handTransformMoney;

  public ScreenSetings screenSetings;

  public CollectionsCardConfig[] CardsCollection;


  void Start()
  {
    foreach (var collection in CardsCollection)
    {
      CardsInstalete(collection);
    }
  }

  public void CardsInstalete(CollectionsCardConfig collection)
  {
    var position = handTransformLife.transform.position;

    var count = 0;
    foreach (var item in collection.CardConfigs)
    {
      var handTransform = handTransformLife;
      switch (collection.TypeCard)
      {
        case GameDate.TypeCurrensy.Life:
          handTransform = handTransformLife;
          break;

        case GameDate.TypeCurrensy.Health:
          handTransform = handTransformHealth;
          break;

        case GameDate.TypeCurrensy.Money:
          handTransform = handTransformMoney;
          break;
      }
      var poz = "position" + count.ToString();
      var cardGO = Instantiate(item.CardsGameObject, handTransform.Find(poz), false);

      InstansCard InstansCard = new()
      {
        GameObjectCard = cardGO,
        NameCard = item.NameCard,
        CardConfig = item
      };

      GameDate.instansCard.Add(InstansCard);

      var cardInfo = cardGO.transform;
      cardInfo.SetParent(handTransform);
      cardInfo.Rotate(0, 0, item.rotate);
     // cardInfo.localScale = new Vector3(screenSetings.ScaleCard, screenSetings.ScaleCard, 0);
      cardInfo.Find("CardImage").GetComponent<Image>().sprite = item.cardImage;
      cardInfo.Find("NameCardPanel").Find("Text").GetComponent<Text>().text = item.NameCard;

      handTransform.Find(poz).gameObject.transform.position += new Vector3(+450,
      0, 0);

      count++;
      if (count > screenSetings.CountCardOnScreen)
        count = 0;

    }
  }
}
