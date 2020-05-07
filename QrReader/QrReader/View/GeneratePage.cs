using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using ZXing.Net.Mobile.Forms;

namespace QrReader.View
{
    public class GeneratePage : ContentPage
    {
        public GeneratePage()
        {
            ZXingBarcodeImageView barcode = new ZXingBarcodeImageView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                AutomationId = "zxingBarcodeImageView"
            };

            barcode.BarcodeFormat = ZXing.BarcodeFormat.QR_CODE;
            barcode.BarcodeValue = "http://www.hostkod.com";

            Content = barcode;
        }
    }
}