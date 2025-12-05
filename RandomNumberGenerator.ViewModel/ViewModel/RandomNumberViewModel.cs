using RandomGenerator.Core;
using RandomNumberGenerator.ViewModel.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Input;

namespace RandomNumberGenerator.ViewModel.ViewModel
{
    public class RandomNumberViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private string _minimumNumber;
        private string _maximumNumber;
        private string _generatedRandomNumber;
        public ICommand GenerateCommand { get; }
        public event EventHandler GenerateTriggered;

        public string GeneratedRandomNumber
        {
            get => _generatedRandomNumber;
            set
            {
                _generatedRandomNumber = value;
                OnPropertyChanged(nameof(GeneratedRandomNumber));
            }
        }
        public string MinimumNumberText
        {
            get => _minimumNumber;
            set
            {
                if (_minimumNumber != value)
                {
                    _minimumNumber = value;
                    OnPropertyChanged(nameof(MinimumNumberText));
                }
            }
        }
        public string MaximumNumberText
        {
            get => _maximumNumber;
            set
            {
                if (_maximumNumber != value)
                {
                    _maximumNumber = value;
                    OnPropertyChanged(nameof(MaximumNumberText));
                }
            }
        }

        public RandomNumberViewModel()
        {
            GenerateCommand = new RelayCommand(OnGenerateCommand, CanExecuteGenerate);
        }

        private void OnGenerateCommand(object obj)
        {
            if (int.TryParse(MinimumNumberText, out int min) && int.TryParse(MaximumNumberText, out int max))
            {
                NumberGeneratorService numberGeneratorService = new NumberGeneratorService();
                var randomNumber = numberGeneratorService.GenerateRandomNumber(min, max);
                GeneratedRandomNumber = "Your random number is : " + randomNumber.ToString();
            }
            else
            {
                GeneratedRandomNumber = "Please enter valid integers";
            }
        }

        private bool CanExecuteGenerate(object obj)
        {
            return true;
        }

        private void OnPropertyChanged([CallerMemberName] string? name = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
