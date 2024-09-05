using System.Collections.Generic;
using Game.Core;
using QFramework;
using UnityEngine;

namespace Game
{
    public class CardsMrg : MonoBehaviour
        , IController
    {
        public Dictionary<int, Card> cards = new ();
        
        
        private void Start()
        {
        }

        
        
        public IArchitecture GetArchitecture()
        {
            return GameCore.Interface;
        }
    } 
} 

