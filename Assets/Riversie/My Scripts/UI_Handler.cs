using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Riversie
{
	public class UI_Handler : MonoBehaviour 
	{
        private GameManager_Master gameManagerMaster;
        public Text turnText;

		void OnEnable()
		{
            SetInitialRefrences();
            gameManagerMaster.EventToggleTurn += ToggleTurn;		
		}

		void OnDisable()
		{
            gameManagerMaster.EventToggleTurn -= ToggleTurn;
        }

		void SetInitialRefrences()
		{
            gameManagerMaster = GetComponent<GameManager_Master>();
		}

        void ToggleTurn()
        {
            if (gameManagerMaster.isBlackturn)
                turnText.text = "Black";
            else
                turnText.text = "White";
        }
	}
}

