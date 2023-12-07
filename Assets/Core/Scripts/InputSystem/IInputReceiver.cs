using UnityEngine;

namespace hazethedev.InputSystem
{
    public interface IInputReceiver<T> where T : struct
    {
        void Receive(in InputData<T> inputData);
    }
    
    public readonly ref struct InputData<T> where T : struct
    {
        public readonly T Input;
        public readonly InputState State;

        public InputData(T input, InputState state)
        {
            Input = input;
            State = state;
        }
    }

    public enum InputState
    {
        Start, Perform, Cancel
    }

    public interface IMovementInputReceiver : IInputReceiver<Vector2>
    {
        new sealed void Receive(in InputData<Vector2> inputData)
        {
            switch (inputData.State)
            {
                case InputState.Start: OnInputStart(in inputData.Input); break;
                case InputState.Cancel: OnInputCancel(in inputData.Input); break;
                case InputState.Perform:
                default:
                    OnInputPerform(in inputData.Input); break;
            }
        }
        
        void OnInputStart(in Vector2 input){}
        void OnInputPerform(in Vector2 input){}
        void OnInputCancel(in Vector2 input){}
    }
}