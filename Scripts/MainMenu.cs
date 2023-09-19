using Godot;

namespace TheSquareWeNeed.Scripts;

public partial class MainMenu : Control
{
	// Set which level to travel inside editor
	[ExportGroup("Select a level to travel")]
	[Export(PropertyHint.File, "*.tscn,")]
	private string LevelFile { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartGame();
		QuitGame();
	}
	
	private void StartGame()
	{
		var startGame = GetNode<Button>("MarginContainer/Title Screen/Start Game");
		startGame.Pressed += StartGameOnPressed;
	}

	private void StartGameOnPressed()
	{
		GetTree().ChangeSceneToFile(LevelFile);
		GD.Print("Entered Next Level");
	}

	private void QuitGame()
	{
		var quitGame = GetNode<Button>("MarginContainer/Title Screen/Quit Game");
		quitGame.Pressed += QuitGameOnPressed;
	}

	private void QuitGameOnPressed()
	{
		GetTree().Quit();
		GD.Print("Quit Game");
	}
}