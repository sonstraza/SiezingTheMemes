using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

	//Class
	///<summary> 
	///     This class controls the movement of an object
	/// 											
	///     Explanation:
	/// 		- There are 3 types of Movement here, TapMovement , ManualMovement and AutoMovement
	/// 			- TapMovement moves your character when you tap or click the screen.
	/// 			- ManualMovement moves your character via your Axis Bindings
	/// 			- HorizontalMovement moves your character automatically without any key bindings
	/// 		
	///     Usage:
	///         - Access a reference to a gameObj with this script attached
	///         - Get the isGrounded boolean from it and implement it with your gameplay Logic.
	///             - Whenever your character's feet touches the ground, isGrounded becomes true, isGrounded will become false if your character jumps and is no longer touching the ground
	///             - e.g if isGrounded, canJump = true. Else, canJump = false
	/// 		
	///     Integration:
	///         - Attach this script to a gameObject
	///         - Attach a collision and a rigidbody to the gameObject
	///         - Set the gameObject's LayerMask to "PropCol"
	///         - Attach and position this gameObject to your character's feet
	/// 
	/// </summary>

public class MechCharMovement : MonoBehaviour
{
	/// <summary> 
	/// 	Reference to RigidBody in current gameObj
	/// 		
	///		Explanation:
	///         - To enable physics and influence the way this gameObject moves 
	///		
	/// 	Usage: 
	/// 		- by altering its velocity
	///     	  
	/// </summary>
	Rigidbody2D myRB;
	/// <summary> 
	/// 	Reference to MechActorGroundDetector in Child
	/// 		
	///		Explanation:
	///         - To detect if character is touching the ground
	///		
	/// 	Usage: 
	/// 		- By Getting Boolean from MechActorGroundDetector.isGrounded
	///     	  
	/// </summary>
	public MechActorGroundDetector MechActorGroundDetector;
	
	//Variable
	/// <summary> 
	/// 	Movement Speed of the Character
	/// 		
	///		Explanation:
	///         - movement speed determines how fast the character moves
	///     Usage:
	///         - set this value to influence the speed of the character
	///        
	///     Integration:
	///         - Set a value for this variable in the inspector
	///       
	/// </summary>
	[FormerlySerializedAs("runSpeed")] public float movementSpeed;
	public float jumpSpeed;
	public bool flipChildChar;


	// Start is called before the first frame update
	void Awake()
	{
		myRB = GetComponent<Rigidbody2D>();
//		childVisCharAnim = GetComponentInChildren<VisCharAnim>();

	}

	// Update is called once per frame
	void Update()
	{
		TapVerticalMovement();
		ManualHorizontalMovement();

	}


	void ManualHorizontalMovement()
	{
		myRB.velocity = new Vector2((movementSpeed * Input.GetAxis("Horizontal") * Vector2.right).x, myRB.velocity.y);
		
		if (myRB.velocity.x > 0.2f)
		{
		
		}
		else if (myRB.velocity.x < -0.2f)
		{

		}
		else
		{

		}
	}

	void AutoHorizontalMovement()
	{
		myRB.velocity += new Vector2(movementSpeed, 0);

	}

	void TapVerticalMovement()
	{
		if (Input.GetButton("Fire1"))
		{
			if (MechActorGroundDetector.isGrounded == true)
			{
				myRB.velocity = new Vector2(myRB.velocity.x, (jumpSpeed * Input.GetAxis("Fire1") * Vector2.up).y);
			}
		}
	}
	
	
	
}


   