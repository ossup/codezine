﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// 空白ページの項目テンプレートについては、https://go.microsoft.com/fwlink/?LinkId=234238 を参照してください

namespace UF01
{
  /// <summary>
  /// それ自体で使用できる空白ページまたはフレーム内に移動できる空白ページ。
  /// </summary>
  public sealed partial class Page3 : Page
  {
    private SampleData SampleData => (App.Current as App).SampleData;

    public Page3()
    {
      this.InitializeComponent();

      Windows.UI.ViewManagement.ApplicationView.GetForCurrentView()
        .Title = "UIコントロールの有無で使い分け";
    }

    private void AppBarButton_Click(object sender, RoutedEventArgs e)
    {
      if (this.Frame.CanGoBack)
        this.Frame.GoBack();
    }

    private void colorComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
      this.SampleData.SampleColor
        = (Color)(colorComboBox.SelectedItem as FrameworkElement).Tag;
    }
  }
}
