using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MauiAppBrownian.Brownian.ViewModels;

public class BrownianViewModel : BaseViewModel
{
    public ICommand GeneateBrownianCommand { get; init; }
    public ObservableCollection<double> PrecoObserv { get; init; }

    private double _precoInical;
    private double _volatilidade;
    private double _mediaRetorno;
    private int _tempo;

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
        PrecoObserv = new ObservableCollection<double>();
        GeneateBrownianCommand = new Command(execute: () =>
        {
            var result = GeneateBrownianMotion(Volatilidade, MediaRetorno, PrecoInical, Tempo);

            foreach (var item in result)
                PrecoObserv.Add(item);
        });


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
