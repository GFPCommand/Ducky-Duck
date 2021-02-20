using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
    public static bool isPause = false;
    private int check, transition;
    public GameObject PausePanel, PauseButton, ExtraLifeMenu, music, panelScore, panelHighScore, GameScores, scoreTextObj, highScoreTextObj, player, ScoreMenuTextObj, HighScoreMenuTextObj;
    public GameObject[] PauseMenuButtons;
    public Text pauseText, EndGameScore, EndGameHighScore;
    public Text[] ButtonsText;
    public Sprite[] ButtonsActions;
    public Sprite[] Birds = new Sprite[4];

    public void PauseGame()
    {
        if (!isPause)
        {
            isPause = true;
            PausePanel.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0;
            check = 0;
        }
    }

    public void ContinueButton()
    {
        switch (check)
        {
            case 0:
                if (isPause && !PlayerLVL.win)
                {
                    isPause = false;
                    PausePanel.SetActive(false);
                    PauseButton.SetActive(true);
                    panelScore.SetActive(true);
                    panelHighScore.SetActive(true);
                    Time.timeScale = 1;
                } else if (!isPause && PlayerLVL.win)
                {
                    panelHighScore.SetActive(false);
                    transition = PlayerPrefs.GetInt("selLVL");
                    PlayerPrefs.SetInt("selLVL", ++transition);
                    SceneManager.LoadScene(1);
                }
                break;

            case 1:
                if (PlayerPrefs.GetInt("Music") == 0)
                {
                    PlayerPrefs.SetInt("Music", 1);
                    ButtonsText[0].text = "Music: on";
                    PauseMenuButtons[0].GetComponent<Image>().sprite = ButtonsActions[0];
                    music.SetActive(true);
                } else if (PlayerPrefs.GetInt("Music") == 1)
                {
                    PlayerPrefs.SetInt("Music", 0);
                    ButtonsText[0].text = "Music: off";
                    PauseMenuButtons[0].GetComponent<Image>().sprite = ButtonsActions[1];
                    music.SetActive(false);
                }
                break;
        }
        
    }

    public void RestartButton()
    {
        switch (check)
        {
            case 0:
                isPause = false;
                SceneManager.LoadScene(1);
                break;

            case 1:
                if (PlayerPrefs.GetInt("Sound") == 0)
                {
                    PlayerPrefs.SetInt("Sound", 1);
                    ButtonsText[1].text = "Sound: on";
                    PauseMenuButtons[1].GetComponent<Image>().sprite = ButtonsActions[0];
                }
                else if (PlayerPrefs.GetInt("Sound") == 1)
                {
                    PlayerPrefs.SetInt("Sound", 0);
                    ButtonsText[1].text = "Sound: off";
                    PauseMenuButtons[1].GetComponent<Image>().sprite = ButtonsActions[1];
                }
                break;
        }
    }

    public void SettingsButton()
    {

        switch (check)
        {
            case 0:
                pauseText.text = "Settings";
                ButtonsText[2].text = "Back";
                PauseMenuButtons[3].SetActive(false);

                if (Player.lose)
                {
                    PauseMenuButtons[0].SetActive(true);
                    GameScores.SetActive(false);
                }

                check = 1;

                if (PlayerPrefs.GetInt("Music") == 1)
                {
                    PauseMenuButtons[0].GetComponent<Image>().sprite = ButtonsActions[0];
                    ButtonsText[0].text = "Music: on";
                }
                else if (PlayerPrefs.GetInt("Music") == 0)
                {
                    PauseMenuButtons[0].GetComponent<Image>().sprite = ButtonsActions[1];
                    ButtonsText[0].text = "Music: off";
                }

                if (PlayerPrefs.GetInt("Sound") == 1)
                {
                    PauseMenuButtons[1].GetComponent<Image>().sprite = ButtonsActions[0];
                    ButtonsText[1].text = "Sound: on";
                }
                else if (PlayerPrefs.GetInt("Sound") == 0)
                {
                    PauseMenuButtons[1].GetComponent<Image>().sprite = ButtonsActions[1];
                    ButtonsText[1].text = "Sound: off";
                }

                break;

            case 1:
                PauseMenuButtons[3].SetActive(true);

                if (!Player.lose) pauseText.text = "Pause";
                else {
                    pauseText.text = "You lose";
                    PauseMenuButtons[0].SetActive(false);

                    GameScores.SetActive(true);

                    EndGameScore.text = "Score: " + Player.score.ToString();
                    EndGameHighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();
                }

                PauseMenuButtons[0].GetComponent<Image>().sprite = ButtonsActions[0];
                PauseMenuButtons[1].GetComponent<Image>().sprite = ButtonsActions[0];

                ButtonsText[0].text = "Continue";
                ButtonsText[1].text = "Restart";
                ButtonsText[2].text = "Settings";

                check = 0;

                break;
        }
        
    }

    public void ExitMenuButton()
    {
        isPause = false;
        if (LoadLevels.isLevels) LoadLevels.isLevels = false;
        Menu.isLoad = false;
        LoadLevels.isLoadLevels = false;
        SceneManager.LoadScene(0);
    }

    public void Confirm()
    {
        panelScore.SetActive(true);
        scoreTextObj.SetActive(true);

        panelHighScore.SetActive(true);
        highScoreTextObj.SetActive(true);

        PlayerPrefs.SetInt("ExtraLife", --InitializeGame.ExtraLifes);

        PausePanel.SetActive(false);

        Time.timeScale = 1;

        if (!LoadLevels.isLevels) Player.lose = false;
        else PlayerLVL.lose = false;

        switch (PlayerPrefs.GetInt("BirdActive"))
        {
            case 1:
                player.GetComponent<SpriteRenderer>().sprite = Birds[0];
                break;
            case 2:
                player.GetComponent<SpriteRenderer>().sprite = Birds[1];
                break;
            case 3:
                player.GetComponent<SpriteRenderer>().sprite = Birds[2];
                break;
            case 4:
                player.GetComponent<SpriteRenderer>().sprite = Birds[3];
                break;
        }
    }

    public void Cancel()
    {
        for (int i = 0; i < PauseMenuButtons.Length; i++)
        {
            if (Player.lose && i == 0) continue; 
            PauseMenuButtons[i].SetActive(true);
        }

        if (!LoadLevels.isLevels) Player.CheckLose++;

        ExtraLifeMenu.SetActive(false);

        ScoreMenuTextObj.SetActive(true);
        HighScoreMenuTextObj.SetActive(true);

        EndGameScore.text = "Score: " + Player.score.ToString();
        EndGameHighScore.text = "HighScore: " + PlayerPrefs.GetInt("HighScore").ToString();

        pauseText.text = "You lose";
    }
}