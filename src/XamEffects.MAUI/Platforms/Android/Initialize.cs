using XamEffects.Droid.Renderers;

namespace XamEffects.Droid
{
    internal static class Effects
    {
        public static void Init()
        {
            TouchEffectPlatform.Init();
            CommandsPlatform.Init();
            BorderViewRenderer.Init();
        }
    }
}