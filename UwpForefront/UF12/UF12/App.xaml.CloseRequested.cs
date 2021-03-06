﻿using System;
using Windows.Foundation;
using Windows.UI.Core.Preview;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace UF12
{
  partial class App
  {
    void SetupCloseRequestedHandler()
    {
      // [×]ボタンのイベントハンドラー (1703以降)
      // ※マニフェストに <rescap:Capability Name="confirmAppClose"/> が必要
      SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += async (s, e) =>
      {
        // 閉じられるのをキャンセルする
        e.Handled = true;

        ContentDialog dialog = new ContentDialog
        {
          Title = "アプリを終了しますか?",
          Content = "[×] ボタンが押されましたが、アプリを終了してもよいですか",
          CloseButtonText = "キャンセル",
          PrimaryButtonText = "終了",
          DefaultButton = ContentDialogButton.Primary
        };
        ContentDialogResult result = await dialog.ShowAsync();
        if (result == ContentDialogResult.Primary)
        {
          // App.Current.Exitでの終了は「異常終了」なので、ウィンドウのサイズを
          // 記憶してもらえない。
          // 自前で記憶させておき、起動時にPreferredLaunchWindowingModeを
          // AutoからPreferredLaunchViewSizeに切り替えると、
          // ウィンドウのサイズを復元できる。（ウィンドウの位置は復元できない）
          var currentRect = Window.Current.Bounds;
          ApplicationView.PreferredLaunchViewSize = new Size(currentRect.Width, currentRect.Height);

          // キャンセルしてしまっているので、
          // 必要ならばあらためてアプリを終了させる。
          this.Exit();
          // ↑Exitすると、OnSuspending等は実行されないので注意!
        }
      };
    }
  }
}
