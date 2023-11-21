using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using Pacman_Game;
using Pacman_Game.Class;
using PacmanGaneWF;

public delegate void Communicate(Task t, Point P);
public delegate void CheatCode();

namespace PacmanWinForms
{
    public enum GameState : byte
    {
        GAMEOVER = 0,
        GAMEPAUSE = 1,
        GAMERUN = 2
    }

    public enum Direction : Int16
    {
        UP = 0,
        LEFT = 1,
        DOWN = 2,
        RIGHT = 3,
        STOP = 14
    }

    public enum GhostColor : byte
    {
        RED = 0,
        BLUE = 1,
        YELLOW = 2,
        PINK = 3,
        NULL = 5
    }

    public enum GhostState : byte
    {
        NORMAL = 0,
        BONUS = 1,
        EATEN = 2,
        BONUSEND = 4
    }

    public class PacmanGame
    {
        public int PacmanDelay
        {
            get { return _delay; }
            set
            {
                _delay = (value < 10) ? 10 : value;
                Pacman.Delay = _delay;
            }
        }

        public int RedGhostDelay
        {
            get { return RedGhost.Delay; }
            set { RedGhost.Delay = value; }
        }

        public int BlueGhostDelay
        {
            get { return BlueGhost.Delay; }
            set { BlueGhost.Delay = value; }
        }

        public int PinkGhostDelay
        {
            get { return PinkGhost.Delay; }
            set { PinkGhost.Delay = value; }
        }

        public int YellowGhostDelay
        {
            get { return YellowGhost.Delay; }
            set { YellowGhost.Delay = value; }
        }

        public int GhostDelay
        {
            get { return _ghostDelay; }
            set
            {
                _ghostDelay = (value < 10) ? 10 : value;
                RedGhost.Delay = _ghostDelay;
                BlueGhost.Delay = _ghostDelay;
                PinkGhost.Delay = _ghostDelay;
                YellowGhost.Delay = _ghostDelay;
            }
        }

        private GameState _state = GameState.GAMEOVER;
        public GameState State
        {
            get { return _state; }
            set
            {
                _state = value;
                Pacman.State = value;
                RedGhost.ghostState = (GhostState)value;
                BlueGhost.ghostState = (GhostState)value;
                YellowGhost.ghostState = (GhostState)value;
                PinkGhost.ghostState = (GhostState)value;
            }
        }

        public Task Runner;
        public Task wallRunner;
        public Task Clock;
        private int _ghostDelay = 90;
        private int _delay = 90;
        private int score = 0;
        private bool _bonus = false;
        private int Level = 1;
        private int lives = 3;

        public bool Bonus
        {
            get { return _bonus; }
            set { _bonus = value; }
        }

        private frmPacmanGame parentForm;
        private PacmanBoard board;

        private PacmanRun Pacman;
        private GhostRun RedGhost;
        private GhostRun BlueGhost;
        private GhostRun PinkGhost;
        private GhostRun YellowGhost;

        List<Point> wallList = new List<Point>();
        List<Point> dotList = new List<Point>();
        List<Point> boxList = new List<Point>();
        List<Point> boxDoorList = new List<Point>();
        List<Point> bonusList = new List<Point>();

        public PacmanGame(frmPacmanGame frm, Panel p)
        {
            parentForm = frm;
            board = new PacmanBoard(p);
            Pacman = new PacmanRun(parentForm, board);
            RedGhost = new GhostRun(parentForm, board, GhostColor.RED);
            BlueGhost = new GhostRun(parentForm, board, GhostColor.BLUE);
            PinkGhost = new GhostRun(parentForm, board, GhostColor.PINK);
            YellowGhost = new GhostRun(parentForm, board, GhostColor.YELLOW);
            this.Init();
            RePaint();
        }

        private void Init()
        {
            wallList = MapHandler.Instance.GetList(PointListsWrapper.PointListType.Wall);
            dotList = MapHandler.Instance.GetList(PointListsWrapper.PointListType.Dot);
            boxList = MapHandler.Instance.GetList(PointListsWrapper.PointListType.Box);
            boxDoorList = MapHandler.Instance.GetList(PointListsWrapper.PointListType.BoxDoor);
            bonusList = MapHandler.Instance.GetList(PointListsWrapper.PointListType.Bonus);

            State = GameState.GAMEOVER;

            score = 0;
            PacmanDelay = 80;
            GhostDelay = 80;
        }

        public void Run()
        {
            RePaint();
            State = GameState.GAMERUN;
            Runner = new Task(runGame);
            Runner.Start();
            wallRunner = new Task(runWalls);
            wallRunner.Start();
            Clock = new Task(runClock);
            Clock.Start();
            Pacman.Run();
            RedGhost.Run();
            BlueGhost.Run();
            YellowGhost.Run();
            PinkGhost.Run();
        }

        public void RePaint()
        {
            parentForm.SuspendLayout();
            board.Resize();
            parentForm.ResumeLayout(false);
        }

        private void runGame()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    // Empty function body for eatDots, eatBonus, addLives, bonusClear, bonusPaint, dotPaint, checkForWin, checkForLose, checkForCollision
                    Runner.Wait(10);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private string convertLives(int l)
        {
            // Empty function body for convertLives
            return string.Empty;
        }

        private void addLives()
        {
            // Empty function body for addLives
        }

        private void runWalls()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    // Empty function body for doorPaint, wallPaint
                    wallRunner.Wait(100);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        private void runClock()
        {
            while (State != GameState.GAMEOVER)
            {
                try
                {
                    // Empty function body for changeGhostState, bonusStateChange
                    Clock.Wait(100);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }
        }

        int redCounter = 0, blueCounter = 0, pinkCounter = 0, yellowCounter = 0;

        private void changeGhostState()
        {
            // Empty function body for changeGhostState
        }

        int bonusStateCounter = 1, bonusCounter = 0;
        bool BonusEndSprite = true;

        private void bonusStateChange()
        {
            // Empty function body for bonusStateChange
        }

        private void eatDots(Point[] core)
        {
            // Empty function body for eatDots
        }

        private void eatBonus(Point[] core)
        {
            // Empty function body for eatBonus
        }

        int eatenScore = 200;

        private void checkForLose()
        {
            // Empty function body for checkForLose
        }

        private void checkForWin()
        {
            // Empty function body for checkForWin
        }

        private void checkForCollision()
        {
            // Empty function body for checkForCollision
        }

        public void cheat()
        {

        }
        private void ChangeLevel()
        {

        }
        public async void WaitSomeTime(int time)
        {

        }
        public void setGhostState(GhostColor color, GhostState state)
        {

        }
        public void setDirection(Direction d)
        {

        }

        private void bonusClear()
        {
            // Empty function body for bonusClear
        }

        int bonusCounterEnd = 0;

        private void bonusPaint(int counter)
        {
            // Empty function body for bonusPaint
        }

        private void dotPaint()
        {
            // Empty function body for dotPaint
        }

        private void doorPaint()
        {
            // Empty function body for doorPaint
        }

        private void wallPaint()
        {
            // Empty function body for wallPaint
        }

        private void addBonus()
        {
            // Empty function body for addBonus
        }
        public void Stop()
        {
            State = GameState.GAMEOVER;
        }

        public void Pause()
        {
            if (State == GameState.GAMERUN)
            {
                State = GameState.GAMEPAUSE;
            }
        }

        public void Continue()
        {
            if (State == GameState.GAMEPAUSE)
            {
                State = GameState.GAMERUN;
            }
        }
    }
}