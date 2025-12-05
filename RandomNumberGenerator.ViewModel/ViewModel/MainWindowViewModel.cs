using System;
using System.Collections.Generic;
using System.Text;

namespace RandomNumberGenerator.ViewModel.ViewModel
{
    public class MainWindowViewModel
    {
        public RandomNumberViewModel RandomNumberViewModel { get; set; }

        public MainWindowViewModel()
        {
            RandomNumberViewModel = new RandomNumberViewModel();
        }
    }
}
