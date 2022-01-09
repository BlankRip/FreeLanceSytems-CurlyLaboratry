using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SaveSystem;
using UnityEngine.SceneManagement;

public class StartingGame : MonoBehaviour
{
    [SerializeField] Button newGame;
    [SerializeField] Button loadGame;

    [Space] [Header("Warning Panel Stuff")]
    [SerializeField] GameObject warningPanel;
    [SerializeField] Button warningNo;
    [SerializeField] Button warningYes;

    [Space] [Header("No Save Panel Stuff")]
    [SerializeField] GameObject noSavePanel;
    [SerializeField] Button noSaveBack;

    private void Start() {
        newGame.onClick.AddListener(NewGame);
        loadGame.onClick.AddListener(LoadGame);

        warningNo.onClick.AddListener(() => {warningPanel.SetActive(false);});
        warningYes.onClick.AddListener(() => { 
            SaveManager.instance.ClearSlot(); 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        });

        noSaveBack.onClick.AddListener(() => {noSavePanel.SetActive(false);});
    }

    private void NewGame() {
        int sceneIndex = SaveManager.instance.GetLoadSceneIndex();
        if(sceneIndex == -1)
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        else
            warningPanel.SetActive(true);
    }

    private void LoadGame() {
        int sceneIndex = SaveManager.instance.GetLoadSceneIndex();
        if(sceneIndex == -1)
            noSavePanel.SetActive(true);
        else
            SceneManager.LoadScene(sceneIndex);
    }
}