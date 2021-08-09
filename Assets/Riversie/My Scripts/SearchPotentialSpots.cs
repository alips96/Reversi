using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Riversie
{
    public class SearchPotentialSpots : MonoBehaviour
    {
        private GameManager_Master gameManagerMaster;
        private Stack<GameObject> myStack = new Stack<GameObject>();
        private bool isSuccessful = false;
        private bool shouldTheGameBeOver = false;

        void OnEnable()
        {
            SetInitialRefrences();
            gameManagerMaster.EventPotentialCalculation += SearchForPotentialSpots;
        }

        void OnDisable()
        {
            gameManagerMaster.EventPotentialCalculation -= SearchForPotentialSpots;
        }

        void SetInitialRefrences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();
        }

        void SearchForPotentialSpots(string friendlyTag)
        {
            //Debug.Log(friendlyTag);
            for (int i = 0; i < 64; i++)
            {
                if (gameManagerMaster.typeOfPieces[i].go.activeSelf &&
                         gameManagerMaster.typeOfPieces[i].countable &&
                         !gameManagerMaster.typeOfPieces[i].go.CompareTag("Green"))
                {

                    //efficiency calculations
                    if ((i - 1 >= 0 &&
                        gameManagerMaster.typeOfPieces[i - 1].position.y != 7 &&
                        gameManagerMaster.typeOfPieces[i - 1].go.activeSelf &&
                        !gameManagerMaster.typeOfPieces[i - 1].go.CompareTag("Green")) || i - 1 < 0 || gameManagerMaster.typeOfPieces[i - 1].position.y == 7)
                    {
                        if ((i + 1 < 64 &&
                        gameManagerMaster.typeOfPieces[i + 1].position.y != 0 &&
                        gameManagerMaster.typeOfPieces[i + 1].go.activeSelf &&
                        !gameManagerMaster.typeOfPieces[i + 1].go.CompareTag("Green")) || i + 1 >= 64 || gameManagerMaster.typeOfPieces[i + 1].position.y == 0)
                        {
                            if ((i + 8 < 64 &&
                         gameManagerMaster.typeOfPieces[i + 8].go.activeSelf &&
                         !gameManagerMaster.typeOfPieces[i + 8].go.CompareTag("Green")) || i + 8 >= 64)
                            {
                                if ((i - 8 >= 0 &&
                        gameManagerMaster.typeOfPieces[i - 8].go.activeSelf &&
                        !gameManagerMaster.typeOfPieces[i - 8].go.CompareTag("Green")) || i - 8 < 0)
                                {
                                    if ((i - 7 >= 0 &&
                         gameManagerMaster.typeOfPieces[i - 7].position.y != 0 &&
                         gameManagerMaster.typeOfPieces[i - 7].go.activeSelf &&
                         !gameManagerMaster.typeOfPieces[i - 7].go.CompareTag("Green")) || i - 7 < 0 || gameManagerMaster.typeOfPieces[i - 7].position.y == 0)
                                    {
                                        if ((i + 7 < 64 &&
                          gameManagerMaster.typeOfPieces[i + 7].position.y != 7 &&
                          gameManagerMaster.typeOfPieces[i + 7].go.activeSelf &&
                          !gameManagerMaster.typeOfPieces[i + 7].go.CompareTag("Green")) || i + 7 >= 64 || gameManagerMaster.typeOfPieces[i + 7].position.y == 7)
                                        {
                                            if ((i + 9 < 64 &&
                           gameManagerMaster.typeOfPieces[i + 9].position.y != 0 &&
                           gameManagerMaster.typeOfPieces[i + 9].go.activeSelf &&
                           !gameManagerMaster.typeOfPieces[i + 9].go.CompareTag("Green")) || i + 9 >= 64 || gameManagerMaster.typeOfPieces[i + 9].position.y == 0)
                                            {
                                                if ((i - 9 >= 0 &&
                         gameManagerMaster.typeOfPieces[i - 9].position.y != 7 &&
                         gameManagerMaster.typeOfPieces[i - 9].go.activeSelf &&
                         !gameManagerMaster.typeOfPieces[i - 9].go.CompareTag("Green")) || i - 9 < 0 || gameManagerMaster.typeOfPieces[i - 9].position.y == 7)
                                                {
                                                    //Debug.Log(i);
                                                    gameManagerMaster.typeOfPieces[i].countable = false;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (gameManagerMaster.typeOfPieces[i].countable)
                    {
                        //Debug.Log(i);
                        if (i - 1 >= 0 &&
                       gameManagerMaster.typeOfPieces[i - 1].position.y != 7 &&
                       !gameManagerMaster.typeOfPieces[i - 1].go.activeSelf &&
                       !gameManagerMaster.typeOfPieces[i - 1].isUsed)
                        {
                            gameManagerMaster.typeOfPieces[i - 1].isUsed = true;
                            //Debug.Log(i - 1);
                            if (CheckPotentialSpots(i - 1, friendlyTag))
                            {
                                ApplyChanges(i - 1);
                                //Debug.Log(i - 1);
                            }
                        }

                        if (i + 1 < 64 &&
                            gameManagerMaster.typeOfPieces[i + 1].position.y != 0 &&
                            !gameManagerMaster.typeOfPieces[i + 1].go.activeSelf &&
                            !gameManagerMaster.typeOfPieces[i + 1].isUsed)
                        {
                            gameManagerMaster.typeOfPieces[i + 1].isUsed = true;
                            //Debug.Log(i + 1);
                            if (CheckPotentialSpots(i + 1, friendlyTag))
                            {
                                ApplyChanges(i + 1);
                                //Debug.Log(i + 1);
                            }
                        }

                        if (i + 8 < 64 &&
                             !gameManagerMaster.typeOfPieces[i + 8].go.activeSelf &&
                             !gameManagerMaster.typeOfPieces[i + 8].isUsed)
                        {

                            gameManagerMaster.typeOfPieces[i + 8].isUsed = true;
                            //Debug.Log(i + 8);
                            //Debug.Log(i + gameManagerMaster.typeOfPieces[i + 8].isUsed.ToString());
                            if (CheckPotentialSpots(i + 8, friendlyTag))
                            {
                                ApplyChanges(i + 8);
                                //Debug.Log(i + 8);
                            }
                        }

                        if (i - 8 >= 0 &&
                            !gameManagerMaster.typeOfPieces[i - 8].go.activeSelf &&
                            !gameManagerMaster.typeOfPieces[i - 8].isUsed)
                        {
                            gameManagerMaster.typeOfPieces[i - 8].isUsed = true;
                            //Debug.Log(i - 8);
                            if (CheckPotentialSpots(i - 8, friendlyTag))
                            {
                                ApplyChanges(i - 8);
                                //Debug.Log(i - 8);
                            }
                        }

                        if (i - 7 >= 0 &&
                             gameManagerMaster.typeOfPieces[i - 7].position.y != 0 &&
                             !gameManagerMaster.typeOfPieces[i - 7].go.activeSelf &&
                             !gameManagerMaster.typeOfPieces[i - 7].isUsed)
                        {

                            gameManagerMaster.typeOfPieces[i - 7].isUsed = true;
                            //Debug.Log(i - 7);
                            if (CheckPotentialSpots(i - 7, friendlyTag))
                            {
                                ApplyChanges(i - 7);
                            }
                        }

                        if (i + 7 < 64 &&
                              gameManagerMaster.typeOfPieces[i + 7].position.y != 7 &&
                             !gameManagerMaster.typeOfPieces[i + 7].go.activeSelf &&
                              !gameManagerMaster.typeOfPieces[i + 7].isUsed)
                        {
                            gameManagerMaster.typeOfPieces[i + 7].isUsed = true;
                            //Debug.Log(i + 7);
                            if (CheckPotentialSpots(i + 7, friendlyTag))
                            {
                                ApplyChanges(i + 7);
                            }
                        }

                        if (i + 9 < 64 &&
                              gameManagerMaster.typeOfPieces[i + 9].position.y != 0 &&
                              !gameManagerMaster.typeOfPieces[i + 9].go.activeSelf &&
                              !gameManagerMaster.typeOfPieces[i + 9].isUsed)
                        {
                            gameManagerMaster.typeOfPieces[i + 9].isUsed = true;
                            //Debug.Log(i + 9);
                            if (CheckPotentialSpots(i + 9, friendlyTag))
                            {
                                ApplyChanges(i + 9);
                            }
                        }

                        if (i - 9 >= 0 &&
                             gameManagerMaster.typeOfPieces[i - 9].position.y != 7 &&
                             !gameManagerMaster.typeOfPieces[i - 9].go.activeSelf &&
                             !gameManagerMaster.typeOfPieces[i - 9].isUsed)
                        {
                            gameManagerMaster.typeOfPieces[i - 9].isUsed = true;
                            //Debug.Log(i - 9);
                            if (CheckPotentialSpots(i - 9, friendlyTag))
                            {
                                ApplyChanges(i - 9);
                            }
                        }
                    }

                }
            } //End of main for

            gameManagerMaster.CallEventDoneWithCalculation(); //isUsablesAreDisabled

            for (int k = 0; k < 64; k++)
            {
                if (gameManagerMaster.typeOfPieces[k].go.CompareTag("Green") && gameManagerMaster.typeOfPieces[k].go.activeSelf)
                {
                    if (shouldTheGameBeOver)
                        shouldTheGameBeOver = false;
                    return;
                }

            }
            if (!shouldTheGameBeOver)
            {
                shouldTheGameBeOver = true;
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
            else
            {
                gameManagerMaster.CallEventGameOver();
            }

        }


        bool CheckPotentialSpots(int index, string myFriendlyTag)
        {
            isSuccessful = false;
            myStack.Clear();
            int yPosition = (int)gameManagerMaster.typeOfPieces[index].position.y;
            //int xPosition = (int) gameManagerMaster.typeOfPieces[index].position.x;

            //Debug.Log(index);

            //Horizontal , Left
            for (int j = 1; j <= yPosition; j++)
            {
                Calculate(index, j, myFriendlyTag);

                if (isSuccessful)
                {
                    myStack.Clear();
                    isSuccessful = false;
                    return true;
                }
                else if (myStack.Count == 0)
                {
                    isSuccessful = false;
                    break;
                }

            }
            myStack.Clear();
            //Debug.Log("1");
            //Horizontal , Right
            for (int j = -1; j >= -(7 - yPosition); j--)
            {
                Calculate(index, j, myFriendlyTag);

                if (isSuccessful)
                {
                    myStack.Clear();
                    isSuccessful = false;
                    return true;
                }
                else if (myStack.Count == 0)
                {
                    isSuccessful = false;
                    break;
                }
            }
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("2");
            //Vertical , Up
            if (CarryOn(8, index, myFriendlyTag))
                return true;
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("3");
            //Vertical , Down
            if (CarryOn(-8, index, myFriendlyTag))
                return true;
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("4");
            //Up Right
            if (yPosition != 7)
            {
                if (CarryOn(7, index, myFriendlyTag))
                    return true;
            }
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("5");
            //Up Left
            if (yPosition != 0)
            {
                if (CarryOn(9, index, myFriendlyTag))
                    return true;
            }
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("6");

            //Down Right
            if (yPosition != 7)
            {
                if (CarryOn(-9, index, myFriendlyTag))
                    return true;
            }
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("7");
            //Down left
            if (yPosition != 0)
            {
                if (CarryOn(-7, index, myFriendlyTag))
                    return true;
            }
            myStack.Clear();
            isSuccessful = false;
            //Debug.Log("8");
            return false;
        }

        void Calculate(int i, int j, string myFriendlyTag)
        {
            if (gameManagerMaster.typeOfPieces[i - j].go.activeSelf
                && !gameManagerMaster.typeOfPieces[i - j].go.CompareTag(myFriendlyTag)
                && !gameManagerMaster.typeOfPieces[i - j].go.CompareTag("Green"))
            {
                myStack.Push(gameManagerMaster.typeOfPieces[i - j].go);
            }

            else
            if (myStack.Count > 0
                && gameManagerMaster.typeOfPieces[i - j].go.CompareTag(myFriendlyTag)
                && gameManagerMaster.typeOfPieces[i - j].go.activeSelf
                )
            {
                isSuccessful = true;
            }

            else
            {
                myStack.Clear();
            }
        }

        bool CarryOn(int counter, int index, string myFriendlyTag)
        {
            //Debug.Log(index);
            int step = counter;

            while (index - counter >= 0 && index - counter < 64)
            {
                //Debug.Log(gameManagerMaster.typeOfPieces[index - counter].position);
                Calculate(index, counter, myFriendlyTag);

                if (isSuccessful)
                {
                    return true;
                }
                else
                    if ((gameManagerMaster.typeOfPieces[index - counter].position.y == 0 && (step == 9 || step == -7)) ||
                        myStack.Count == 0 ||
                        gameManagerMaster.typeOfPieces[index - counter].position.y == 7 && (step == 7 || step == -9))
                {
                    isSuccessful = false;
                    break;
                }


                counter += step;
            }
            return false;
        }

        void ApplyChanges(int i)
        {
            gameManagerMaster.typeOfPieces[i].go.SetActive(true);
            gameManagerMaster.typeOfPieces[i].go.GetComponent<MeshRenderer>().material.color = Color.green;
            gameManagerMaster.typeOfPieces[i].go.tag = "Green";
        }
    }
}

