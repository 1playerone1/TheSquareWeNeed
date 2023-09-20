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
		IsGamePaused();
		StartGame();
		QuitGame();
	}
	
	// Game Menu should never paused so its false
	private void IsGamePaused()
	{
		GetTree().Paused = false;
	}

	// Gets Start Game Button
	private void StartGame()
	{
		var startGame = GetNode<Button>("MarginContainer/Title Screen/Start Game");
		startGame.Pressed += StartGameOnPressed;
	}

	// When pressed on Start Game Button travel to chosen level path
	private void StartGameOnPressed()
	{
		GetTree().ChangeSceneToFile(LevelFile);
	}

	// Gets Quit Game Button
	private void QuitGame()
	{
		var quitGame = GetNode<Button>("MarginContainer/Title Screen/Quit Game");
		quitGame.Pressed += QuitGameOnPressed;
	}

	// When pressed on Quit Game Button finish application
	private void QuitGameOnPressed()
	{
		GetTree().Quit();
	}
}