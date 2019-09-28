using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CnvInputMobileSwipe : MonoBehaviour
{
    private Vector2 touchOrigin = -Vector2.one; //Used to store location of screen touch origin for mobile controls.

    void SwipeControl(out float swipeHorizontalAxis, out float swipeVerticalAxis)
    {
        int horizontal = 0; //Used to store the horizontal move direction.
        int vertical = 0; //Used to store the vertical move direction.

        //Check if we are running either in the Unity editor or in a standalone build.
#if UNITY_STANDALONE || UNITY_WEBPLAYER

        //Get input from the input manager, round it to an integer and store in horizontal to set x axis move direction
        horizontal = (int) (Input.GetAxisRaw("Horizontal"));

        //Get input from the input manager, round it to an integer and store in vertical to set y axis move direction
        vertical = (int) (Input.GetAxisRaw("Vertical"));

        //Check if moving horizontally, if so set vertical to zero.
        if (horizontal != 0)
        {
            vertical = 0;
        }
        //Check if we are running on iOS, Android, Windows Phone 8 or Unity iPhone
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        //Check if Input has registered more than zero touches
        if (Input.touchCount > 0)
        {
            //Store the first touch detected.
            Touch myTouch = Input.touches[0];
            int touchIndex = 0;
            foreach (Touch touch in Input.touches)
            {
                myTouch = Input.touches[touchIndex];
                touchIndex++;
                //Check if the phase of that touch equals Began
                if (myTouch.phase == TouchPhase.Began)
                {
                    //If so, set touchOrigin to the position of that touch
                    touchOrigin = myTouch.position;
                    if(touchIndex == 0){
                        bool reallyHoldingBattleCard = false;
                        foreach(bool hold in BattleCardController.instance.holdingBC){
                            if(hold == true){
                                reallyHoldingBattleCard = true;
                                break;
                            }
                        }
                        if(reallyHoldingBattleCard == true){
                            horizontal = 0;
                            vertical = 0;
                            return;
                        }
                    }
                }
                
                //If the touch phase is not Began, and instead is equal to Ended and the x of touchOrigin is greater or equal to zero:
                else if (myTouch.phase == TouchPhase.Moved && touchOrigin.x >= 0)
                {
                    //Set touchEnd to equal the position of this touch
                    Vector2 touchEnd = myTouch.position;
                    
                    //Calculate the difference between the beginning and end of the touch on the x axis.
                    float x = touchEnd.x - touchOrigin.x;
                    
                    //Calculate the difference between the beginning and end of the touch on the y axis.
                    float y = touchEnd.y - touchOrigin.y;
                    
                    //Set touchOrigin.x to -1 so that our else if statement will evaluate false and not repeat immediately.
                    touchOrigin.x = -1;
                    
                    //Check if the difference along the x axis is greater than the difference along the y axis.
                    if (Mathf.Abs(x) > Mathf.Abs(y))
                        //If x is greater than zero, set horizontal to 1, otherwise set it to -1
                        horizontal = x > 0 ? 1 : -1;
                    else
                        //If y is greater than zero, set horizontal to 1, otherwise set it to -1
                        vertical = y > 0 ? 1 : -1;
                }     
            }
        }
#endif //End of mobile platform dependendent compilation section started above with #elif

        swipeHorizontalAxis = horizontal;
        swipeVerticalAxis = vertical;
    }

    /*
    //inside class // Swipe Controls
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;
    
    public void SwipeTouch()
    {

        if(Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if(t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x,t.position.y);
            }

            if(t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x,t.position.y);
                            
                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
                
                //normalize the 2d vector
                currentSwipe.Normalize();
    
                //swipe upwards
                if(currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("up swipe");
                    swipeVerticalAxis = currentSwipe.y;

                }
                //swipe down
                if(currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
                {
                    Debug.Log("down swipe");
                    swipeVerticalAxis = currentSwipe.y;
                }
                //swipe left
                if(currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("left swipe");
                    swipeHorizontalAxis = currentSwipe.x;            
                }
                //swipe right
                if(currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
                {
                    Debug.Log("right swipe");
                    swipeHorizontalAxis = currentSwipe.x;            
                }
            }


        }
    }

    public void SwipeMouse()
    {
        if(Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        }
        if(Input.GetMouseButtonUp(0))
        {
                //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x,Input.mousePosition.y);
        
                //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
            
            //normalize the 2d vector
            currentSwipe.Normalize();
    
            //swipe upwards
            if(currentSwipe.y > 0  && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
            {
                Debug.Log("up swipe");
                swipeVerticalAxis = currentSwipe.y;
            }
            //swipe down
            if(currentSwipe.y < 0 && currentSwipe.x > -0.5f &&  currentSwipe.x < 0.5f)
            {
                Debug.Log("down swipe");
                swipeVerticalAxis = currentSwipe.y;
            }
            //swipe left
            if(currentSwipe.x < 0 &&  currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("left swipe");
                swipeHorizontalAxis = currentSwipe.x;
            }
            //swipe right
            if(currentSwipe.x > 0 &&  currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                Debug.Log("right swipe");
                swipeHorizontalAxis = currentSwipe.x;            
            }

        }
    }
    */
}