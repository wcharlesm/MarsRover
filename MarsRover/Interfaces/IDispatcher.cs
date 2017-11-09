using System;
using System.Collections.Generic;
using System.Text;

namespace MarsRover.Interfaces
{
    public interface IDispatcher
    {
        String ReceiveInstructions(String dispatch);
    }
}
