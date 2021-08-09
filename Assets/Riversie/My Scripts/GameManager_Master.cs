using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riversie
{
    public class GameManager_Master : MonoBehaviour
    {
        //Counters
        private int GameOverCounter; //Counter for GameOver
        private int k;

        //Events
        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventGameOver;
        public event GeneralEventHandler EventDoneWithCalculation;
        public event GeneralEventHandler EventToggleTurn;

        public delegate void ColorEventHandler(GameObject go);
        public event ColorEventHandler EventBlackToWhiteAnimation;
        public event ColorEventHandler EventWhiteToBlackAnimation;

        public delegate void PositionEventHandler(int positionOfClick);
        public event PositionEventHandler EventPlayerInput;

        public delegate void PotentialEventHandler(string tagString);
        public event PotentialEventHandler EventPotentialCalculation;

        //Turn controller
        public bool isBlackturn = true;

        //Count until game over event occurs
        public int gameOverCounter;

        [System.Serializable]
        public class Pieces 
        {
            public GameObject go;
            public Vector2 position;
            public bool countable = true;
            public bool isUsed;

            public Pieces(GameObject myGameObject,Vector2 myPosition,bool isCountableOrNot,bool isUsedOrNot)
            {
                go = myGameObject;
                position = myPosition;
                countable = isCountableOrNot;
                isUsed = isUsedOrNot;
            }
        }

        public List<Pieces> typeOfPieces = new List<Pieces>();


		void Start()
		{
            SetItemsPosition();
        }

        void SetItemsPosition()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    typeOfPieces[k].position = new Vector2(i, j);
                    typeOfPieces[k].countable = true;
                    k++;
                }
            }
        }

        public void CallEventGameOver()
        {
            if (EventGameOver != null)
                EventGameOver();
        }

        public void CallEventPlayerInput(int position)
        {
            if (EventPlayerInput != null)
                EventPlayerInput(position);
        }

        public void CallEventBlackToWhiteAnimation(GameObject go)
        {
            if (EventBlackToWhiteAnimation != null)
                EventBlackToWhiteAnimation(go);
        }

        public void CallEventWhiteToBlackAnimation(GameObject go)
        {
            if (EventWhiteToBlackAnimation != null)
                EventWhiteToBlackAnimation(go);
        }

        public void CallEventPotentialCalculation(string myFriendlyTag)
        {
            if (EventPotentialCalculation != null)
                EventPotentialCalculation(myFriendlyTag);
        }

        public void CallEventDoneWithCalculation()
        {
            if (EventDoneWithCalculation != null)
                EventDoneWithCalculation();
        }

        public void CallEventToggleTurn()
        {
            if (EventToggleTurn != null)
                EventToggleTurn();
        }
    }
}

