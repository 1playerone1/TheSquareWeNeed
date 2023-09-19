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
		GetTree().Paused = false;
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
	}

	private void QuitGame()
	{
		var quitGame = GetNode<Button>("MarginContainer/Title Screen/Quit Game");
		quitGame.Pressed += QuitGameOnPressed;
	}

	private void QuitGameOnPressed()
	{
		GetTree().Quit();
	}
}