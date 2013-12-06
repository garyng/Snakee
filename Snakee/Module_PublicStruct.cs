using System.Drawing;
using CustomPictureBox;

namespace Snakee
{

    abstract public class DefaultSkin
    {
        static public Image Tail_R;
        static public Image Tail_L;
        static public Image Tail_U;
        static public Image Tail_D;

        static public Image Head_R;
        static public Image Head_L;
        static public Image Head_U;
        static public Image Head_D;

        static public Image HeadEat_R;
        static public Image HeadEat_L;
        static public Image HeadEat_U;
        static public Image HeadEat_D;

        static public Image Body_DR;
        static public Image Body_DL;
        static public Image Body_UR;
        static public Image Body_UL;

        static public Image BodyFat_DR;
        static public Image BodyFat_DL;
        static public Image BodyFat_UR;
        static public Image BodyFat_UL;

        static public Image Turn_DR;
        static public Image Turn_DL;
        static public Image Turn_UR;
        static public Image Turn_UL;

        static public Image TurnFat_DR;
        static public Image TurnFat_DL;
        static public Image TurnFat_UR;
        static public Image TurnFat_UL;

        static public Image Food;
        static public Image Wall;

        public static string strTail_R = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADJJREFUKFNj/P//PwNeAFKAAwOFIZIwAFOIJITQjSKIzEE2HqsibPZjtQKnQlw+gIsDAJWJxTxHMSdFAAAAAElFTkSuQmCC";
        public static string strHead_R = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADJJREFUKFNj/P//PwMQgAksgJEBqAADgDRAAYKFTSHYdBwSZJoAdSzIwWBMtBX43MEAAMpnzDYbwvtDAAAAAElFTkSuQmCC";
        public static string strHeadEat_R = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADpJREFUKFNj/P//PwMQgAk0wAjmAxWgACQhkBymAiTVZCqAugdkEKYJMEmoO1AVIEuiK8DwCdShYBMA0AO2TJj/ElYAAAAASUVORK5CYII=";
        public static string strBody_DR = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADRJREFUKFNj/P//PwNeAFQABkBFMCYKDRcFKcCmCEUbNkUY5qKbglUBsiKsLkNXAFKEEwMAMsK/QlIMeJcAAAAASUVORK5CYII=";
        public static string strTurn_UR = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADlJREFUKFNj/M8ABP/BJCZgZATJQZUAGdgAWAFIAmwOFgBXgEsRigJsijAUoCvCqgBZEQNO10FVAQC0I8Q/GC++8wAAAABJRU5ErkJggg==";
        public static string strTurnFat_UR = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADNJREFUKFNj/A8EDLgAIyMjA1QBiMIKwArwKYIrwKUIRQE2RRgK0BVhVYCsCKQApyKQ/wFcqs03vJVzWgAAAABJRU5ErkJggg==";
        public static string strBodyFat_DR = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADhJREFUKFNj/P//PwMQgAksgJEBqAAMQIqwARQF2BShaINahWIQhrnopmBVgKwIq8vQFWB3PtRzAIxfxjw4FjH8AAAAAElFTkSuQmCC";
        public static string strFood = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAADhJREFUKFNj+P//PwOD2v8SIP6PhkvAcjgkYYpLQApgnFIgGxlDxNEUICsmTwHMinK4yQQdScibAHjqgZft/u8GAAAAAElFTkSuQmCC";
        public static string strWall = "iVBORw0KGgoAAAANSUhEUgAAAAgAAAAICAYAAADED76LAAAAAXNSR0IArs4c6QAAAARnQU1BAACxjwv8YQUAAAAgY0hSTQAAeiYAAICEAAD6AAAAgOgAAHUwAADqYAAAOpgAABdwnLpRPAAAAC9JREFUKFNj/M/AAER4AEgBGANJFAwVB2mHSCIrQhLDlEBTSIICvFYQdCTMJ1hoANu5iXhRDp+SAAAAAElFTkSuQmCC";

        static public Color PicBackground = Color.Black;
        static public Color PicForeground = Color.White;

        static public void Image_Init()
        {

            Tail_R = PFunc.Base64_ToImage(strTail_R);
            Tail_L = PFunc.Image_Rotate(Tail_R, RotateFlipType.RotateNoneFlipX);
            Tail_U = PFunc.Image_Rotate(Tail_R, RotateFlipType.Rotate270FlipNone);
            Tail_D = PFunc.Image_Rotate(Tail_R, RotateFlipType.Rotate90FlipNone);

            Head_R = PFunc.Base64_ToImage(strHead_R);
            Head_L = PFunc.Image_Rotate(Head_R, RotateFlipType.RotateNoneFlipX);
            Head_U = PFunc.Image_Rotate(Head_R, RotateFlipType.Rotate270FlipNone);
            Head_D = PFunc.Image_Rotate(Head_R, RotateFlipType.Rotate90FlipNone);

            HeadEat_R = PFunc.Base64_ToImage(strHeadEat_R);
            HeadEat_L = PFunc.Image_Rotate(HeadEat_R, RotateFlipType.RotateNoneFlipX);
            HeadEat_U = PFunc.Image_Rotate(HeadEat_R, RotateFlipType.Rotate270FlipNone);
            HeadEat_D = PFunc.Image_Rotate(HeadEat_R, RotateFlipType.Rotate90FlipNone);

            Body_DR = PFunc.Base64_ToImage(strBody_DR);
            Body_DL = PFunc.Image_Rotate(Body_DR, RotateFlipType.RotateNoneFlipX);
            Body_UR = PFunc.Image_Rotate(Body_DR, RotateFlipType.Rotate90FlipNone);
            Body_UL = PFunc.Image_Rotate(Body_DR, RotateFlipType.Rotate90FlipY);

            BodyFat_DR = PFunc.Base64_ToImage(strBodyFat_DR);
            BodyFat_DL = PFunc.Image_Rotate(BodyFat_DR, RotateFlipType.RotateNoneFlipX);
            BodyFat_UR = PFunc.Image_Rotate(BodyFat_DR, RotateFlipType.Rotate90FlipNone);
            BodyFat_UL = PFunc.Image_Rotate(BodyFat_DR, RotateFlipType.Rotate90FlipY);

            Turn_UR = PFunc.Base64_ToImage(strTurn_UR);
            Turn_DR = PFunc.Image_Rotate(Turn_UR, RotateFlipType.RotateNoneFlipY);
            Turn_DL = PFunc.Image_Rotate(Turn_UR, RotateFlipType.RotateNoneFlipXY);
            Turn_UL = PFunc.Image_Rotate(Turn_UR, RotateFlipType.RotateNoneFlipX);

            TurnFat_UR = PFunc.Base64_ToImage(strTurnFat_UR);
            TurnFat_DR = PFunc.Image_Rotate(TurnFat_UR, RotateFlipType.RotateNoneFlipY);
            TurnFat_DL = PFunc.Image_Rotate(TurnFat_UR, RotateFlipType.RotateNoneFlipXY);
            TurnFat_UL = PFunc.Image_Rotate(TurnFat_UR, RotateFlipType.RotateNoneFlipX);

            Food = PFunc.Base64_ToImage(strFood);
            Wall = PFunc.Base64_ToImage(strWall);

        }

    }

    public enum SnakeDirection
    {
        Left, Right, Up, Down
    }

    public struct HighScoreInfo
    {
        public string Name;
        public string Map;
        public int Score;
        public int Rank;
    }

    public struct SnakeBodyInfo
    {
        public SnakeBox Box;
        public Point Coordinate;
    }

    public struct Skin
    {
        public Image Tail_R;
        public Image Tail_L;
        public Image Tail_U;
        public Image Tail_D;

        public Image Head_R;
        public Image Head_L;
        public Image Head_U;
        public Image Head_D;

        public Image HeadEat_R;
        public Image HeadEat_L;
        public Image HeadEat_U;
        public Image HeadEat_D;

        public Image Body_DR;
        public Image Body_DL;
        public Image Body_UR;
        public Image Body_UL;

        public Image BodyFat_DR;
        public Image BodyFat_DL;
        public Image BodyFat_UR;
        public Image BodyFat_UL;

        public Image Turn_DR;
        public Image Turn_DL;
        public Image Turn_UR;
        public Image Turn_UL;

        public Image TurnFat_DR;
        public Image TurnFat_DL;
        public Image TurnFat_UR;
        public Image TurnFat_UL;

        public Image Food;
        public Image Wall;

        public Color Background;
        public Color Foreground;
    }

    public struct MapInfo
    {
        public string Name;
        public int Interval;

        public int Width;
        public int Height;
        public int BlockSize;

        public int SnakeLength;

        public int Version;
    }

    public struct PlayerInfo
    {
        public string Name;
        public string MapName;
        public string LastMap;
    }

    public enum MapBoxState
    {
        Tail_R,
        Tail_L,
        Tail_U,
        Tail_D,

        Head_R,
        Head_L,
        Head_U,
        Head_D,

        HeadEat_R,
        HeadEat_L,
        HeadEat_U,
        HeadEat_D,

        Body_DR,
        Body_DL,
        Body_UR,
        Body_UL,
        
        BodyFat_DR,
        BodyFat_DL,
        BodyFat_UR,
        BodyFat_UL,
        
        Turn_DR,
        Turn_DL,
        Turn_UR,
        Turn_UL,
        
        TurnFat_DR,
        TurnFat_DL,
        TurnFat_UR,
        TurnFat_UL,
        
        Food,
        Wall,

        None

    }

    public enum ProgressState
    {
        Initializing,
        Initialized,
        MapLoaded,
        MapGenerated,

    }

}
