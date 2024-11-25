using CardsNameSpace;
using UnityEngine;


namespace CollectionsCardsNameSpace
{
  [CreateAssetMenu(fileName = "NewCardsCollection", menuName = "CardsCollection", order = 1)]
  public class CollectionsCardConfig : ScriptableObject
  {

    [SerializeField]
    public GameDate.TypeCurrensy TypeCard;
    public CardConfig[] CardConfigs;

  }
}