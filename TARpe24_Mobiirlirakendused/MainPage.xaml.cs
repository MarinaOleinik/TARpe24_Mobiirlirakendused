namespace TARpe24_Mobiirlirakendused
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnCounterClicked(object? sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                if(count==10){   
                    BotImage.IsVisible = false;
                    CounterLabel.Text = "Pilt kadus ära! Vajuta Reset.";}
                CounterBtn.Text = $"Clicked {count} times";

            BotImage.Rotation += 20;//Pöörab pilti iga vajutusega 20 kraadi

            var rnd= new Random();            
            var rndColor= Color.FromRgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));
            BackgroundColor = rndColor;//Muutab taustavärvi juhuslikuks värviks


            SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void ResetBtn_Clicked(object sender, EventArgs e)
        {
            count = 0;
            CounterBtn.Text = "Alustame uuesti!";

            BotImage.IsVisible = true;//Teeb pildi uuesti nähtavaks
            BotImage.Rotation = 0;//Lähtestab pildi pöörde nulli
            CounterLabel.Text="Pilt on tagasi!";

            BackgroundColor = Colors.White;//muudame värv avalgeks
            ResetBtn.ClearValue(BackgroundColorProperty);//eemaldame nupu taustavärvi
            CounterBtn.ClearValue(Button.TextColorProperty);
            if (BotImage.HorizontalOptions == LayoutOptions.Start)
            {
                BotImage.HorizontalOptions = LayoutOptions.End;
            }
            else
            {
                BotImage.HorizontalOptions = LayoutOptions.Start;
            }
        }
    }
}
