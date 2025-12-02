
using System.Collections.Generic;
using TMPro;
using UnityEngine;

//
// Plan B [Andrew Foord, 1987] v2023.09.14
//
// v2025.11.21
//

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private TMP_Text caret;

    [SerializeField] private TMP_InputField inputField;
    [SerializeField] private TMP_Text inputText;


    [SerializeField] private Transform entryHighlightBar;

    private Transform entryContainer;
    private Transform entryTemplate;


    private List<Transform> highscoreEntryTransformList;


    private Highscores highscores;


    private Vector2 originPos;


    private const string PLAYER_PREFS_HIGHSCORE_KEY = "highscoreTable";


    private string replaceCaret = "_";
    private string emptyString = "";

    private string bkspace = "\b";
    private string bkspaceDbl = "\b\b";


    private int highlightBarPosition;


    private float caretBlinkTimer;

    private bool enteringName;
    private bool isEmptyString;


    private bool disableTest = true;




    private void Start()
    {
        InitialiseHighScoreTable();
    }


    private void Update()
    {
        if (enteringName)
        {
            BlinkCaret();
        }


        if (disableTest)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                DeletePlayerPrefsKey();
            }

            if (Input.GetKeyDown(KeyCode.I))
            {
                InsertHighScore(30);

                disableTest = false;
            }
        }
    }


    private void InitialiseHighScoreTable()
    {
        entryContainer = transform.Find("highscoreEntryContainer");

        entryTemplate = transform.Find("highscoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        entryHighlightBar.gameObject.SetActive(false);

        LoadDefaultHighscoreData();

        Debug.Log("HIGHSCORE TABLE INITIALISED");
    }



    private void DeletePlayerPrefsKey()
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE_KEY))
        {
            PlayerPrefs.DeleteKey(PLAYER_PREFS_HIGHSCORE_KEY);

            ReloadDefaultHighscoreData();

            Debug.Log("PLAYERPREFS HIGHSCORE KEY DELETED");
        }
    }


    private void ReloadDefaultHighscoreData()
    {
        ClearHighScores();

        // remove the high score transforms from the list
        highscores.highscoreEntryList.Clear();

        LoadDefaultHighscoreData();
    }


    private void LoadHighScoreTable()
    {
        if (PlayerPrefs.HasKey(PLAYER_PREFS_HIGHSCORE_KEY))
        {
            Debug.Log("PLAYERPREFS KEY PRESENT - LOADING HIGHSCORE DATA");

            LoadHighScoreData();

            Debug.Log(PlayerPrefs.GetString(PLAYER_PREFS_HIGHSCORE_KEY));
        }

        else
        {
            Debug.Log("NO PLAYERPREFS KEY PRESENT - LOADING DEFAULT DATA");

            SetDefaultHighscoreData();

            Debug.Log(PlayerPrefs.GetString(PLAYER_PREFS_HIGHSCORE_KEY));
        }
    }


    private void LoadHighScoreData()
    {
        // locate the high score table
        string jsonString = PlayerPrefs.GetString(PLAYER_PREFS_HIGHSCORE_KEY);

        // and see if there is any data in the table
        highscores = JsonUtility.FromJson<Highscores>(jsonString);
    }


    private void LoadDefaultHighscoreData()
    {
        LoadHighScoreTable();

        SortHighScoreData();
    }


    private void SetDefaultHighscoreData()
    {
        //AddHighScore("", 0);
        //AddHighScore("       Plan B is a", 0);
        //AddHighScore("BLACK ACCIDENT PRODUCTION", 0);
        //AddHighScore("", 0);
        //AddHighScore("Program......Andrew Foord", 0);
        //AddHighScore("Music.........Peter Foord", 0);
        //AddHighScore("Monitor......Paul Brittan", 0);
        //AddHighScore("", 0);
        //AddHighScore("", 0);
        //AddHighScore("", 0);

        AddDefaultHighScoreData("", 50);
        AddDefaultHighScoreData("       Plan B is a", 30);
        AddDefaultHighScoreData("BLACK ACCIDENT PRODUCTION", 20);
        AddDefaultHighScoreData("", 10);
        AddDefaultHighScoreData("Program......Andrew Foord", 100);
        AddDefaultHighScoreData("Music.........Peter Foord", 80);
        AddDefaultHighScoreData("Monitor......Paul Brittan", 40);
        AddDefaultHighScoreData("", 70);
        AddDefaultHighScoreData("", 60);
        AddDefaultHighScoreData("", 90);

    }


    private void SaveHighScoreData()
    {
        // create a string of highscore data
        string json = JsonUtility.ToJson(highscores);

        PlayerPrefs.SetString(PLAYER_PREFS_HIGHSCORE_KEY, json);

        PlayerPrefs.Save();
    }


    public void SaveHighScoreName()
    {
        highscores.highscoreEntryList[highlightBarPosition].name = entryHighlightBar.Find("nameText").GetComponent<TMP_Text>().text;

        int score = int.Parse(entryHighlightBar.Find("scoreText").GetComponent<TMP_Text>().text);

        highscores.highscoreEntryList[highlightBarPosition].score = score;

        entryHighlightBar.gameObject.SetActive(false);

        enteringName = false;


        SaveHighScoreData();


        ClearHighScores();

        DisplayHighScores();


        Debug.Log("SCORE ENTERED");
    }


    private void AddDefaultHighScoreData(string name, int score)
    {
        // create a new HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = name, score = score };

        LoadHighScoreData();

        // if there is no saved high score data
        if (highscores == null)
        {
            // initialise a new high score entry
            highscores = new Highscores()
            {
                highscoreEntryList = new List<HighscoreEntry>()
            };
        }

        // add new entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        SaveHighScoreData();
    }


    public void InsertHighScore(int score)
    {
        // create a new HighscoreEntry
        HighscoreEntry highscoreEntry = new HighscoreEntry { name = "", score = score };


        // add new temporary entry to Highscores
        highscores.highscoreEntryList.Add(highscoreEntry);

        // get high score name y position
        highlightBarPosition = SortHighScoreData();

        // remove the last high score transform
        Destroy(highscoreEntryTransformList[highscores.highscoreEntryList.Count - 1].gameObject);

        // remove the last high score transform from the list
        highscores.highscoreEntryList.RemoveAt(highscores.highscoreEntryList.Count - 1);

        SaveHighScoreData();

        GetHighScoreName(highscoreEntry);
    }


    private void GetHighScoreName(HighscoreEntry highscoreEntry)
    {
        entryHighlightBar.transform.position = new Vector2(entryHighlightBar.transform.position.x, entryHighlightBar.transform.position.y - (highlightBarPosition * 2));

        entryHighlightBar.gameObject.SetActive(true);


        int rank = highlightBarPosition + 1;

        string rankString = FormatRankString(rank);

        entryHighlightBar.Find("posText").GetComponent<TMP_Text>().text = rankString;

        entryHighlightBar.Find("scoreText").GetComponent<TMP_Text>().text = highscoreEntry.score.ToString("0000000");

        originPos = caret.transform.position;

        highscoreEntry.name = "";

        entryHighlightBar.Find("nameText").GetComponent<TMP_Text>().text = "";

        inputField.ActivateInputField();

        inputText.text = caret.text;

        // we are entering a name, so blink the caret
        enteringName = true;
    }


    public void ValidateInput()
    {
        if (Input.anyKey)
        {
            // exceeded input length
            if (inputText.textInfo.characterCount >= inputField.characterLimit + 1 && !Input.inputString.Equals(bkspace))
            {
                return;
            }

            else if (Input.inputString.Equals(bkspace) || Input.inputString.Equals(bkspaceDbl))
            {
                if (inputField.text.Length >= 0 && !isEmptyString)
                {
                    if (caret.transform.position.x > originPos.x)
                    {
                        caret.transform.position = new Vector2(caret.transform.position.x - 1, caret.transform.position.y);
                    }

                    if (inputField.text.Length == 0)
                    {
                        caret.transform.position = new Vector2(caret.transform.position.x, caret.transform.position.y);

                        entryHighlightBar.Find("nameText").GetComponent<TMP_Text>().text = "";

                        isEmptyString = true;
                    }
                }
            }


            else if (Input.inputString.Length > 0 && !(inputText.textInfo.characterCount >= inputField.characterLimit + 1))
            {
                try
                {
                    caret.transform.position = new Vector2(caret.transform.position.x + 1, caret.transform.position.y);

                    isEmptyString = false;
                }

                catch
                {
                    Debug.Log("ERROR");
                }
            }


            //else if (Input.GetKey(KeyCode.Return))
            //{
            //    entryHighlightBar.gameObject.SetActive(false);

            //    enteringName = false;

            //    Debug.Log("SCORE ENTERED");
            //}


            //else if (Input.inputString.Equals(emptyString))
            //{
            //    return;
            //}


            if (inputField.text.Length > 0)
            {
                entryHighlightBar.Find("nameText").GetComponent<TMP_Text>().text = inputField.text;
            }
        }
    }


    private int SortHighScoreData()
    {
        highlightBarPosition = -1;

        for (int i = 0; i < highscores.highscoreEntryList.Count; i++)
        {
            for (int j = i + 1; j < highscores.highscoreEntryList.Count; j++)
            {
                if (highscores.highscoreEntryList[j].score >= highscores.highscoreEntryList[i].score)
                {
                    if (highlightBarPosition == -1)
                    {
                        highlightBarPosition = i;
                    }

                    HighscoreEntry tmp = highscores.highscoreEntryList[i];

                    highscores.highscoreEntryList[i] = highscores.highscoreEntryList[j];

                    highscores.highscoreEntryList[j] = tmp;
                }
            }
        }

        SaveHighScoreData();


        ClearHighScores();

        DisplayHighScores();


        Debug.Log("HIGH SCORE DATA SORTED");
        
        return highlightBarPosition;       
    }


    private void DisplayHighScores()
    {
        highscoreEntryTransformList = new List<Transform>();

        foreach (HighscoreEntry highscoreEntry in highscores.highscoreEntryList)
        {
            CreateHighscoreEntryTransform(highscoreEntry, entryContainer, highscoreEntryTransformList);
        }
    }


    private void ClearHighScores()
    {
        if (entryContainer.childCount > 0)
        {
            for (int i = 0; i < entryContainer.childCount; i++)
            {
                Destroy(highscoreEntryTransformList[i].gameObject);
            }
        }
    }


    private void CreateHighscoreEntryTransform(HighscoreEntry highscoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 64f;

        Transform entryTransform = Instantiate(entryTemplate, container);

        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);

        entryTransform.gameObject.SetActive(true);


        int rank = transformList.Count + 1;

        string rankString = FormatRankString(rank);

        entryTransform.Find("posText").GetComponent<TMP_Text>().text = rankString;


        string name = highscoreEntry.name;

        entryTransform.Find("nameText").GetComponent<TMP_Text>().text = name;

        int score = highscoreEntry.score;

        entryTransform.Find("scoreText").GetComponent<TMP_Text>().text = score.ToString("0000000");


        transformList.Add(entryTransform);
    }


    private string FormatRankString(int rank)
    {
        string rankString;

        switch (rank)
        {
            case 10:

                rankString = "" + rank;

                break;

            default:

                rankString = " " + rank;

                break;
        }

        return rankString;
    }


    private void BlinkCaret()
    {
        caretBlinkTimer += Time.deltaTime;

        if (caretBlinkTimer >= 0.5f)
        {
            caret.text = replaceCaret;
        }

        if (caretBlinkTimer >= 1f)
        {
            caret.text = emptyString;

            caretBlinkTimer = 0;
        }
    }



    // list of high scores to save
    private class Highscores
    {
        public List<HighscoreEntry> highscoreEntryList;
    }


    // single high score entry
    [System.Serializable]
    private class HighscoreEntry
    {
        public string name;
        public int score;
    }


} // end of class
