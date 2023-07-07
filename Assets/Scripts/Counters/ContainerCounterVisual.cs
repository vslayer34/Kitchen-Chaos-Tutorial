using UnityEngine;

public class ContainerCounterVisual : MonoBehaviour
{
    [SerializeField] private ContainerCounter containerCounter;

    private Animator animator;
    private int openCloseId;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    private void Start()
    {
        openCloseId = Animator.StringToHash("OpenClose");
        containerCounter.OnPlayerGrabbingObject += ContainerCounter_OnPlayerGrabbingObject;
    }

    private void ContainerCounter_OnPlayerGrabbingObject(object sender, System.EventArgs e)
    {
        animator.SetTrigger(openCloseId);
    }
}
