﻿using Android.Views;

using View = Android.Views.View;

namespace XamEffects.Droid.GestureCollectors
{
    internal static class TouchCollector
    {
        static Dictionary<View, List<Action<View.TouchEventArgs>>> Collection { get; } =
            new Dictionary<View, List<Action<View.TouchEventArgs>>>();

        static View _activeView;

        public static void Add(View view, Action<View.TouchEventArgs> action)
        {
            if (Collection.ContainsKey(view))
            {
                Collection[view].Add(action);
            }
            else
            {
                view.Touch += ActionActivator;
                Collection.Add(view, new List<Action<View.TouchEventArgs>> { action });
            }
        }

        public static void Delete(View view, Action<View.TouchEventArgs> action)
        {
            if (!Collection.ContainsKey(view)) return;

            var actions = Collection[view];
            actions.Remove(action);

            if (actions.Count != 0) return;
            view.Touch -= ActionActivator;
            Collection.Remove(view);
        }

        static void ActionActivator(object sender, View.TouchEventArgs e)
        {
            var view = (View)sender;
            if (!Collection.ContainsKey(view) || (_activeView != null && _activeView != view)) return;

            switch (e.Event.Action)
            {
                case MotionEventActions.Down:
                    _activeView = view;
                    view.PlaySoundEffect(SoundEffects.Click);
                    break;

                case MotionEventActions.Up:
                case MotionEventActions.Cancel:
                    _activeView = null;
                    e.Handled = true;
                    break;
            }

            var actions = Collection[view].ToArray();
            foreach (var valueAction in actions)
            {
                valueAction?.Invoke(e);
            }
        }
    }
}
