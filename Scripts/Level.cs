using Godot;

namespace TheSquareWeNeed.Scripts;

public partial class Level : Node
{
	// Set which level to travel inside editor
	[ExportGroup("Select a level to travel")]
	[Export(PropertyHint.File, "*.tscn,")]
	private string LevelFile { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		FallZone();
		NextLevel();
	}
	
	// Checks if player falls from platform
	private void FallZone()
	{
		var fallArea = GetNode<Area2D>("FallZone");
		fallArea.BodyEntered += AreaOnBodyEntered;
	}

	// If player touches travel to chosen level 
	private void NextLevel()
	{
		var nextLevel = GetNode<Area2D>("NextLevel");
		nextLevel.BodyEntered += NextLevelOnBodyEntered;
	}

	// When player interacts with Area2D travel to chosen level
	private void NextLevelOnBodyEntered(Node2D body)
	{
		GetTree().ChangeSceneToFile(LevelFile);
	}

	// When Player falls from platform load current level
	private void AreaOnBodyEntered(Node2D body)
	{
		GetTree().ReloadCurrentScene();
	}
	
}