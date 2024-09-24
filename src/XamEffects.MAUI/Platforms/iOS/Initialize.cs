using XamEffects.iOS.Renderers;

namespace XamEffects.iOS
{
    internal static class Effects
    {
        public static void Init()
        {
            CommandsPlatform.Init();
            TouchEffectPlatform.Init();
            BorderViewRenderer.Link();
        }
    }
}