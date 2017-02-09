using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Input.Inking;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace PaintSupport
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ink.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;

            // Set initial ink stroke attributes.
            InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
            drawingAttributes.Color = Windows.UI.Colors.Black;
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;
            ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

        }


        string[] CapsAlpha = new string[] { "Ant", "ant", "Bear", "bear", "Cat", "cat", "Dog", "dog", "Elephant", "elephant", "Frog", "frog", "Giraffe", "giraffe", "Hippo", "hippo", "Ice-Cream", "ice-cream", "Jellyfish", "jellyfish", "Kite", "kite", "Lion", "lion", "Mouse", "mouse", "Nest", "nest", "Owl", "owl",
            "Parrot", "parrot", "Queen", "queen", "Rabbit", "rabbit", "Sheep", "sheep", "Toy", "toy", "Umbrella", "umbrella", "Vulture", "vulture", "Watch", "watch", "X-ray", "x-ray", "Yak", "yak", "Zebra", "zebra" };
        int currentIndex = 0;
        private void WPrevTap(object sender, TappedRoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = 0;
                return;
            }

            Trans_Tex.Source = new BitmapImage(new Uri("ms-appx:///WorkBook/T" + currentIndex + ".png"));
            Alph_cap.Source = new BitmapImage(new Uri("ms-appx:///ABCD/MixCapSmall/CS" + currentIndex + ".png"));
            CapAlphaName.Text = CapsAlpha[currentIndex];
            //var speechText = this.CapAlphaName.Text;            
        }

        private void W_FwdTap(object sender, TappedRoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex > 51)
            {
                currentIndex = 25;
                return;
            }
            Trans_Tex.Source = new BitmapImage(new Uri("ms-appx:///WorkBook/T" + currentIndex + ".png"));
            Alph_cap.Source = new BitmapImage(new Uri("ms-appx:///ABCD/MixCapSmall/CS" + currentIndex + ".png"));
            CapAlphaName.Text = CapsAlpha[currentIndex];

        }

        private void W_MactiveTap(object sender, TappedRoutedEventArgs e)
        {
            //if ((W_Mactive.Source as BitmapImage).UriSource == new Uri("ms-appx:///ABCD/Music_active.png", UriKind.Absolute))
            //{
            //    W_Mactive.Source = new BitmapImage(new Uri("ms-appx:///ABCD/Music_mute.png"));
            //    mediaWorkbook.Stop();
            //}
            //else
            //{
            //    W_Mactive.Source = new BitmapImage(new Uri("ms-appx:///ABCD/Music_active.png"));
            //    mediaWorkbook.Play();
            //}
        }


        private void W_Paintt(object sender, TappedRoutedEventArgs e)
        {
            W_Paint.Visibility = Visibility.Collapsed;
            ink.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.None;
        }
        private void CPtest_ColorChanged(object sender, Windows.UI.Color color)
        {
            ink.InkPresenter.InputDeviceTypes = CoreInputDeviceTypes.Mouse | CoreInputDeviceTypes.Touch;

            // Set initial ink stroke attributes.
            InkDrawingAttributes drawingAttributes = new InkDrawingAttributes();
            drawingAttributes.Color = color;
            drawingAttributes.IgnorePressure = false;
            drawingAttributes.FitToCurve = true;
            ink.InkPresenter.UpdateDefaultDrawingAttributes(drawingAttributes);

            //Bg_BigRect.Background = new SolidColorBrush(color);
        }

        private void W_ClearTap(object sender, TappedRoutedEventArgs e)
        {
            ink.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Erasing;
            //ink.InkPresenter.InputProcessingConfiguration.Mode = InkInputProcessingMode.Inking;

            //ink.InkPresenter.StrokeContainer.Clear();
            //ink.InkPresenter.Strokes.Clear();
            //Windows.UI.Input.Inking.InkInputProcessingMode.Erasing;
            //this.ink.Strokes.Remove();
        }



        private void HomePage(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(MainPage));
        }

    }
}
