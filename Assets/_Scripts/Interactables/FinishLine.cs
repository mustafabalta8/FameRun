using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour,  IInteractable
{
    [SerializeField] Transform[] multiplierPositions;

    public void Interact()
    {
        HandleFinalMovement();
    }
    private void HandleFinalMovement()
    {

        GameManager.GameState = GameStates.Final;

        //8  pos
        float positionDeterminer = Popularity.instance.TempPopularity / 100f;
        int lastIndex = multiplierPositions.Length - 1;
        //print(positionDeterminer);

        if (positionDeterminer > .9f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex].position);
        }
        else if (positionDeterminer > .8f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 1].position);
        }
        else if (positionDeterminer > .7f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 2].position);
        }
        else if (positionDeterminer > .55f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 3].position);
        }
        else if (positionDeterminer > .45f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 4].position);
        }
        else if (positionDeterminer > .30f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 5].position);
        }
        else if (positionDeterminer > .15f)
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 6].position);
        }
        else
        {
            PlayerManager.instance.FinalMove(multiplierPositions[lastIndex - 7].position);
        }
    }


}
