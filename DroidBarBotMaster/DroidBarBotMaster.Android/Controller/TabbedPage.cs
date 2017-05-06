using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using static Android.Widget.TabHost;

namespace DroidBarBotMaster.Droid.Controller
{
    [Activity(Label = "TabbedPage", MainLauncher = true)]
    public class TabbedPage : Activity
    {

        LocalActivityManager localActivityManager;


        protected override void OnCreate(Bundle savedInstanceState)
        {
            RequestWindowFeature(WindowFeatures.NoTitle);

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TabbedPage);

            localActivityManager = new LocalActivityManager(this, false);

            localActivityManager.DispatchCreate(savedInstanceState);

            TabHost tabHost = FindViewById<TabHost>(Resource.Id.tabsHost);   // create the TabHost that will contain the Tabs

            tabHost.Setup(localActivityManager);

            CreateTab(typeof(CocktailListview), "COCKTAIL", "COCKTAIL", tabHost);

            CreateTab(typeof(EditPage), "", "", tabHost);

        }

        private void CreateTab(Type activityType, string tag, string label, TabHost tabHost)
        {

            Intent intent = new Intent(this, activityType);

            intent.AddFlags(ActivityFlags.NewTask);

            TabSpec spec = tabHost.NewTabSpec(tag);

            spec.SetIndicator(label, this.GetDrawable( Android.Resource.Drawable.IcMenuManage));

            spec.SetContent(intent);
            
            tabHost.AddTab(spec);
        }
    }
}