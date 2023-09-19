using Godot;

namespace TheSquareWeNeed.Scripts;

public partial class Player : CharacterBody2D
{
    private const float Speed = 300.0f;
    private const float JumpVelocity = -600.0f;
	
    private Sprite2D _characterSprite;
    private AudioStreamPlayer2D _jumpSound;

    // Get the gravity from the project settings to be synced with RigidBody nodes.
    private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	
    public override void _Ready()
    {
        CharacterSprite();
        JumpSound();
    }

    public override void _PhysicsProcess(double delta)
    {
        Vector2 velocity = Velocity;

        // Add the gravity.
        if (!IsOnFloor())
        {
            velocity.Y += _gravity * (float)delta;
        }

        // Handle Jump.
        if (Input.IsActionJustPressed("Jump") && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
			
            // Play sound when jumps
            _jumpSound.Play();
        }
		
        // Get the input direction and handle the movement/deceleration.
        Vector2 direction = Input.GetVector("Left", "Right", "Up", "Down");
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }
        Velocity = velocity;
        MoveAndSlide();
        
        // Flips character when player or enemy goes left or right
        FlipSprite();
        
    }
    
    // Player Sprite
    private void CharacterSprite()
    {
        _characterSprite = GetNode<Sprite2D>("Sprite2D");
    }
    
    // Player jump sound
    private void JumpSound()
    {
        _jumpSound = GetNode<AudioStreamPlayer2D>("JumpSound");
    }
    
    // Flip player sprite
    private void FlipSprite()
    {
        Vector2 velocity = Velocity;
        _characterSprite.FlipH = !(velocity.X >= 0);
    }
    
}