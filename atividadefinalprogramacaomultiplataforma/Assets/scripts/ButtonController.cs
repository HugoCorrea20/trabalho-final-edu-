using UnityEngine;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour
{
    public jogador playerScript; // Referência ao script jogador

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool jump = false;

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
    }
}
