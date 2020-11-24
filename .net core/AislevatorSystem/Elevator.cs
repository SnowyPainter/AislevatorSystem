using System;
using System.Collections;
using System.Collections.Generic;

namespace AislevatorSystem
{
    public class Elevator
    {
        public int CurrentFloor { get; private set; } = 1;
        
        public Elevator(int f)
        {
            CurrentFloor = f;
        }

        public IEnumerable<int> GetMoveList(int floor)
        {
            int u = CurrentFloor > floor ? -1 : 1;
            for (int f = 1; f <= Math.Abs(CurrentFloor - floor); f++)
                yield return CurrentFloor + (f*u);

            CurrentFloor = floor;
        }

    }
}
