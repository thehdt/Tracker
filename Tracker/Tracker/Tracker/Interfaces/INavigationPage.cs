using System;
using Tracker.Enumerations;

namespace Tracker.Interfaces
{
    public interface INavigationPage
    {
        event Action<int, int> SetWindowSize;
        event Action<PageNames> MoveForward;
        event Action MoveBackwards;
    }
}
