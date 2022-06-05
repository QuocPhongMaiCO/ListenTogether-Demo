using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp2.Data
{
    public interface INativeAudioService
    {
        Task InitializeAsync(string audioURI);

        Task PlayAsync();

        Task PauseAsync();

        Task SetMuted(bool value);

        Task SetVolume(int value);

        Task SetCurrentTime(double value);

        ValueTask DisposeAsync();

        bool IsPlaying { get; }

        double CurrentPosition { get; }

        event EventHandler<bool> IsPlayingChanged;
    }
}
