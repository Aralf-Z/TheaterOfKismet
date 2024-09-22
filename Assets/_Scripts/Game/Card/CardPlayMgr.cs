using System;
using Game.Core;
using QFramework;
using UnityEngine;

namespace Game
{
    public class CardPlayMgr : MonoBehaviour
        , IController
    {
        public DragArea dragArea;
        public GameCardMgr gameCardsMgr;
        public UICardsMgr uiCardsMgr;
        
        private CardSystem mCardSystem;

        private void Start()
        {
            mCardSystem = this.GetSystem<CardSystem>();
        }

        private void Update()
        {
            mCardSystem.OnUpdate(Time.deltaTime);
        }

        public IArchitecture GetArchitecture()
        {
            return GameCore.Interface;
        }
    } 
} 

