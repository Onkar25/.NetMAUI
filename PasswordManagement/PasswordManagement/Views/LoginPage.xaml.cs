using Firebase.Auth;
using PasswordManagement.Services;
using PasswordManagement.ViewModels;

namespace PasswordManagement.Views;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel(Navigation);
	}
	public LoginPage(DatabaseServices databaseServices)
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel(databaseServices);
	}

	public LoginPage(FirestoreService firestoreService, FirebaseAuthClient firebaseAuthClient)
	{
		InitializeComponent();
		BindingContext = new LoginPageViewModel(firestoreService, firebaseAuthClient);
		FirestoreService = firestoreService;
	}

	public FirestoreService FirestoreService { get; }

	private void Button_Clicked(object sender, EventArgs e)
	{
		#region Google Sign In
		// 	WebView _signInWebView = new WebView
		// 	{
		// 		Source = GoogleAuthService.ConstructGoogleSignInUrl(),
		// 		VerticalOptions = LayoutOptions.Fill,
		// 	};
		// 	Grid grid = new Grid();
		// 	grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Star }); // Row for the WebView
		// 	Grid.SetRow(_signInWebView, 0);
		// 	grid.Children.Add(_signInWebView);

		// 	ContentPage signInContentPage = new ContentPage
		// 	{
		// 		Content = grid,
		// 	};

		// 	try
		// 	{
		// 		Application.Current.MainPage.Navigation.PushModalAsync(signInContentPage);
		// 	}
		// 	catch (Exception ex)
		// 	{
		// 		Console.WriteLine(ex.Message);
		// 	}
		// 	_signInWebView.Navigating += (sender, e) =>
		//    {

		// 	   string code = GoogleAuthService.OnWebViewNavigating(e, signInContentPage);
		// 	   if (!string.IsNullOrEmpty( e.Url ))//e.Url.StartsWith("http://localhost") && code != null)
		// 	   {
		// 		   (string access_token, string refresh_token) = GoogleAuthService.ExchangeCodeForAccessToken(code);
		// 		    if (!string.IsNullOrWhiteSpace(refresh_token))
		//             {
		//                 App.Current.MainPage = new AppShell(FirestoreService);
		//             }
		// 	   }

		//    };
		#endregion
	}

}