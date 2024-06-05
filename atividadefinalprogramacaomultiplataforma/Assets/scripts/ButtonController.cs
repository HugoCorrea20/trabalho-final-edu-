using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public jogador playerScript; // Referência ao script jogador
    

   

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool jump = false;
    private bool pickupOrDigOrOpen = false;
    private bool moveUp = false;
    private bool moveDown = false;

    public void OnButtonLeftDown()
    {
        moveLeft = true;
    }

    public void OnButtonLeftUp()
    {
        moveLeft = false;
    }

    public void OnButtonRightDown()
    {
        moveRight = true;
    }

    public void OnButtonRightUp()
    {
        moveRight = false;
    }

    public void OnButtonJumpDown()
    {
        jump = true;
    }

    public void OnButtonPickupOrDigOrOpenDown()
    {
        pickupOrDigOrOpen = true;
    }

    public void OnButtonUpDown()
    {
        moveUp = true;
    }

    public void OnButtonUpUp()
    {
        moveUp = false;
    }

    public void OnButtonDownDown()
    {
        moveDown = true;
    }

    public void OnButtonDownUp()
    {
        moveDown = false;
    }

    void Update()
    {
        if (moveLeft)
        {
            playerScript.MoveLeft();
        }
        else if (moveRight)
        {
            playerScript.MoveRight();
        }
        else
        {
            playerScript.StopMoving();
        }

        if (jump)
        {
            playerScript.Jump();
            jump = false; // Resetar o estado de pulo
        }

        if (pickupOrDigOrOpen)
        {
            playerScript.PickupOrDigOrOpen();
            pickupOrDigOrOpen = false; // Resetar o estado de pegar/cavar/abrir
        }

        if (moveUp)
        {
            playerScript.MoveUp();
        }

        if (moveDown)
        {
            playerScript.MoveDown();
        }
    }
}