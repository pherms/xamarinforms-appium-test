using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.Views;


namespace SimpleApp.UWP.additionalStuff
{
    class Class1
    {
        protected bool SetProperty<T>(ref T backingStore, T value,

        [CallerMemberName] string propertyName = "",
                    Action onChanged = null);


        protected override void OnCreate(Bundle savedInstanceState)

        {

            TabLayoutResource = Resource.Layout.Tabbar;

            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            LoadApplication(new App());

        }
    }
}
