using UnityEngine;

public class VirtualJoystick : MonoBehaviour
{
    public MovimentoNavio navioScript; // Referência ao script MovimentoNavio

    private bool moveLeft = false;
    private bool moveRight = false;
    private bool attack = false;

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

    public void OnButtonAttackDown()
    {
        attack = true;
    }

    void Update()
    {
        if (moveLeft)
        {
            navioScript.MoveLeft();
        }
        else if (moveRight)
        {
            navioScript.MoveRight();
        }
        else
        {
            navioScript.StopMoving();
        }

        if (attack)
        {
            navioScript.AtirarBala();
            attack = false; // Resetar o estado de ataque
        }
    }
}
