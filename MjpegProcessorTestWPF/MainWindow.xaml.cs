using System;
using System.Windows;
using MjpegProcessor;

using System.Windows.Media;

namespace MjpegProcessorTestWPF
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		readonly MjpegDecoder _mjpeg;
        bool XFlipped = false;
        bool YFlipped = false;
        bool started = false;

        public MainWindow()
		{
			InitializeComponent();
			_mjpeg = new MjpegDecoder();
			_mjpeg.FrameReady += mjpeg_FrameReady;
			_mjpeg.Error += _mjpeg_Error;
		}

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            if (started == false)
            {
                Start.Content = "Stop";
                _mjpeg.ParseStream(new Uri("http://lgcam1:1716/?action=stream"));
                started = true;
            }
            else
            {
                started = false;
                _mjpeg.StopStream();
                Start.Content = "Start";

            }
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {

            



            // RotateTransform rotateTransform = new RotateTransform(180);
            // image.RenderTransform = rotateTransform;
            //   image. .Save(@"Path", ImageFormat.Jpeg);



        }
        private void FlipX_Click(object sender, RoutedEventArgs e)
        {

            image.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);

            ScaleTransform flipTrans = new ScaleTransform();


            if (XFlipped == true)
            {
                flipTrans.ScaleX = 1;
                XFlipped = false;
            }
            else
            {
                flipTrans.ScaleX = -1;
                XFlipped = true;
            }
            //flipTrans.ScaleY = -1;
            image.RenderTransform = flipTrans;


        }
        private void FlipY_Click(object sender, RoutedEventArgs e)
        {
            image.RenderTransformOrigin = new System.Windows.Point(0.5, 0.5);

            ScaleTransform flipTrans = new ScaleTransform();


            if (YFlipped == true)
            {
                flipTrans.ScaleY = 1;
                YFlipped = false;
            }
            else
            {
                flipTrans.ScaleY = -1;
                YFlipped = true;
            }
             image.RenderTransform = flipTrans;



            // RotateTransform rotateTransform = new RotateTransform(180);
            // image.RenderTransform = rotateTransform;
            //   image. .Save(@"Path", ImageFormat.Jpeg);



        }



        private void mjpeg_FrameReady(object sender, FrameReadyEventArgs e)
		{



            image.Source = e.BitmapImage;
		}

		void _mjpeg_Error(object sender, MjpegProcessor.ErrorEventArgs e)
		{
			MessageBox.Show(e.Message);
		}
	}
}
