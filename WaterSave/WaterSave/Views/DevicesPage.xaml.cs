﻿using System;
using WaterSave.Helpers;
using WaterSave.Models;
using WaterSave.ViewModels;

using Xamarin.Forms;

namespace WaterSave.Views
{
    public partial class DevicesPage : ContentPage
    {
        DevicesViewModel viewModel;

        public DevicesPage()
        {
            InitializeComponent();

            BindingContext = viewModel = new DevicesViewModel();


            MessagingCenter.Subscribe<MessagingCenterAlert>(this, "messageDevice", (MessagingCenterAlert message) =>
            {
                DisplayAlert(message.Title, message.Message, message.Cancel);
            });
        }

        protected void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            InstancesListView.SelectedItem = null;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (viewModel.Instances.Count == 0)
                viewModel.LoadItemsCommand.Execute(null);
        }
    }
}
