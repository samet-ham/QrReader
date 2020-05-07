using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZXing;
using ZXing.Mobile;
using ZXing.Net.Mobile.Forms;

namespace QrReader.View
{
    public class ReaderPage : ContentPage
    {
        ZXingScannerPage sPage;
        public ReaderPage()
        {
            sPage = new ZXingScannerPage(new MobileBarcodeScanningOptions
            {
                AutoRotate = true,
                PossibleFormats = new List<BarcodeFormat>
                {
                    //BarcodeFormat.QR_CODE,
                    //BarcodeFormat.AZTEC
                },
                UseFrontCameraIfAvailable = false,
                UseNativeScanning = true
            });

            sPage.ToggleTorch();
            sPage.OnScanResult += SPage_OnScanResult;

            Button scanButton = new Button
            {
                Text = "Tara",
                AutomationId = "scanContinuously"
            };
            Button generateButton = new Button
            {
                Text = "Oluştur",
                AutomationId = "barcodeGenerator"
            };

            generateButton.Clicked += GenerateButton_Clicked;

            scanButton.Clicked += ScanButton_Clicked;

            var stack = new StackLayout();
            stack.Children.Add(scanButton);
            stack.Children.Add(generateButton);

            Content = stack;
        }

        private async void GenerateButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(new GeneratePage());
        }

        private void SPage_OnScanResult(ZXing.Result result)
        {
            sPage.IsScanning = false;
            Device.BeginInvokeOnMainThread(() =>
            {
                Navigation.PopAsync();
                DisplayAlert("Taranan Kod", result.Text, "Ok");
            });
        }

        private async void ScanButton_Clicked(object sender, System.EventArgs e)
        {
            await Navigation.PushAsync(sPage);
        }
    }
}