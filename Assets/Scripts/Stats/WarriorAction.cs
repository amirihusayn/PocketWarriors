using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAction : MonoBehaviour
{
    // Fields
    [SerializeField] private WarriorStats stats;
    [SerializeField] private Animator warriorAnimator;
    [SerializeField] private Rigidbody warriorRigidBody;
    [SerializeField] private GameObject cameraPrefab;
    private ActionContainer actionContainer;
    private InputPrototype warriorInput;
    private Vector3 movement;
    private bool isHorizontalAttack;

    // Properties
    public WarriorStats Stats { get => stats;}
    public Animator WarriorAnimator { get => warriorAnimator; }
    public Rigidbody WarriorRigidBody { get => warriorRigidBody; }
    public ActionContainer ActionContainer { get => actionContainer;}
    public InputPrototype WarriorInput { get => warriorInput; }
    public Vector3 Movement { get => movement; set => movement = value; }
    public bool IsHorizontalAttack { get => isHorizontalAttack; set => isHorizontalAttack = value; }

    // Methods
    private void Start()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        Initialize();
    }

    public void Initialize()
    {
        warriorInput = new PrimaryInput();
        actionContainer = new ActionContainer(this);
        InstantiateCamera();
    }

    private void InstantiateCamera()
    {
        GameObject camera = Instantiate(cameraPrefab, new Vector3(0, 15, -18), Quaternion.Euler(30, 0, 0));
        camera.transform.SetParent(gameObject.transform);
    }

    private void Update()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        Check();
    }

    public void Check()
    {
        actionContainer.CheckActions(this);
    }

    private void FixedUpdate()
    {
        if (!GameController.Instance.IsGameLocal)
            return;
        Perform();
    }

    public void Perform()
    {
        actionContainer.PerformActions(this);
        Movement = new Vector3(Movement.x, 0, Movement.z);
        Movement = Vector3.Normalize(Movement) * stats.FootSpeed;
        warriorRigidBody.velocity = transform.forward * Movement.z + transform.right * Movement.x + transform.up * warriorRigidBody.velocity.y;
    }

    public void CreateProjectile()
    {
    }
}