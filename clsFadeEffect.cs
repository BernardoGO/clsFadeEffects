using System;
using System.Windows.Media.Animation;
using System.Windows;

namespace FadeEffects
{
    public class clsFadeEffect
    {
        public int delay { get; set; }
        public double FadeOutDuration { get; set; }
        public double FadeInDuration { get; set; }
        public double Durations { set { FadeInDuration = value; FadeOutDuration = value; } }
        public double FadeInTo { get; set; }
        public double FadeOutTo { get; set; }

        public clsFadeEffect()
        {
            delay = 0;
            FadeInDuration = 1.0;
            FadeOutDuration = 1.0;
            FadeInTo = 1;
            FadeOutTo = 0;
        }

        public void Switch(FrameworkElement ChangeFrom, FrameworkElement ChangeTo)
        {
            ChangeFrom.BeginAnimation(UIElement.OpacityProperty, null);
            ChangeTo.BeginAnimation(UIElement.OpacityProperty, null);
            FadeOut(ChangeFrom);
            FadeIn(ChangeTo);
        }

        public void FadeOut(FrameworkElement Change)
        {

            Change.BeginAnimation(UIElement.OpacityProperty, null);
            DoubleAnimationUsingKeyFrames opacityAnimation = new DoubleAnimationUsingKeyFrames();
            TimeSpan endTime = TimeSpan.FromSeconds(FadeOutDuration);
            KeyTime kEnd = KeyTime.FromTimeSpan(endTime);


            opacityAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(FadeOutTo, kEnd));

            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("(FrameworkElement.Opacity)"));
            Storyboard sb = new Storyboard();
            sb.BeginTime = TimeSpan.FromMilliseconds(delay);
            sb.Children.Add(opacityAnimation);
            
            sb.Completed += (EventHandler)delegate(object sender, EventArgs e)
            {
                Change.Visibility = System.Windows.Visibility.Collapsed;
                //Change.BeginAnimation(UIElement.OpacityProperty, null);
            };
            
            sb.Begin(Change);
            
        }

        public void FadeIn(FrameworkElement Change)
        {
            Change.Visibility = System.Windows.Visibility.Visible;
            Change.BeginAnimation(UIElement.OpacityProperty, null);
            DoubleAnimationUsingKeyFrames opacityAnimation = new DoubleAnimationUsingKeyFrames();
            TimeSpan endTime = TimeSpan.FromSeconds(FadeInDuration);
            KeyTime kEnd = KeyTime.FromTimeSpan(endTime);

            opacityAnimation.KeyFrames.Add(new SplineDoubleKeyFrame(FadeInTo, kEnd));



            Storyboard.SetTargetProperty(opacityAnimation, new PropertyPath("(FrameworkElement.Opacity)"));
            Storyboard sb = new Storyboard();
            sb.BeginTime = TimeSpan.FromMilliseconds(delay);
            sb.Children.Add(opacityAnimation);
            /*
            sb.Completed += (EventHandler)delegate(object sender, EventArgs e)
            {
                Change.BeginAnimation(UIElement.OpacityProperty, null);
            };
            */
            sb.Begin(Change);


        }

    }
    }

