using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace UPE_ONS.Util
{
    class Animation
    {
        public static void fadeIn(UserControl userControl, string name)
        {
            Storyboard storyboard = new Storyboard();
            TimeSpan duration = new TimeSpan(0, 0, 2);

            // Create a DoubleAnimation to fade the not selected option control
            DoubleAnimation animation = new DoubleAnimation();

            animation.From = 0.0;
            animation.To = 1.0;
            animation.Duration = new Duration(duration);
            // Configure the animation to target de property Opacity
            Storyboard.SetTargetName(animation, name);
            Storyboard.SetTargetProperty(animation, new PropertyPath(Control.OpacityProperty));
            // Add the animation to the storyboard
            storyboard.Children.Add(animation);

            // Begin the storyboard
            storyboard.Begin(userControl);
        }
    }
}
