using UnityEngine;

public class FootCollision : MonoBehaviour
{
    private bool leftToeInside = false;
    private bool leftHeelInside = false;
    private bool rightToeInside = false;
    private bool rightHeelInside = false;

    public Animator animator; // アニメーターコンポーネントの指定

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name == "LeftToe")
        {
            leftToeInside = true;
        }
        else if (collider.gameObject.name == "LeftHeel")
        {
            leftHeelInside = true;
        }
        else if (collider.gameObject.name == "RightToe")
        {
            rightToeInside = true;
        }
        else if (collider.gameObject.name == "RightHeel")
        {
            rightHeelInside = true;
        }

        CheckAllPartsInside();
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.name == "LeftToe")
        {
            leftToeInside = false;
        }
        else if (collider.gameObject.name == "LeftHeel")
        {
            leftHeelInside = false;
        }
        else if (collider.gameObject.name == "RightToe")
        {
            rightToeInside = false;
        }
        else if (collider.gameObject.name == "RightHeel")
        {
            rightHeelInside = false;
        }

        CheckAllPartsInside();
    }

    private void CheckAllPartsInside()
    {
        bool isIdle = leftToeInside && leftHeelInside && rightToeInside && rightHeelInside;
        bool isRunning = (leftToeInside && !leftHeelInside && rightToeInside && !rightHeelInside) || (!leftToeInside && !leftHeelInside && !rightToeInside && !rightHeelInside) || (leftToeInside && leftHeelInside && rightToeInside && !rightHeelInside) || (leftToeInside && leftHeelInside && rightToeInside && !rightHeelInside);
        bool isWalking = (leftToeInside && leftHeelInside && !rightToeInside && rightHeelInside) || (!leftToeInside && leftHeelInside && rightToeInside && rightHeelInside);

        animator.SetBool("isIdle", isIdle);
        animator.SetBool("isRunning", isRunning);
        animator.SetBool("isWalking", isWalking);
    }
}
