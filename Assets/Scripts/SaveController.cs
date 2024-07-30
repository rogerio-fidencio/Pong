using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static Unity.VisualScripting.StickyNote;

public class SaveController : MonoBehaviour
{
    public Color colorPlayerOne = Color.white;
    public Color colorPlayerTwo = Color.white;
    public string namePlayerOne;
    public string namePlayerTwo;

    private static SaveController _instance;
    public static SaveController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SaveController>();
                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject(typeof(SaveController).Name);
                    _instance = singletonObject.AddComponent<SaveController>();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public string GetName(bool isPlayer)
    {
        return isPlayer ? namePlayerOne : namePlayerTwo;
    }

    public void Reset()
    {
        namePlayerOne = "";
        namePlayerTwo = "";
        colorPlayerOne = Color.white;
        colorPlayerTwo = Color.white;
    }

    public void SaveWinner(string winner)
    {
        PlayerPrefs.SetString("SavedWinner", winner);
    }
    public string GetLastWinner()
    {
        return PlayerPrefs.GetString("SavedWinner");
    }

    public void ClearSave()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
