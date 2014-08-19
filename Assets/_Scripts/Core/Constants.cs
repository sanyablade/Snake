public static class Constants {
	public const float CELL_LENGTH = 1.0f;
	public const float CELL_LENGTH_HALF = CELL_LENGTH * .5f;
	public const float POWER_SPEED = .5f;
	public const int FOOD_POINTS = 10;
	public const int MIN_FIELD = 6;
	public const int MAX_FIELD = 15;
	public const int MIN_SPEED = 2;
	public const int MAX_SPEED = 5;
	public const int MAX_WALLS = 10;

	public class View {
		public const int ROTATION_SPEED = 60;
	}

	public static class Resources {
		public static class Prefabs {
			public const string SNAKE_HEAD = "Prefabs/SnakeHead";
			public const string SNAKE_TAIL = "Prefabs/SnakeTail";
			public const string FOOD = "Prefabs/Food";
			public const string WALL = "Prefabs/Wall";

			public static class GameBoard {
				public const string FIELD = "Prefabs/GameBoard/Field";
				public const string BORDER_UP = "Prefabs/GameBoard/BorderUp";
				public const string BORDER_DOWN = "Prefabs/GameBoard/BorderDown";
				public const string BORDER_LEFT = "Prefabs/GameBoard/BorderLeft";
				public const string BORDER_RIGHT = "Prefabs/GameBoard/BorderRight";
			}

			public static class Camera {
				public const string CAMERA_2D = "Prefabs/Camera/Camera2D";
				public const string CAMERA_3D = "Prefabs/Camera/Camera3D";
			}

			public static class Stones {
				public const string STONE_1 = "Prefabs/Stones/Stone1";
				public const string STONE_2 = "Prefabs/Stones/Stone2";
				public const string STONE_3 = "Prefabs/Stones/Stone3";
				public const string STONE_4 = "Prefabs/Stones/Stone4";
				public const string STONE_5 = "Prefabs/Stones/Stone5";
			}
		}
	}
}
