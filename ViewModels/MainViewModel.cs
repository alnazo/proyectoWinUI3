using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ProyectoAplicacion.dto;
using ProyectoAplicacion.Helpers;
using ProyectoAplicacion.Views;

namespace ProyectoAplicacion.ViewModels;

public class MainViewModel : ObservableObject
{
    private int _pageSize = 5;
    private int _pageNumber;
    private int _pageCount;
    private ObservableCollection<Sitio> _sitio;
    private readonly PaginationHelper<Sitio> _paginationHelper;

    public MainViewModel()
    {
        _paginationHelper = new PaginationHelper<Sitio>();

        FirstAsyncCommand = new AsyncRelayCommand(async () => await GetSitios(1, _pageSize), () => _pageNumber != 1);
        PreviousAsyncCommand = new AsyncRelayCommand(async () => await GetSitios(_pageNumber - 1, _pageSize), () => _pageNumber > 1);
        NextAsyncCommand = new AsyncRelayCommand(async () => await GetSitios(_pageNumber + 1, _pageSize), () => _pageNumber < _pageCount);
        LastAsyncCommand = new AsyncRelayCommand(async () => await GetSitios(_pageCount, _pageSize), () => _pageNumber != _pageCount);


        Refresh();
    }


    public List<int> PageSizes => new() { 5, 10, 20 };

    public int PageSize
    {
        get => _pageSize;
        set
        {
            SetProperty(ref _pageSize, value);
            Refresh();
        }
    }

    public int PageNumber
    {
        get => _pageNumber;
        private set => SetProperty(ref _pageNumber, value);
    }

    public int PageCount
    {
        get => _pageCount;
        private set => SetProperty(ref _pageCount, value);
    }

    public ObservableCollection<Sitio> Sitios
    {
        get => _sitio;
        set => SetProperty(ref _sitio, value);
    }

    public IAsyncRelayCommand FirstAsyncCommand
    {
        get;
    }

    public IAsyncRelayCommand PreviousAsyncCommand
    {
        get;
    }

    public IAsyncRelayCommand NextAsyncCommand
    {
        get;
    }

    public IAsyncRelayCommand LastAsyncCommand
    {
        get;
    }

    private async Task GetSitios(int pageNumber, int pageSize)
    {
        _sitio = MainPage.logica.listaSitios;
        PageCount = (int)Math.Ceiling((double)_sitio.Count / pageSize);
        PageNumber = pageNumber;
        Sitios = _paginationHelper.GetPage(_sitio, pageSize, pageNumber);
        
        FirstAsyncCommand.NotifyCanExecuteChanged();
        PreviousAsyncCommand.NotifyCanExecuteChanged();
        NextAsyncCommand.NotifyCanExecuteChanged();
        LastAsyncCommand.NotifyCanExecuteChanged();
    }


    public void Refresh()
    {
        _pageNumber = 0;
        FirstAsyncCommand.Execute(null);
    }

}