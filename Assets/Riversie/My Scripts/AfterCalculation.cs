using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riversie
{
	public class AfterCalculation : MonoBehaviour 
	{
        private GameManager_Master gameManagerMaster;

		void OnEnable()
		{
            SetInitialRefrences();
            gameManagerMaster.EventDoneWithCalculation += DisableIsUsableParameters;		
		}

		void OnDisable()
		{
            gameManagerMaster.EventDoneWithCalculation -= DisableIsUsableParameters;
        }

		void SetInitialRefrences()
		{
            gameManagerMaster = GetComponent<GameManager_Master>();
		}

        void DisableIsUsableParameters()
        {
            //Debug.Log("yes");
            for (int i = 0; i < 64; i++)
            {
                gameManagerMaster.typeOfPieces[i].isUsed = false;
            }
        }
	}
}

