using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Snakee
{
    public class KeysControl
    {
        public static Keys Left = Keys.Left;
        public static Keys Right = Keys.Right;
        public static Keys Up = Keys.Up;
        public static Keys Down = Keys.Down;

        public static Keys Start = Keys.S;
        public static Keys Pause = Keys.P;
        public static Keys Stop = Keys.X;    //Exit To Main Menu
        public static Keys Restart = Keys.R;

        public static Keys Highscore = Keys.H;
        public static Keys MapEditor = Keys.M;
        public static Keys MapLoader = Keys.L;

        public static Keys GodMode = Keys.Control | Keys.Shift | Keys.Alt | Keys.G;
        
    }

    public class GlobalSettings
    {
        public static int MapVersion = 1;
    }

    public class UIString
    {
        public class MainForm
        {
            public static string Start = "Start(" + KeysControl.Start.ToString() + ")";
            public static string Pause = "Pause(" + KeysControl.Pause.ToString() + ")";
            public static string Exit = "Exit(" + KeysControl.Stop.ToString() + ")";
            public static string Restart = "Restart(" + KeysControl.Restart.ToString() + ")";

            public static string HighScore = "Highscore(" + KeysControl.Highscore.ToString() + ")";

            public static string MapEditor = "Map Editor(" + KeysControl.MapEditor.ToString() + ")";
            public static string MapLoader = "Load Map(" + KeysControl.MapLoader.ToString() + ")";

            public static string Name = "Name: ";
            public static string Map = "Map: ";
            public static string Paused = "Paused";
            public static string Score = "Score: ";
            public static string NewHighscore = "New Highscore!";
            public static string GameOver = "Game Over!";
            public static string YourScore = "Your Score: ";
            public static string Rank = "Rank : # ";

            public static string GodMode = "God Mode Activated!";
        }

        public class HighScoreForm
        {
            public static string HighScoreTitle = "HIGHSCORES";
            public static string NameTitle = "Name";
            public static string MapTitle = "Map";
            public static string ScoreTitle = "Score";
            public static string NoTitle = "No.";
        }

        public class MapEditorForm
        {
            public static string FormTitle = "Snakee - Map And Skin Editor" ;

            public static string MainScreenTitle = "Snakee - Map And Skin Editor";
            public static string MainScreenNewBtn = "New Map...";
            public static string MainScreenLoadBtn = "Load Map...";

            public static string SideMapInfoTitle = "Map Info";
            public static string SideMapInfoName = "Name";
            public static string SideMapInfoWidth = " Width";
            public static string SideMapInfoHeight = "Height";
            public static string SideMapInfoBlockSize = "Block Size";
            public static string SideMapInfoSnakeInitLength = "Snake Initial Length";
            public static string SideMapInfoInterval = "Interval";

            public static string SideThemeInfoTitle = "Theme Info";
            public static string SideThemeInfoBackColor = "Background Color";
            public static string SideThemeInfoForeColor = "Foreground Color";

            public static string SkinToolBarBackToHome = "Back To Home";
            public static string SkinToolBarReloadDefault = "Reload Default Value";
            public static string SkinToolBarGenNewMap = "Generate New Map";

            public static string SkinInfoTitle = "Skin Info";
            public static string SkinInfoHelp = "Left double click to select path of the specific skin." + Environment.NewLine + "*The skin image file must be in PNG format" + Environment.NewLine + "*The skin size must match the " + SideMapInfoBlockSize + " in the " + SideMapInfoTitle +  " section";
            public static string SkinInfoBatchImport = "Batch Import Skin Files..." + Environment.NewLine + Environment.NewLine + "*Select a folder that contains:" + Environment.NewLine + " - snakee_body_down_right.png" + Environment.NewLine + " - snakee_body_fat_down_right.png" + Environment.NewLine + " - snakee_head_right.png" + Environment.NewLine + " - snakee_head_eat_right.png" + Environment.NewLine + " - snakee_tail_right.png" + Environment.NewLine + " - snakee_turn_up_right.png" + Environment.NewLine + " - snakee_turn_fat_up_right.png" + Environment.NewLine + " - snakee_wall.png";

            public static string SkinPreviewBody = "Skin Preview - Body";
            public static string SkinPreviewFatBody = "Skin Preview - Fat Body";
            public static string SkinPreviewHead = "Skin Preview - Head";
            public static string SkinPreviewEatHead = "Skin Preview - Eating Head";
            public static string SkinPreviewTail = "Skin Preview - Tail";
            public static string SkinPreviewTurnBody = "Skin Preview - Turning Body";
            public static string SkinPreviewFatTurnBody = "Skin Preview - Fat Turning Body";
            public static string SkinPreviewFood = "Skin Preview - Food";
            public static string SkinPreviewWall = "Skin Preview - Wall";

            public static string SkinCheckError = "There is some error";
            public static string SkincheckErrorTitle = "Error";

            public static string SkinCheckWarning = "You are advised to correct those warning!" + Environment.NewLine + "'Cancel' to go back and edit" + Environment.NewLine + "'OK' to remain those settings and proceed to Map Editor";
            public static string SkinCheckWarningTitle = "Warning";

            public static string MapToolBarBackToSkin = "Back To Skin Editor";
            public static string MapToolBarSave = "Save Map...";

            public static string MainMapNotCompatible = "This map is no compatible to this version of Snakee";

            //TODO: Error And Warning In Class_Map


        }

    }
}
