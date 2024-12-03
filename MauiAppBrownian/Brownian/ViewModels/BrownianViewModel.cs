using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiAppBrownian.Brownian.ViewModels;

public class BrownianViewModel : BaseViewModel
{
    public ICommand GeneateBrownianCommand { get; init; }

    private double _precoInical;
    private double _volatilidade;
    private double _mediaRetorno;
    private int _tempo;
    private double[] _prices;


    public double[] Prices
    {
        get => _prices;
        set
        {
            _prices = value;
            OnPropertyChanged();
        }
    }
    public double PrecoInical
    {
        get => _precoInical;
        set
        {
            _precoInical = value;
            OnPropertyChanged();
        }
    }
    public double Volatilidade
    {
        get => _volatilidade;
        set
        {
            _volatilidade = value;
            OnPropertyChanged();
        }
    }
    public double MediaRetorno
    {
        get => _mediaRetorno;
        set
        {
            _mediaRetorno = value;
            OnPropertyChanged();
        }
    }
    public int Tempo
    {
        get => _tempo;
        set
        {
            _tempo = value;
            OnPropertyChanged();
        }
    }

    public BrownianViewModel()
    {
        PrecoInical = 100;
        Volatilidade = 20;
        MediaRetorno = 1;
        Tempo = 252;
        Execute();

        GeneateBrownianCommand = new Command(Execute);
    }

    private void Execute()
    {
        Prices = GeneateBrownianMotion(Volatilidade, MediaRetorno, PrecoInical, Tempo);
    }

    private double[] GeneateBrownianMotion(double sigma, double mean, double initialPrice, int numDays)
    {
        Random rand = new();
        double[] prices = new double[numDays];
        prices[0] = initialPrice;

        for (int i = 1; i < numDays; i++)
        {
            double u1 = 1.0 - rand.NextDouble();
            double u2 = 1.0 - rand.NextDouble();
            double z = Math.Sqrt(-2.0 * Math.Log(u1)) * Math.Cos(2.0 * Math.PI * u2);

            double retornoDiario = mean + sigma * z;

            prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
        }

        return prices;
    }
}
