namespace PrimeiroApp;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	private void OnCounterClicked(object sender, EventArgs e)
	{
		count++;

		if (count == 1)
			CounterBtn.Text = $"Clicou {count} Vez";
		else
			CounterBtn.Text = $"Clicou {count} Vezes";

		SemanticScreenReader.Announce(CounterBtn.Text);
	}

    private void btnVerificar_Clicked(object sender, EventArgs e)
    {
		
		if(txtNome.Text.Length == 1)
		{
            string texto1 = $"O nome tem {txtNome.Text.Length} caracter";
            DisplayAlert("Mensagem", texto1, "Ok");
        }
		else if (txtNome.Text.Length > 1)
		{
            string texto = $"O nome tem {txtNome.Text.Length} caracteres";
            DisplayAlert("Mensagem", texto, "Ok");
        }
    }

    private async void btnLimpar_Clicked(object sender, EventArgs e)
    {
		if (await DisplayAlert("Pergunta", "Deseja realmente limpar a tela", "Yes", "No"))
		{
			txtNome.Text = string.Empty;
		
		}
	}

    private async void btnVerificarDiasVividos_Clicked(object sender, EventArgs e)
    {
		int diasVividos = DateTime.Now.Subtract(txtDtNascimento.Date).Days;

		await Application.Current.MainPage.
			DisplayAlert("Mensagem", $"Você já viveu {diasVividos} dias", "Ok");
    }

    private void btnAtualizarInformacoes_Clicked(object sender, EventArgs e)
    {
		string informacoes = string.Empty;

		if (Preferences.ContainsKey("acaoInicial"))
			informacoes += Preferences.Get("acaoInicial", string.Empty);


        if (Preferences.ContainsKey("acaoStart"))
            informacoes += Preferences.Get("acaoStart", string.Empty);

        if (Preferences.ContainsKey("acaoSleep"))
            informacoes += Preferences.Get("acaoSleep", string.Empty);

        if (Preferences.ContainsKey("acaoResume"))
            informacoes += Preferences.Get("acaoResume", string.Empty);

    }
}

