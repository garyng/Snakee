Snakee!
==========
A classic Snake game in C#

About
=========
Snakee! is definitely as huge project for me. I started this project when I just learned C# and continuously work for it for about 1 year.

The code quality was very `poor` as the codes grow larger, and I have no time for doing code refactoring, so I pushed all the code to Github.

My developing environment : VS2010


Implementation
==============
This Snakee! game was implemented in an different way: It doesn't use bitmap to the game main screen, it uses a 2D array of custom picture box.

Here is the code for creating the 2D array:

```csharp
        void Map_Init()
        {

            for (int y = 0; y < m_miMapInfo.Height; y++)
            {
                List<SnakeBox> sbBoX = new List<SnakeBox>();
                for (int x = 0; x < m_miMapInfo.Width; x++)
                {
                    SnakeBox sbX = new SnakeBox(m_ssSkin);
                    sbX.Size = new Size(m_miMapInfo.BlockSize, m_miMapInfo.BlockSize);

                    //sbX.BorderStyle = BorderStyle.FixedSingle;
                    sbX.BackColor = m_meMap.Background;

                    if (x == 0)
                    {
                        if (y == 0)
                        {
                            sbX.Location = new Point(5, 5);
                        }
                        else
                        {
                            sbX.Top = m_sbMapBox[y - 1][0].Bottom;
                            sbX.Left = m_sbMapBox[y - 1][0].Left;
                        }
                    }
                    else
                    {
                        sbX.Left = sbBoX[x - 1].Right;
                        sbX.Top = sbBoX[x - 1].Top;
                    }


                    //if (Map_IsWall(x, y) == true && m_bNoBorder == false)
                    //{
                    //    sbX.IsWall = true;
                    //    SnakeBodyInfo sbi = new SnakeBodyInfo();
                    //    sbi.Box = sbX;
                    //    sbi.Coordinate = new Point(x,y);
                    //    m_sbiWall.Add(sbi);
                    //}

                    picSnakeCon.Invoke((Action)delegate()
                    {
                    picSnakeCon.Controls.Add(sbX);

                    });
                    sbBoX.Add(sbX);

                }
                m_sbMapBox.Add(sbBoX);
            }

            picInfoCon.Invoke((Action)delegate()
            {
                picInfoCon.Location = new Point(5, 5);

                picSnakeCon.Size = new Size(m_miMapInfo.Width * m_miMapInfo.BlockSize + 15, m_miMapInfo.Height * m_miMapInfo.BlockSize + 15);

                picSnakeCon.Top = picInfoCon.Bottom + 5;
                picSnakeCon.Left = picInfoCon.Left;

                picInfoCon.Width = picSnakeCon.Width;

            }
                );
            this.Invoke((Action)delegate()
            { 
                this.ClientSize = new Size(picSnakeCon.Width + 10, picSnakeCon.Height + picInfoCon.Height + 20);
            });

        }
```

There is another half-way-done code in `Class_Game.cs`
```csharp
        #region MapGenerating

        void Map_Gen()
        {
            List<List<Point>> pFood = new List<List<Point>>();

            //Map gen
            for (int y = 0; y < m_miMap.Width; y++)
            {
                List<MapBoxState> mbs = new List<MapBoxState>();

                List<Point> food = new List<Point>();

                for (int x = 0; x < m_miMap.Height; x++)
                {
                    mbs.Add(MapBoxState.None);

                    food.Add(new Point(x, y));
                }
                pFood.Add(food);

                m_mbsMap.Add(mbs);
            }

            //Wall Gen
            m_pWallLoc = m_meMap.WallPoint;

            m_pWallLoc.ForEach(item=>
                m_mbsMap[item.Y][item.X] = MapBoxState.Wall
                );

            //Food Init
            m_pFoodSel = pFood.SelectMany(item => item).ToList();
            m_pFoodSel.RemoveAll(item=>
                m_pWallLoc.Any(wall=>
                item == wall
                )
                );

            //Snake Gen
            m_pSnakeLoc = m_meMap.SnakeBodyPoint;

            for (int i = 1; i < m_pSnakeLoc.Count -1; i++)
            {
                m_mbsMap[m_pSnakeLoc[i].X][m_pSnakeLoc[i].Y] = MapBoxState.Body_DR;
            }

            m_mbsMap[m_pSnakeLoc[0].X][m_pSnakeLoc[0].Y] = MapBoxState.Tail_R;
            m_mbsMap[m_pSnakeLoc[m_pSnakeLoc.Count - 1].X][m_pSnakeLoc[m_pSnakeLoc.Count - 1].Y] = MapBoxState.Head_R;

            Food_GetRandom();
        }

        #endregion
```

Screenshot
===========
Some of the screenshot while running

Main Screen:
![Main Screen](/Screenshots/Main.png "Snakee Main Screen")

Playing:
![Playing](/Screenshots/Play-Main.png "Playing")

Paused:
![Paused](/Screenshots/Play-Main.png "Paused")

Highscore:
![Highscore](/Screenshots/Play-Paused.png "Highscore")

Map Editor:
![Map Editor - Main](/Screenshots/MapEditor-Main.png "Map Editor - Main")

Map Editor - Map Info Editor:
![Map Editor - Map Info Editor](/Screenshots/MapEditor-InfoEditor.png "Map Editor - Info Editor")

Map Editor - Edit Map:
![Map Editor - Edit Map](/Screenshots/MapEditor-Map.png "Map Editor - Edit Map")

Map Loader
![Map Loaded](/Screenshots/MapLoader.png "Map Loader")

God Mode
![God Mode](/Screenshots/GodMode.png "God Mode")

Some Bugs
![Easter Egg](/Screenshots/EasterEgg.png "Easter Egg")
