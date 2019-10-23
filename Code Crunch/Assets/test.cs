using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using EventTypes;

public class test : MonoBehaviour
{
    private void Update()
    {
        if(InputManager.KeyReleased_A())
        {
            SceneLoader.changeScene(SCENE_TYPE.game_scene);
        }

        if (InputManager.KeyReleased_D())
        {
            SceneLoader.changeScene(SCENE_TYPE.menu_scene);
        }
    }
}
