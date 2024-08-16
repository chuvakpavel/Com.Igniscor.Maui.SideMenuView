﻿using SampleProject.Models;
using CommunityToolkit.Mvvm.Input;

namespace SampleProject.Abstractions;

internal abstract class BaseNavigationViewModel : BaseViewModel
{
    public List<NavigationButtonItem> Items { get; set; }


    public IAsyncRelayCommand<string?> GoToCommand { get; }

    protected BaseNavigationViewModel()
    {
        Items = new List<NavigationButtonItem>();
        GoToCommand = new AsyncRelayCommand<string?>(GoToPageAsync);
    }

    private static async Task GoToPageAsync(string? path)
    {
        if (!string.IsNullOrWhiteSpace(path))
        {
            await Shell.Current.GoToAsync($"/{path}");
        }
    }
}