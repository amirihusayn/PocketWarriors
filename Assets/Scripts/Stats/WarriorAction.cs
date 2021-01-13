using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorAction : MonoBehaviour
{
    // Fields
    [SerializeField] private WarriorStats warriorStats;
    [SerializeField] private Animator warriorAnimator;
    [SerializeField] private Rigidbody warriorRigidBody;
    private ActionContainer actionContainer;
    private SpectralPower spectralPower;
    private InputPrototype warriorInput;
    private Vector3 movement;
    private Vector3 jump;

    // Properties
    public SpectralPower SpectralPower { get => spectralPower; set => spectralPower = value; }
    public InputPrototype WarriorInput { get => warriorInput; set => warriorInput = value; }
    public Animator WarriorAnimator { get => warriorAnimator; set => warriorAnimator = value; }
    public Vector3 Movement { get => movement; set => movement = value; }
    public Rigidbody WarriorRigidBody { get => warriorRigidBody; set => warriorRigidBody = value; }
    public Vector3 Jump { get => jump; set => jump = value; }

    // Methods
    private void Start() 
    {
        warriorInput = new PrimaryInput();////////// Initialize it somewhere
        actionContainer = new ActionContainer();
    }
    private void Update() 
    {
        actionContainer.CheckWarriorActions(this);
    }
    private void FixedUpdate()
    {
        actionContainer.PerformWarriorActions(this);
        // Debug.Log(transform.forward);
        Movement = new Vector3(Movement.x , 0 , Movement.z);
        warriorRigidBody.velocity = Vector3.Normalize(Movement) * warriorStats.GetFootSpeed + transform.up * warriorRigidBody.velocity.y;

        // Movement = Vector3.Normalize(new Vector3(Movement.x , 0 , Movement.z)) * warriorStats.GetFootSpeed;
        // Movement += Jump * warriorStats.GetFootSpeed * 10;
        // warriorRigidBody.AddForce(Movement);
    }


    public void InstantiateProjectile()
    {
    //////////// projectile or spectral component fields that are either NetworkBehaviour or MonoBehaviour
    ////// we call their instantiate method inside related action
    }
}