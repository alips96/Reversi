using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Riversie
{
	public class GameOver : MonoBehaviour 
	{
        private GameManager_Master gameManagerMaster;
        public GameObject panelGameOver;
        int BlackCounter;
        int whiteCounter;
        public Text numberOfBlackPieces;
        public Text NumberOfWhitePieces;
        public Text winnerAnnouncer;

		void OnEnable()
		{
            SetInitialRefrences();
            gameManagerMaster.EventGameOver += CarryOutGameOver;		
		}

		void OnDisable()
		{
            gameManagerMaster.EventGameOver -= CarryOutGameOver;
        }

		void SetInitialRefrences()
		{
            gameManagerMaster = GetComponent<GameManager_Master>();
		}

        void CarryOutGameOver()
        {
            for (int i = 0; i < 64; i++)
            {
                if (gameManagerMaster.typeOfPieces[i].go.activeSelf)
                {
                    if (gameManagerMaster.typeOfPieces[i].go.CompareTag("Black"))
                    {
                        BlackCounter++;
                    }
                    else if (gameManagerMaster.typeOfPieces[i].go.CompareTag("White"))
                    {
                        whiteCounter++;
                    }
                }
            }

            if (panelGameOver != null)
            {
                panelGameOver.SetActive(true);

                if (BlackCounter > whiteCounter)
                    winnerAnnouncer.text = "Black Wins!";
                else
                    if (whiteCounter > BlackCounter)
                    winnerAnnouncer.text = "White Wins!";
                else
                    winnerAnnouncer.text = "Draw!";

                numberOfBlackPieces.text = BlackCounter.ToString();
                NumberOfWhitePieces.text = whiteCounter.ToString();
            }            
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
	}
}

