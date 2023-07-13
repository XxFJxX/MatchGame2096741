namespace MatchGame2096741;

public partial class MainPage : ContentPage
{
    

	public MainPage()
	{
		InitializeComponent();
        //Lanza o inicializa el juego 
        SetUpGame();

        //Tiempo
            IDispatcherTimer timer;
            timer = Dispatcher.CreateTimer();
            int count = 0;
            lblPrincipal.Text = "0:00";
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += (s, e) =>
            {
                count += 1;
                TimeSpan time = TimeSpan.FromSeconds(count);
                //Condicion para detener el tiempo cuando termine
                if (numE == 8)
                {
                    string i = lblPrincipal.Text;
                    lblPrincipal.Text = i;
                }
                else
                {
                    lblPrincipal.Text = time.ToString(@"m\:ss");
                }
            };
            timer.Start();
        
    }

    //Variable que contara el nuemro de veces que acerta
    int numE;

    //Las instruciones que sogue para lanzar el juego
    private void SetUpGame()
    {
        List<string> animalEmoji = new List<string>()
    {           
            "😊","😊",
            "👍","👍",
            "🐙","🐙",
            "✌️","✌️",
            "🤡","🤡",
            "👻","👻",
            "🐸","🐸",
            "😤","😤",
    };
        //Se usa un numero ramdom 
        Random random = new Random();

        //Se ordenan los emoji
        foreach (Button view in Grid1.Children)
        {
            int index = random.Next(animalEmoji.Count);
            string nextEmoji = animalEmoji[index];
            view.Text = nextEmoji;
            animalEmoji.RemoveAt(index);
        }
    }
   
    //Se programa el click del boton
    Button ultimoButtonClicked;
    bool encontrandoMatch = false;

    //Se programa el evento del click
    private void Button_Clicked(object sender, EventArgs e)
    {
        
        Button button = sender as Button;
        if (encontrandoMatch == false)
        {
            button.IsVisible = false;
            ultimoButtonClicked = button;
            encontrandoMatch = true;
        }
        else if (button.Text == ultimoButtonClicked.Text)
        {
            button.IsVisible = false;
            encontrandoMatch = false;
            //Cuenta el nuemro de veces acertado
            numE ++ ;
        }
        else
        {
            ultimoButtonClicked.IsVisible = true;
            encontrandoMatch = false;
        }

        
     }

    private void ReiniciarClicked(object sender, EventArgs e)
    {
        Navigation.PushModalAsync(new MainPage());
    }

}

