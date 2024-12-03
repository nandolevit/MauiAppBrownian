using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Xml.Linq;

namespace MauiAppBrownian.Brownian.ViewModels;

public class BrownianViewModel : BaseViewModel
{
    public ICommand GeneateBrownianCommand { get; init; }

    private string _precoInical;
    private string _volatilidade;
    private string _mediaRetorno;
    private string _tempo;
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
    public string PrecoInical
    {
        get => _precoInical;
        set
        {
            _precoInical = Regex.Replace(value!, @"\D+", "");
            OnPropertyChanged();
        }
    }
    public string Volatilidade
    {
        get => _volatilidade;
        set
        {
            _volatilidade = Regex.Replace(value!, @"\D+", "");
            OnPropertyChanged();
        }
    }
    public string MediaRetorno
    {
        get => _mediaRetorno;
        set
        {
            _mediaRetorno = Regex.Replace(value!, @"\D+", "");
            OnPropertyChanged();
        }
    }
    public string Tempo
    {
        get => _tempo;
        set
        {
            _tempo = Regex.Replace(value!, @"\D+", "");
            OnPropertyChanged();
        }
    }

    public BrownianViewModel()
    {
        PrecoInical = "100";
        Volatilidade = "20";
        MediaRetorno = "1";
        Tempo = "252";
        Execute();

        GeneateBrownianCommand = new Command(execute: () => Execute(),
        canExecute: () =>
        {
            var valid = !(string.IsNullOrEmpty(PrecoInical) ||
            string.IsNullOrEmpty(Volatilidade) ||
            string.IsNullOrEmpty(MediaRetorno) ||
            string.IsNullOrEmpty(Tempo));

            return valid;
        });
        this.PropertyChanged += CanRefresh!;
    }

    private void Execute()
    {
        var sigma = Convert.ToDouble(Volatilidade);
        var mean = Convert.ToDouble(MediaRetorno);
        var initial = Convert.ToDouble(PrecoInical);
        var numDays = Convert.ToInt32(Tempo);

        Prices = GeneateBrownianMotion(sigma, mean, initial, numDays);
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

            double retornoDiario = (mean / 100) + (sigma / 100) * z;

            prices[i] = prices[i - 1] * Math.Exp(retornoDiario);
        }

        return prices;
    }
    private void CanRefresh(object sender, PropertyChangedEventArgs args)
    {
        (GeneateBrownianCommand as Command)!.ChangeCanExecute();
    }
}
