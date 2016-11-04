using UnityEngine;
using System.Collections;

public class BGScrolling : MonoBehaviour {


	// reference to the renderer
	private Renderer _renderer;

	// reference to the player
	[SerializeField]
	private Transform player;
	private Vector3 savedPosition;

	// scroll speed multiplier
	public float scrollSpeed = 0.5f;

	private float multiX, multiY;

	private bool isMoving, movingInX, movingInY;


	void Awake () 
	{
		_renderer = this.gameObject.GetComponent<Renderer> ();
	}

	void Start () 
	{
		savedPosition = player.position;
		isMoving = false;
	}

	void Update () 
	{
		if (Input.GetKey (KeyCode.UpArrow))
			
			isMoving = true;
		
		else
			
			isMoving = false;

		if (player) {
			
			if (Mathf.Abs (player.position.x - savedPosition.x) > Mathf.Abs (player.position.y - savedPosition.y)) {
		
				movingInX = true;
				movingInY = false;

			}
			

			if (Mathf.Abs (player.position.x - savedPosition.x) < Mathf.Abs (player.position.y - savedPosition.y)) {

				movingInX = false;
				movingInY = true;

			}
		}	

	}


	void FixedUpdate () 
	{
		if (player) {
			
			// check current player position against saved player position.  If different, run code below.
			if (player.position == savedPosition)
				multiX = multiY = 0f;
			else if (player.position != savedPosition) {
			
				if (movingInX) {
					// set multiX with positive or negative depending on player direction
					if (player.position.x > savedPosition.x)
						multiX = -1f;
				
					if (player.position.x < savedPosition.x)
						multiX = 1f;

				}

				if (movingInY) {
				
					// set multiY with positive or negative depending on player direction
					if (player.position.y > savedPosition.x)
						multiY = -1f;
				
					if (player.position.y < savedPosition.x)
						multiY = 1f;

				}

				// after setting multiplier values, save current position for next comparison
				savedPosition = player.position;

			}

		}
		// set the offset of the renderer main texture according to movement of the player
		// if player is going up, move texture down
		// if player is going down, move texture up
		// if player is going left, move texture right
		// if player is going right, move texture left

		float xOffset = _renderer.material.GetTextureOffset("_MainTex").x;
		float yOffset = _renderer.material.GetTextureOffset("_MainTex").y;

		if (isMoving) 
		{
			xOffset += multiX * scrollSpeed;
			yOffset += multiY * scrollSpeed;
		} 


		Vector2 offsetVector = new Vector2 (xOffset, yOffset);
		Vector2 resetVector = new Vector2 ( 0, 0 );
		Vector2 maxOffset = new Vector2 ( 1f, 1f );
		Vector2 minOffset = new Vector2 ( -1f, -1f );

		if (offsetVector.x > maxOffset.x | offsetVector.x < minOffset.x)
			offsetVector.x = resetVector.x;

		if (offsetVector.y > maxOffset.y | offsetVector.y < minOffset.y)
			offsetVector.y = resetVector.y;

		_renderer.material.SetTextureOffset ("_MainTex", offsetVector);

	
	}

}
