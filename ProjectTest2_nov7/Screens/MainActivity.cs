using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Media;

namespace ProjectTest2_nov7.Screens
{
	[Activity (Label = "ProjectTest2_nov7", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{

		MediaRecorder _recorder;
		MediaPlayer _player;
		MediaPlayer StockPlayer;
		MediaPlayer RecordPlayer;

		Button StopRecord;
		Button RecordVoice;
		Button PlayBack;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.WelcomePage);

			// Get our button from the layout resource,
			// and attach an event to it
			Button SelectGender = FindViewById<Button> (Resource.Id.EnterAppButton);
			SelectGender.Click += delegate {
				HandleGenderSelect();
			};
		}


		//Used for entering gender selection
		void HandleGenderSelect(){
			SetContentView (Resource.Layout.GenderSelect);
			Button SelectMale = FindViewById<Button> (Resource.Id.SelectMale);
			Button SelectFemale = FindViewById<Button> (Resource.Id.SelectFemale);
			SelectFemale.Enabled = !SelectFemale.Enabled;


			SelectMale.Click += delegate {
				HandleLanguageSelect();
			};
		}

		//Used for entering the Language Selection Screen
		void HandleLanguageSelect () {
			SetContentView (Resource.Layout.LanguageSelect);

			Button SelectMandarin = FindViewById<Button> (Resource.Id.SelectMandarin);
			SelectMandarin.Click += delegate {
				HandleMandarinSelect();
			};
		}



		//Used for entering Mandarin Word Selection Screen
		void HandleMandarinSelect() {
			SetContentView (Resource.Layout.MandarinWords);

			Button SelectMandarin_Ma = FindViewById<Button> (Resource.Id.Mandarin_Ma);
			Button button2 = FindViewById<Button> (Resource.Id.button2);
			Button button3 = FindViewById<Button> (Resource.Id.button3);
			Button button4 = FindViewById<Button> (Resource.Id.button4);
			Button button5 = FindViewById<Button> (Resource.Id.button5);
			Button button6 = FindViewById<Button> (Resource.Id.button6);
			Button button7 = FindViewById<Button> (Resource.Id.button7);
			Button button8 = FindViewById<Button> (Resource.Id.button8);
			Button button9 = FindViewById<Button> (Resource.Id.button9);
			Button button10 = FindViewById<Button> (Resource.Id.button10);

			Button SelectBackToLanguages = FindViewById<Button> (Resource.Id.BackToLanguages);

			button2.Enabled = !button2.Enabled;
			button3.Enabled = !button3.Enabled;
			button4.Enabled = !button4.Enabled;
			button5.Enabled = !button5.Enabled;
			button6.Enabled = !button6.Enabled;
			button7.Enabled = !button7.Enabled;
			button8.Enabled = !button8.Enabled;
			button9.Enabled = !button9.Enabled;
			button10.Enabled = !button10.Enabled;





			SelectMandarin_Ma.Click += delegate {
				HandleMandarin_Ma_Male_Select() ;
			};








			SelectBackToLanguages.Click += delegate {
				HandleLanguageSelect();
			};


		}




		//Used for entering the Mandarin_ma speech processing screen
		void HandleMandarin_Ma_Male_Select() {
			SetContentView (Resource.Layout.Mandarin_Mother_Male);

			string RecordPath = "/sdcard/Recording.mp3";
			//string RecordPath = Environment.getExternalStorageDirectory ()
			//	.getAbsolutePath () + "/Recording.mp3";


			//string RecordPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath + "/Recording.3gpp";
			//string RecordPath = this.file.getAbsolutePath().substring(8)


			Button PlayStock = FindViewById<Button> (Resource.Id.PlayMa);
			PlayBack = FindViewById<Button> (Resource.Id.PlayBack);
			Button BackToMandarin = FindViewById<Button> (Resource.Id.BackToMandarin);

			RecordVoice = FindViewById<Button> (Resource.Id.Record);
			StopRecord = FindViewById<Button> (Resource.Id.Stop);
			StockPlayer = MediaPlayer.Create(this, Resource.Raw.mother);

			_recorder = new MediaRecorder ();
			_player = new MediaPlayer ();





			//Click Event Handlers
			PlayStock.Click += delegate {
				StockPlayer.Start();
			};


			RecordVoice.Click += delegate {

				RecordVoice.Enabled = !RecordVoice.Enabled;
				StopRecord.Enabled = !StopRecord.Enabled;
				if (PlayBack.Enabled==true){
					PlayBack.Enabled = false;
				}


				_recorder.SetAudioSource (AudioSource.Mic);
				_recorder.SetOutputFormat (OutputFormat.Mpeg4);
				_recorder.SetOutputFile(RecordPath);
				_recorder.SetAudioEncoder (AudioEncoder.Aac);
				

				_recorder.Prepare();
				_recorder.Start ();


			};


			//Stops recording
			StopRecord.Click += delegate {
				StopRecord.Enabled =! StopRecord.Enabled;

				if (PlayBack.Enabled==false){
					PlayBack.Enabled = true;
				}


				_recorder.Stop ();
				_recorder.Reset ();

				/* For instant playback
				_player.SetDataSource (RecordPath);
				_player.Prepare ();
				_player.Start ();
				*/
				RecordVoice.Enabled = !RecordVoice.Enabled;




			};


			PlayBack.Click += delegate {
				RecordPlayer = new MediaPlayer ();
				RecordPlayer.SetDataSource (RecordPath);
				RecordPlayer.Prepare ();
				RecordPlayer.Start ();

			};


			BackToMandarin.Click += delegate {
				HandleMandarinSelect ();
			};


		}

		protected override void OnResume ()
		{
			base.OnResume ();

			_recorder = new MediaRecorder ();
			_player = new MediaPlayer ();

			_player.Completion += (sender, e) => {
				_player.Reset ();
				RecordVoice.Enabled = !RecordVoice.Enabled;

			} ;

		}

		protected override void OnPause ()
		{
			base.OnPause ();

			_player.Release ();
			_recorder.Release ();
			_player.Dispose ();
			_recorder.Dispose ();
			_player = null;
			_recorder = null;
		}







	}
}


