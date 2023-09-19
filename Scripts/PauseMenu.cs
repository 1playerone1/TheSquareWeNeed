using Godot;

namespace TheSquareWeNeed.Scripts;

public partial class PauseMenu : Control
{
	
	// Set which level to travel inside editor
	[ExportGroup("Select a level to travel")]
	[Export(PropertyHint.File, "*.tscn,")]
	private string LevelFile { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ResumeGame();
		ReturnMenu();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Pause"))
		{
			_on_pause_button_pressed();
		}
	}

	private void ResumeGame()
	{
		var retryGame = GetNode<Button>("MarginContainer/Pause Overlay/Title Screen/Resume");
		retryGame.Pressed += _on_pause_popup_close_pressed;
	}

	private void ReturnMenu()
	{
		var mainMenu = GetNode<Button>("MarginContainer/Pause Overlay/Title Screen/Return Menu");
		mainMenu.Pressed += ReturnMenuOnPressed;
	}

	private void ReturnMenuOnPressed()
	{
		GetTree().ChangeSceneToFile(LevelFile);
	}

	private void _on_pause_button_pressed()
	{
		GetTree().Paused = true;
		GetNode<ColorRect>("MarginContainer/Pause Overlay").Show();
	}

	private void _on_pause_popup_close_pressed()
	{
		GetNode<ColorRect>("MarginContainer/Pause Overlay").Hide();
		GetTree().Paused = false;
	}
	
}