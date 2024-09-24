using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace XamEffects.MAUI
{
    public static class AppBuilderExtensions
    {
        public static MauiAppBuilder UseXamEffects(this MauiAppBuilder builder)
        {
#if ANDROID
                Droid.Effects.Init();
#elif IOS
                iOS.Effects.Init();
#elif MACCATALYST                
#elif WINDOWS
#endif
            builder
                //.UseMauiCompatibility()
                .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                handlers.AddHandler(typeof(BorderView), typeof(Droid.Renderers.BorderViewRenderer));
#elif IOS
                handlers.AddHandler(typeof(BorderView), typeof(iOS.Renderers.BorderViewRenderer));
#elif MACCATALYST
#elif WINDOWS
#endif
            }).ConfigureEffects(handlers =>
            {
#if ANDROID
                handlers.Add<Commands, Droid.CommandsPlatform>();
                handlers.Add<TouchEffect, Droid.TouchEffectPlatform>();
#elif IOS
                handlers.Add<Commands, iOS.CommandsPlatform>();
                handlers.Add<TouchEffect, iOS.TouchEffectPlatform>();
#elif MACCATALYST
#elif WINDOWS
#endif
            });
            return builder;
        }
    }
}
