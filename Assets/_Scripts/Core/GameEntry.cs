using Game.Core;
using QFramework;
using UnityEngine;

namespace Game
{
    public class GameEntry: MonoBehaviour
    , IController
    {
         private void Start()
         {
              this.GetSystem<CardSystem>().GameEntry();
         }
          
         public IArchitecture GetArchitecture()
         {
             return GameCore.Interface;
         }
    } 
} 

