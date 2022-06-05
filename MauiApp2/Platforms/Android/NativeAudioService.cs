using Android.Media;
using MauiApp2.Data;
using AndroidApp = Android.App;

namespace MauiApp2.Platforms.Android
{
    public class NativeAudioService : INativeAudioService
    {   
        IAudioActivity instance;

        private MediaPlayer mediaPlayer => instance != null &&
            instance.Binder.GetMediaPlayerService() != null ?
            instance.Binder.GetMediaPlayerService().mediaPlayer : null;

        public bool IsPlaying => mediaPlayer?.IsPlaying ?? false;

        public double CurrentPosition => mediaPlayer?.CurrentPosition / 1000 ?? 0;
        public event EventHandler<bool> IsPlayingChanged;

        public Task InitializeAsync(string audioURI)
        {
            if (instance == null)
            {
                var activity = CurrentActivity.CrossCurrentActivity.Current;
                instance = activity.Activity as IAudioActivity;
            }
            else
            {
                instance.Binder.GetMediaPlayerService().isCurrentEpisode = false;
                instance.Binder.GetMediaPlayerService().UpdatePlaybackStateStopped();
            }

            instance.Binder.GetMediaPlayerService();

            return Task.CompletedTask;
        }

        public Task PauseAsync()
        {
            if (IsPlaying)
            {
                return instance.Binder.GetMediaPlayerService().Pause();
            }

            return Task.CompletedTask;
        }

        public async Task PlayAsync()
        {
            await instance.Binder.GetMediaPlayerService().Play();
        }

        public Task SetMuted(bool value)
        {
            instance?.Binder.GetMediaPlayerService().SetMuted(value);

            return Task.CompletedTask;
        }

        public Task SetVolume(int value)
        {
            instance?.Binder.GetMediaPlayerService().SetVolume(value);

            return Task.CompletedTask;
        }

        public Task SetCurrentTime(double position)
        {
            return instance.Binder.GetMediaPlayerService().Seek((int)position * 1000);
        }

        public ValueTask DisposeAsync()
        {
            instance.Binder?.Dispose();
            return ValueTask.CompletedTask;
        }
    }
}
