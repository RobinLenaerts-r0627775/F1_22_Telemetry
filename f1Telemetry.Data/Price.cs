using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace f1Telemetry.Data;

public class Price : INotifyPropertyChanged
{
    private double _askPrice;
    private double _bidPrice;
    private double _spread;

    public Price(double askPrice, double bidPrice)
    {
        _askPrice = askPrice;
        _bidPrice = bidPrice;
    }

    public double AskPrice
    {
        get => _askPrice;
        set => SetProperty(ref _askPrice, value);
    }

    public double BidPrice
    {
        get => _bidPrice;
        set => SetProperty(ref _bidPrice, value);
    }

    public double Spread => _askPrice - _bidPrice;

    public event PropertyChangedEventHandler PropertyChanged;

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new
                         PropertyChangedEventArgs(propertyName));
    }

    bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string
                                                     propertyName = null)
    {
        if (Equals(storage, value))
        {
            return false;
        }

        storage = value;
        OnPropertyChanged(propertyName);
        return true;
    }
} 