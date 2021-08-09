using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riversie
{
	public class PlayerInput : MonoBehaviour 
	{
        private GameManager_Master gameManagerMaster;

        void Start()
        {
            SetInitialRefrences();
        }

        void OnMouseDown()
        {
            if (gameObject.activeSelf)
            {
                if (transform.CompareTag("Green"))
                {
                    for (int i = 0; i < 64; i++)
                    {
                        if(transform.name == gameManagerMaster.typeOfPieces[i].go.name)
                        {
                            gameManagerMaster.CallEventToggleTurn();
                            gameManagerMaster.CallEventPlayerInput(i);
                            break;
                        }
                    }
                }
            }
        }

        void SetInitialRefrences()
        {
            gameManagerMaster = GameObject.Find("GameManager").GetComponent<GameManager_Master>();
        }
	}
}

