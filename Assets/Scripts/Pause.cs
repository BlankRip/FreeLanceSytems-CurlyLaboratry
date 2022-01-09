﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class Pause : MonoBehaviour
{
    [SerializeField] KeyCode pauseKey = KeyCode.Escape;
    [SerializeField] GameObject pausePanel;
    [SerializeField] GameObject unsaveDataWarning;

    [Space][Header("Pause Panel Buttons")]
    [SerializeField] Button resume;
    [SerializeField] Button saveGame;
    [SerializeField] Button backToMenu;
    [SerializeField] Button quit;

    [Space][Header("Unsave Warning Panel Buttons")]
    [SerializeField] Button no;
    [SerializeField] Button yes;
    private UnityEvent yesButtonEvent;

    private void Start() {
        yesButtonEvent = new UnityEvent();

        resume.onClick.AddListener(ResumeGame);
        if(saveGame != null)
            saveGame.onClick.AddListener(SaveGame);
        backToMenu.onClick.AddListener(BackToMenu);
        if(quit != null)
            quit.onClick.AddListener(Quit);

        no.onClick.AddListener(CloseUnsaveWarning);
        yes.onClick.AddListener(RunYesEvent);
    }

    private void OnDestroy() {
        resume.onClick.RemoveListener(ResumeGame);
        if(saveGame != null)
            saveGame.onClick.RemoveListener(SaveGame);
        backToMenu.onClick.RemoveListener(BackToMenu);
        if(quit != null)
            quit.onClick.RemoveListener(Quit);

        no.onClick.RemoveListener(CloseUnsaveWarning);
        yes.onClick.RemoveListener(RunYesEvent);
    }

    private void Update() {
        if(Input.GetKeyDown(pauseKey)) {
            if(pausePanel.activeSelf)
                ResumeGame();
            else
                PauseGame();
        }
    }

    private void PauseGame() {
        Time.timeScale = 0;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        pausePanel.SetActive(true);
    }

    private void ResumeGame() {
        Time.timeScale = 1;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        pausePanel.SetActive(false);
    }

    private void SaveGame() {
        Debug.Log("Save game stuff here");
    }

    private void BackToMenu() {
        yesButtonEvent.RemoveAllListeners();
        yesButtonEvent.AddListener(() => {SceneManager.LoadScene(0);});
        unsaveDataWarning.SetActive(true);
    }

    private void Quit() {
        yesButtonEvent.RemoveAllListeners();
        yesButtonEvent.AddListener(() => {Debug.Log("Quitting Game"); Application.Quit();});
        unsaveDataWarning.SetActive(true);
    }

    private void CloseUnsaveWarning() {
        unsaveDataWarning.SetActive(false);
    }

    private void RunYesEvent() {
        yesButtonEvent.Invoke();
    }
}