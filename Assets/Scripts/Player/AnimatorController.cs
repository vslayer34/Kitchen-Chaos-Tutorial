using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorController : MonoBehaviour
{
    // references
    [SerializeField] private Player playerScript;
    private Animator playerAnimator;
    private int isWalkingBool;

    private void Awake()
    {
        playerAnimator = GetComponent<Animator>();
    }

    private void Start()
    {
        isWalkingBool = Animator.StringToHash("IsWalking");
    }

    private void Update()
    {
        playerAnimator.SetBool(isWalkingBool, playerScript.IsWalking);
    }
}
