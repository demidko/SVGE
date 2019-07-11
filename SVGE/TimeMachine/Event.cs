using System;

namespace TimeMachine
{
    class Event
    {
        public readonly Action Undo, Redo;
        public Event(in Action undo, in Action redo)
        {
            Undo = undo;
            Redo = redo;
        }
    }
}
