/*

*/

using System;
using QFramework;
using TheaterOfKismet.UI;
using UnityEngine;

namespace TheaterOfKismet
{
    public class GameUpdate: MonoBehaviour
    , IController
    {
        private GameStateSystem mGameState;
        
        private void Start()
        {
            mGameState = this.GetSystem<GameStateSystem>();
            
            //测试


            UIKit.OpenPanel<MainUI>();
            
            var model = this.GetModel<MainModel>();

            model.dragDirection.Register(dir =>
            {
                if(dir != 0)
                    Debug.Log($"Dir -> {dir}");
            });
        }

        private void Update()
        {
            mGameState.Update(Time.deltaTime);
            
        }

        public IArchitecture GetArchitecture()
         {
             return GameCore.Interface;
         }
    } 
} 

