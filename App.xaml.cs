﻿using StudentsCollection.ViewModels;
using StudentsCollection.Views;

namespace StudentsCollection
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
    }
}