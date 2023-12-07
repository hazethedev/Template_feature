using hazethedev.Common;
using Sirenix.OdinInspector;
// using SpelGames.InputSystem;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace hazethedev.GameManagement
{
    [DefaultExecutionOrder(-5)]
    public class GameManager : Singleton<GameManager>
    {
        [SerializeField] private GamePreferenceApplier m_Preferences;
        // [ShowInInspector, ReadOnly] private IInputManager m_InputSystem;
        //
        [ShowInInspector, ReadOnly, EnumToggleButtons]
        private GameState m_State;
        
        public GameState State => m_State;

        private void Start()
        {
            // m_InputSystem = GetComponent<IInputManager>();
            // m_InputSystem.Enable(false, GameInputHandlerFlag.Core);
            HandleSettings();
            StartGame();
        }

        public void StartLevel() => ChangeState(GameState.Play);
        private void StartGame() => ChangeState(GameState.Start);

        private void ChangeScene(int sceneIndex, LoadSceneMode sceneMode = LoadSceneMode.Single)
        {
            // m_InputSystem.Enable(false);
            m_Preferences.ApplyOnExit(manager: this);
            SceneManager.LoadScene(sceneIndex, sceneMode);
        }
        public void RestartLevel() => ChangeScene(SceneManager.GetActiveScene().buildIndex);

        public void ChangeState(GameState state)
        {
            if (m_State == state) return;
            m_State = state;
        }

        private void HandleSettings() => m_Preferences.ApplyOnEnter(manager: this);
    }
}