using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Riversie
{
	public class Attack : MonoBehaviour 
	{
        private GameManager_Master gameManagerMaster;
        private Stack<GameObject> myStack = new Stack<GameObject>();
        private bool isSuccessful = false;

        void OnEnable()
		{
            SetInitialRefrences();
            gameManagerMaster.EventPlayerInput += PrepareToDamage;	
		}

		void OnDisable()
		{
            gameManagerMaster.EventPlayerInput -= PrepareToDamage;
        }

		void SetInitialRefrences()
		{
            gameManagerMaster = GetComponent<GameManager_Master>();
		}

        void PrepareToDamage(int positionOfThePiece)
        {
            if (gameManagerMaster.isBlackturn)
            {
                gameManagerMaster.typeOfPieces[positionOfThePiece].go.GetComponent<MeshRenderer>().material.color = Color.black;
                gameManagerMaster.typeOfPieces[positionOfThePiece].go.tag = "Black";
                ApplyDamage("Black", positionOfThePiece);
            }

            else
            {
                gameManagerMaster.typeOfPieces[positionOfThePiece].go.GetComponent<MeshRenderer>().material.color = Color.white;
                gameManagerMaster.typeOfPieces[positionOfThePiece].go.tag = "White";
                ApplyDamage("White", positionOfThePiece);
            }
        }

        void ApplyDamage(string myFriendlyTag,int index)
        {
            myStack.Clear();
            isSuccessful = false;
            int yPosition = (int) gameManagerMaster.typeOfPieces[index].position.y;
            //int xPosition = (int) gameManagerMaster.typeOfPieces[index].position.x;

            //Horizontal , Left
            for (int j = 1; j <= yPosition; j++)
            {
                Calculate(index,j,myFriendlyTag);

                if (myStack.Count == 0 || isSuccessful)
                {
                    break;
                }

            }
            if (myStack.Count > 0 && !isSuccessful)
                myStack.Clear();

            ApplyColorChanges(myFriendlyTag);
            myStack.Clear();

            //Horizontal , Right
            for (int j = -1; j >= -(7 - yPosition); j--)
            {
                Calculate(index, j, myFriendlyTag);
                if(myStack.Count == 0 || isSuccessful)
                {
                    break;
                }
            }

            if (myStack.Count > 0 && !isSuccessful)
                myStack.Clear();

            ApplyColorChanges(myFriendlyTag);
            myStack.Clear();

            //Vertical , Up
            CarryOn(8, index, myFriendlyTag);

            //Vertical , Down
            CarryOn(-8, index, myFriendlyTag);

            //Up Right
            if(yPosition != 7)
                CarryOn(7, index, myFriendlyTag);

            //Up Left
            if (yPosition != 0)
                CarryOn(9, index, myFriendlyTag);

            //Down Right
            if (yPosition != 7)
                CarryOn(-9, index, myFriendlyTag);

            //Down left
            if (yPosition != 0)
                CarryOn(-7, index, myFriendlyTag);
            
            //next steps

            for (int i = 0; i < 64; i++) //disable the green gameObjects
            {
                if (gameManagerMaster.typeOfPieces[i].go.activeSelf)
                {
                    if (gameManagerMaster.typeOfPieces[i].go.CompareTag("Green"))
                    {
                        gameManagerMaster.typeOfPieces[i].go.SetActive(false);
                    }
                }
            }

            gameManagerMaster.gameOverCounter++;

            if (gameManagerMaster.gameOverCounter >= 64)
                gameManagerMaster.CallEventGameOver();
            else
            {
                gameManagerMaster.isBlackturn = !gameManagerMaster.isBlackturn; //Player turn is toggled
                gameManagerMaster.CallEventToggleTurn();

                if (gameManagerMaster.isBlackturn)
                {
                    gameManagerMaster.CallEventPotentialCalculation("Black");
                }

                else
                {
                    gameManagerMaster.CallEventPotentialCalculation("White");
                }
                  
            }

        }

        void CarryOn(int counter,int index,string myFriendlyTag)
        {
            isSuccessful = false;
            myStack.Clear();
            int step = counter;

            while (index - counter >= 0 && index - counter < 64)
            {
                //Debug.Log(index - counter);
                Calculate(index, counter, myFriendlyTag);

                if ((gameManagerMaster.typeOfPieces[index - counter].position.y == 0 && (step == 9 || step == -7)) ||
                    myStack.Count == 0 || isSuccessful ||
                    gameManagerMaster.typeOfPieces[index - counter].position.y == 7 && (step == 7 || step == -9))
                {
                    break;
                }

                counter += step;
            }
            if (myStack.Count > 0 && !isSuccessful)
                myStack.Clear();
            ApplyColorChanges(myFriendlyTag);
            myStack.Clear();
        }


        void Calculate(int i,int j,string myFriendlyTag)
        {
            //Debug.Log(myFriendlyTag);
            if (gameManagerMaster.typeOfPieces[i - j].go.activeSelf 
                && !gameManagerMaster.typeOfPieces[i - j].go.CompareTag(myFriendlyTag)
                && !gameManagerMaster.typeOfPieces[i - j].go.CompareTag("Green"))
            {
                myStack.Push(gameManagerMaster.typeOfPieces[i - j].go);
            }

            else
            if(myStack.Count > 0 
                && gameManagerMaster.typeOfPieces[i - j].go.CompareTag(myFriendlyTag)
                && gameManagerMaster.typeOfPieces[i - j].go.activeSelf)
            {
                isSuccessful = true;
            }

            else
            {
                myStack.Clear();
            }
        }

        void ApplyColorChanges(string tag)
        {
            isSuccessful = false;
            if (myStack.Count > 0)
            {
                if (tag == "Black")
                {
                    foreach (GameObject go in myStack)
                    {
                        go.GetComponent<MeshRenderer>().material.color = Color.black;
                        go.tag = "Black";
                    }
                }
                else
                {
                    foreach (GameObject go in myStack)
                    {
                        go.GetComponent<MeshRenderer>().material.color = Color.white;
                        go.tag = "White";
                    }
                }
            }
        }
	}
}

