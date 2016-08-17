// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace SweetScent.iOS
{
    [Register ("MapsController")]
    partial class MapsController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        MapKit.MKMapView MapView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton SearchButton { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (MapView != null) {
                MapView.Dispose ();
                MapView = null;
            }

            if (SearchButton != null) {
                SearchButton.Dispose ();
                SearchButton = null;
            }
        }
    }
}