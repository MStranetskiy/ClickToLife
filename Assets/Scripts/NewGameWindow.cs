
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewGameWindow : MonoBehaviour
{
    public InputField PlayerInputName;
    public GameObject Leaderboars;
    public ConnectDB connectDB;
    public Text PlaceHolder;
    public Data data;
    private List<char> ForbiddenChar = new() {':','=','\u263a','\\','`','{','}','(',')','*','?','.','/','~',
     '!','@','#','$','%','^','&','+','"','[', ']',';', '\''};
    public List<string> RandomNames = new()
    {
"Акакий","Дурило","Сруль","Дырочко","Попин","Недогоникочерга","Гробокопатель","Нечибаба","Одноочко","Перебейнога","Голозадов",
"Попкин","Пупкин","Ахтунг","Раззявин","Занюськин","Вырвихвост","Завывалов","Голопупенко","Жутков","Сусь","Сухорылов",
"Нахлобыстов","Отслюнько","Синепупенко","Продайвода","Усрючкин","Атомули Ядалато","Накосика Сукасена","Ятасука Накомоде",
"Мояхата Сыровата","Комухари Комусиси","Комуто Херовато","Томимо Токосо","Толисику Толикаку","Херанука Пороялю",
"Тояма Токанава","Ясука Такая","Совсейдури Охерачу","Ручищито Ширехари","Вынька Мелоч","Бздашек Западловский",
"Мыкола Заяицкий","Жарь Лук де Блюю","Оливье Жюй да Глотай","Спиро Наполнасракис","Танос Слюнидополу","Маразмус Нолемоций",
"Оридо Пота","Поджог Сараев","Ушат Помоев","Рекорд Надоев","Гарем Плейбоев","Рулон Обоев","Бидон Отстоев","Букет Левкоев",
"Залог Успехов","Захват Покоев","Исход Изгоев","Камаз Отбросов","Налог Сдоходов","Обвал Забоев","Отлов Приматов",
"Отряд Ковбоев","Побег Дебилов","Побег Злодеев","Подрыв Устоев","Подшум Прибоев","Полив Побегов","Разбор Полётов",
"Развод Супругов","Разгон Пикетов","Разгул Маньяков","Распил Самшитов","Удел Плебеев","Газон Засеян","Вагон Опохмелян",
"Гиви Набздел","Гвозди Заржавели",
};

    public void GenerationRandomName()
    {
        var randomElement = RandomNames[Random.Range(0, RandomNames.Count)];
        PlayerInputName.text = randomElement;

        if (!CheckConditionalName())
        GenerationRandomName();
    }

    public bool CheckConditionalName()
    {
        if (PlayerInputName.text.Length < 3 || PlayerInputName.text.Length > 20)
        {
            PlayerInputName.text = "";
            PlaceHolder.color = Color.red;
            PlaceHolder.text = "От 3 до 20 символов";
            return false;
        }

        foreach (var item in PlayerInputName.text)
        {
            if (ForbiddenChar.Contains(item))
            {
                PlayerInputName.text = "";
                PlaceHolder.color = Color.red;
                PlaceHolder.text = "Содержит недопустимые символы";
                return false;
            }
        }
        return true;
    }
    
    public void StartNewGame()
    {
        if (!CheckConditionalName())
        return;

        data.speedTime =1;
        gameObject.SetActive(false);
        GameDate.PlayerName = PlayerInputName.text;
    }

    public void ShowLeaderboard()
    {
        Leaderboars.SetActive(true);
        connectDB.SelectRequest();
    }
    public void Exit()
    {
        Application.Quit();
    }
}
