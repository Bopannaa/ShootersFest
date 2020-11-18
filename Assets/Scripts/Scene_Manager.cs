﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class Scene_Manager : Singleton<Scene_Manager>
{   
    public Action CreatePersistableObjects; 

    public InputControl inputControl;

    void Start()
    {
        if(CreatePersistableObjects != null)
        {
            CreatePersistableObjects();
        }
    }

    void Awake()
    {
        inputControl = new InputControl();
    }

    public void OnEnable()
    {
        ShopScene.ActionBackButton  += LoadStartScene;
        StartScene.ActionShopButton += LoadShopScene;
        StartScene.ActionPlayButton += LoadLevelScene;
        LevelScene.ActionBackButton += LoadStartScene;
        LevelChooser.ActionLevelButton += LoadGameScene;
        StartScene.ActionQuitButton += QuitGame;
        GameScene.ActionPauseButton += LoadStartScene; // to be removed
        inputControl.Enable();
    }

    void OnDisable()
    {
        ShopScene.ActionBackButton  -= LoadStartScene;
        StartScene.ActionShopButton -= LoadShopScene;
        StartScene.ActionPlayButton -= LoadLevelScene;
        LevelScene.ActionBackButton -= LoadStartScene;
        LevelChooser.ActionLevelButton -= LoadGameScene;
        StartScene.ActionQuitButton -= QuitGame;
        GameScene.ActionPauseButton -= LoadStartScene; // to be removed
        inputControl.Disable();
    }

    public void LoadShopScene()
    {
        SceneManager.LoadScene("ShopScene");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadLevelScene()
    {
        SceneManager.LoadScene("LevelScene");
    }

    public void LoadGameScene(int level)
    {
        SceneManager.LoadScene("GameScene");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}

