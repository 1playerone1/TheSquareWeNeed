using Godot;

namespace TheSquareWeNeed.Scripts;

public partial class MainMenu : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		StartGame();
	}
	private void StartGame()
	{
		var startGame = GetNode<Button>("MarginContainer/Buttons/Start Game");
		startGame.Pressed += StartGameOnPressed;
	}

	private void StartGameOnPressed()
	{
		GetTree().ChangeSceneToFile("res://Levels/level_1.tscn");
		GD.Print("Entered Next Level");
	}
}