namespace NativeBinding;

[Activity(Label = "@string/app_name", MainLauncher = true)]
public class MainActivity : Activity
{
    NativeLibraryBinding.NativeClass nativeClass = new();
    protected override void OnCreate(Bundle? savedInstanceState)
    {
        base.OnCreate(savedInstanceState);

        // Set our view from the "main" layout resource
        SetContentView(Resource.Layout.activity_main);

        
    }

    [Obsolete]
    public void ImplementNative()
    {
        nativeClass.GetData();
    }
}
