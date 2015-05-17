using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace _3DColor
{
    public class InputHandler : GameComponent
    {
        #region Fields

        static KeyboardState currentStateKeyboard;

        static KeyboardState lastStateKeyboard;

        static MouseState currentStateMouse;

        static MouseState lastStateMouse;

        #endregion

        #region Properties

        public static KeyboardState KeyboardState
        {
            get { return currentStateKeyboard; }
        }

        public static KeyboardState LastKeyboardState
        {
            get { return lastStateKeyboard; }
        }

        public static MouseState MouseState
        {
            get { return currentStateMouse; }
        }

        public static MouseState LastMouseState 
        {
            get { return lastStateMouse; }
        }
        #endregion

        #region Constructor

        public InputHandler(Game game)
            : base(game)
        {
            // Store the keyboard and mouse state upon initialization
            currentStateKeyboard = Keyboard.GetState();
            currentStateMouse = Mouse.GetState();
        }
        #endregion

        #region XNA Methods

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before
        /// starting to run.
        /// </summary>
        public override void Initialize()
        {
            // Blank for now
            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // We need to store the old state and get the new state on update.
            lastStateKeyboard = currentStateKeyboard;
            lastStateMouse = currentStateMouse;
            currentStateKeyboard = Keyboard.GetState();
            currentStateMouse = Mouse.GetState();
            base.Update(gameTime);
        }
        #endregion

        #region General Method

        /// <summary>
        /// Cycle the states by setting last to current. This is a bad cleanup.
        /// </summary>
        public static void Flush()
        {
            lastStateKeyboard = currentStateKeyboard;
            lastStateMouse = currentStateMouse;
        }

        #endregion

        #region Keyboard Methods
        /// <summary>
        /// Check for releases by comparing the previous state to the current state.
        /// In the event of a key release it will have been down, and currently its up
        /// </summary>
        /// <param name="key">This is the key to check for release</param>
        /// <returns></returns>
        public static bool KeyReleased(Keys key)
        {
            return currentStateKeyboard.IsKeyUp(key) &&
            lastStateKeyboard.IsKeyDown(key);
        }

        /// <summary>
        /// Given a previous key state of up determine if its been pressed
        /// </summary>
        /// <param name="key">key to check</param>
        /// <returns></returns>
        public static bool KeyPressed(Keys key)
        {
            return currentStateKeyboard.IsKeyDown(key) &&
                   lastStateKeyboard.IsKeyUp(key);
        }

        /// <summary>
        /// Don't examine last state just check if a key is down
        /// </summary>
        /// <param name="key">key to check</param>
        /// <returns></returns>
        public static bool KeyDown(Keys key)
        {
            // check if a key is down regardless of current/past state
            return currentStateKeyboard.IsKeyDown(key);
        }

        #endregion

        #region Mouse Methods
        /// <summary>
        /// Checks for releases by comparing the previous state to the current state.
        /// </summary>
        /// <returns></returns>
        public static bool MouseReleased()
        {
            return currentStateMouse.LeftButton == ButtonState.Released &&
            lastStateMouse.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Given a previous mouse state of up determine if its been pressed
        /// </summary>
        /// <returns></returns>
        public static bool MousePressed()
        {
            return currentStateMouse.LeftButton == ButtonState.Pressed &&
            lastStateMouse.LeftButton == ButtonState.Released;
        }

        /// <summary>
        /// Don't examine last state just check if the mouse button is down
        /// </summary>
        /// <returns></returns>
        public static bool MouseDown()
        {
            return currentStateMouse.LeftButton == ButtonState.Pressed;
        }

        /// <summary>
        /// Returns the postions of the mouse pointer
        /// </summary>
        /// <returns></returns>
        public static Point MousePosition()
        {
            return new Point(currentStateMouse.X, currentStateMouse.Y);
        }

        #endregion
    }
}
