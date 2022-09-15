using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerManager : Character
{
    [Header("Movement")]
    [SerializeField] private Vector3 movementDirection;
    [SerializeField] private float forwardSpeed;
    [SerializeField] private float swerveSpeed;
    [SerializeField] private float sideMovementLimit;


    private float lastFrameFingerPositionX;
    private float moveFactorX;

    [SerializeField] private GameObject model01, model02, model03, model04;


    public static PlayerManager instance;

    [SerializeField] private GameObject popularityBar;
    [SerializeField] float finalWalkSpeed = 5;

    private void Awake()
    {
        Singelton();
    }
    private void Singelton()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
        if (GameManager.GameState == GameStates.InGame)
        {
            HandleSideMove();
            MoveForward();
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var interactible = other.GetComponent<IInteractable>();
        if (interactible != null)
        {
            interactible.Interact();
        }

    }

    public void UpdateCharacterState(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Desperate:
                model01.SetActive(true);
                model02.SetActive(false);
                animator = model01.GetComponent<Animator>();
                UpdateAnimationState(AnimationState.Walking);
                break;
            case CharacterState.Modest:
                model01.SetActive(false);
                model02.SetActive(true);
                model03.SetActive(false);
                animator = model02.GetComponent<Animator>();
                break;
            case CharacterState.Famous:
                model02.SetActive(false);
                model03.SetActive(true);
                model04.SetActive(false);
                animator = model03.GetComponent<Animator>();
                break;
            case CharacterState.Superstar:
                model03.SetActive(false);
                model04.SetActive(true);
                animator = model04.GetComponent<Animator>();
                break;
        }
    }
    private void MoveForward()
    {
        transform.Translate(movementDirection * Time.deltaTime * forwardSpeed);//

    }
    private void HandleSideMove()
    {
        GetInput();
        // ball.position = new Vector3(Mathf.SmoothDamp(ball.position.x,DesireBallPos.x,ref velocity , maxSpeed)
        //,ball.position.y,ball.position.z);
        float swerveAmount = swerveSpeed * moveFactorX * Time.deltaTime;

        var currentPos = transform.position; 
        currentPos.x += swerveAmount;
        currentPos.x = Mathf.Clamp(currentPos.x, -sideMovementLimit, sideMovementLimit);

        transform.position = currentPos;

    }

    public void FinalMove(Vector3 targetPosition)
    {
        transform.DOMove(targetPosition, finalWalkSpeed).SetSpeedBased(true).OnComplete(StartUpdateAnimationState);
        
        popularityBar.SetActive(false);     

    }

    private void StartUpdateAnimationState()
    {
        transform.DORotate(Vector3.up * 180, 0.5f);  //Rotate(Vector3.up * 180);
        UpdateAnimationState(AnimationState.Dancing);
        GameManager.instance.HandeWinning();
    }




    private void GetInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButton(0))
        {
            moveFactorX = Input.mousePosition.x - lastFrameFingerPositionX;
            lastFrameFingerPositionX = Input.mousePosition.x;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            moveFactorX = 0f;
        }
    }
}
