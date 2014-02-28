namespace BalkanSuperHero
{
    using System;
    using System.Collections.Generic;
    using GameEngine;
    using GameObjects;
    using Interfaces;

    public class Game
    {
        private IRenderer renderer;
        private IInputControl userControl;
        private Engine engine;
        //private readonly List<Item> items;
        //private List<InanimateObject> inanimates;
        //private List<Character> characters;
        private List<Sprite> allPlayableObjects;
        private List<Item> allItems;

        public Game(IRenderer renderer, IInputControl userControl)
        {
            this.renderer = renderer;
            this.userControl = userControl;
            this.engine = new Engine(this);
            //this.items = new List<Item>();
            //this.inanimates = new List<InanimateObject>();
            //this.characters = new List<Character>();
            this.allPlayableObjects = new List<Sprite>();
        }

        /// <summary>
        /// Gets repository of all possible items within the game
        /// </summary>
        //public IEnumerable<Item> Items
        //{
        //    get { return this.items.AsReadOnly(); }
        //}

        public void Start()
        {
            // initialize drawing "device" - where game will be drawn (WinForm, GDI+, Console, etc.)
            this.renderer.InitializeRenderer(800, 600);

            // initialize user controls
            this.userControl.InitializeInputControls(Enumerations.InputType.Keyboard);

            // Initialize game
            this.GameInitialization();

            // Provide control to the Game engine loop
            engine.Run(this);
        }

        private void LoadItemsRepository()
        {
            throw new NotImplementedException();
        }

        private void GameInitialization()
        {
            // Initialize playground
            // Initialize all inanimateble objects
            // Initialize all non-player characters (enemies, creatures & vendors)
        }

        public void Shutdown()
        {
            this.renderer = null;
            this.userControl = null;
            this.engine = null;
            System.Environment.Exit(0);
        }

        public void UpdateAll()
        {
            this.ClearQueu();
            foreach (var item in this.allPlayableObjects)
            {
                item.Update();
            }
        }

        public void ClearQueu()
        {
            this.allPlayableObjects.RemoveAll(x => !x.IsAlive);
        }

        public void DrawAll()
        {
            this.renderer.UpdateAll(allPlayableObjects);
        }

        public void HandleInput()
        {
            userControl.ProcessInput();
        }
    }
}
