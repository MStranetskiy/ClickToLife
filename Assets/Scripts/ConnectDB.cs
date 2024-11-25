using UnityEngine;
using PUSHKA.MySQL;
using System;
using UnityEngine.UI;
using System.Data;

public class ConnectDB : MonoBehaviour
{
    public GameObject PanelPalyer;
    public Transform content;
    public Text PlayerName, PalyerScore;
    private int showLeaderboardPlace= 10;
    private string namePlayer= "Name", score="Score", placePlayer="Place";
    int distance=0;
    public void AddRequest()
    {
        SqlDataBase dataBase = new SqlDataBase("45.90.218.156", "clicktolife", "MaxAdmin", "Lk8&U8RY");
        string dataStr = "'" + DateTime.Now.Year + "-" + DateTime.Now.Month + "-" + DateTime.Now.Day + "'";
        string request = "INSERT INTO Player VALUES ('" + GameDate.PlayerName + "'," + GameDate.lived + "," + dataStr + ");";

        dataBase.RunQuery(request);
    }

    public void SelectRequest()
    {
        SqlDataBase dataBase = new SqlDataBase("45.90.218.156", "clicktolife", "MaxAdmin", "Lk8&U8RY");
        dataBase.SelectQuery("SELECT * FROM clicktolife.Player order by score DESC;", out DataTable dataTable);
        var place =1;
        for (int i = 0; i < showLeaderboardPlace; i++)
        {
            DataRow item = dataTable.Rows[i];

            var newItem = Instantiate(PanelPalyer, content, false);
            newItem.transform.position += new Vector3(0, -distance, 0);
            newItem.transform.Find(namePlayer).GetComponent<Text>().text = item[0].ToString();

            int daysLived = Int32.Parse(item[1].ToString());
            int year = daysLived / 365;
            daysLived -= year * 365;
            int month = daysLived / 30;
            daysLived -= month * 30;
            
            string result = year.ToString() + "г. " + month.ToString() + "м. " + daysLived.ToString() + "д.";

            newItem.transform.Find(score).GetComponent<Text>().text = result;
            newItem.transform.Find(placePlayer).GetComponent<Text>().text = place.ToString();
            distance = distance - -150;
            place++;
        }
        PanelPalyer.gameObject.SetActive(false);
    }
}
