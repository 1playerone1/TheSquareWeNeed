using Godot;

namespace TheSquareWeNeed.Scripts;

public partial class Level : Node
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		FallZone();
		NextLevel();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	// Checks if player falls from platform
	private void FallZone()
	{
		var fallArea = GetNode<Area2D>("FallZone");
		fallArea.BodyEntered += AreaOnBodyEntered;
	}

	private void NextLevel()
	{
		var nextLevel = GetNode<Area2D>("NextLevel");
		nextLevel.BodyEntered += NextLevelOnBodyEntered;
	}

	private void NextLevelOnBodyEntered(Node2D body)
	{
		GetTree().ChangeSceneToFile("res://Levels/level_2.tscn");
		GD.Print("Entered Next Level");
	}

	// When Player falls from platform load current level
	private void AreaOnBodyEntered(Node2D body)
	{
		GetTree().ReloadCurrentScene();
		GD.Print("Player Fell");
	}
	
}