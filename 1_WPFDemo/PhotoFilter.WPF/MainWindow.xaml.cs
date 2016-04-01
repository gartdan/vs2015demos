﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PhotoFilter.WPF
{
    public class ImageItem : INotifyPropertyChanged
    {
        public string Name { get; set; }
        private BitmapImage _image = null;
        public BitmapImage Image { 
            get {
                if (_image == null)
                {
                    _image = new BitmapImage();

                    _image.BeginInit();
                    _image.UriSource = Uri;
                    _image.DecodePixelWidth = 150;
                    _image.EndInit();
                    OnPropertyChanged();
                }
                return _image;
            }
            set { _image = value; }
        }
        public Uri Uri { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
    public class MainPageViewModel
    {
        public List<ImageItem> Images { get; set; }
        public MainPageViewModel()
        {
            Images = new List<ImageItem>();

            var files = Utilities.GetPictureList();
            foreach (var file in files)
            {
                if (Utilities.IsValidImageFile(file))
                {
                    ImageItem image = new ImageItem();
                    image.Uri = new Uri(file);
                    image.Name = file.Substring(file.LastIndexOf(@"\") + 1);
                    Images.Add(image);
                }
            }
        }
    }

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainPageViewModel _viewModel;
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            await Utilities.GetImagesFromCloud();
            _viewModel = new MainPageViewModel();
            this.DataContext = _viewModel;
        }

        private void MainListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ImagePage imagePage = new ImagePage(MainListView);
            imagePage.Show();
        }
    }
}
