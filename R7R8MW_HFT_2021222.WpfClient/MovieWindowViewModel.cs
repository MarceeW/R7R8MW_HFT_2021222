using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using R7R8MW_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace R7R8MW_HFT_2021222.WpfClient
{
    public class MovieWindowViewModel : ObservableRecipient
    {
        private Movie selected;

        public RestCollection<Movie> Movies { get; set; }
        public Movie Selected
        {
            get { return selected; }
            set
            {
                if (value != null)
                {
                    selected = new Movie()
                    {
                        Title = value.Title,
                        Id = value.Id
                    };
                    OnPropertyChanged();

                    isSelectedValid = true;
                    (DeleteMovieCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateMovieCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                else
                {
                    isSelectedValid = false;
                    (DeleteMovieCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateMovieCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateMovieCommand { get; }
        public ICommand DeleteMovieCommand { get; }
        public ICommand UpdateMovieCommand { get; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private bool isSelectedValid;
        public MovieWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Movies = new RestCollection<Movie>("http://localhost:60038/", "movie", "hub");
                CreateMovieCommand = new RelayCommand(() =>
                {
                    Movies.Add(new Movie() { Title = Selected.Title });
                });

                DeleteMovieCommand = new RelayCommand(() =>
                {
                    Movies.Delete(Selected.Id);
                },
                    () => isSelectedValid);

                UpdateMovieCommand = new RelayCommand(() =>
                {
                    Movies.Update(Selected);
                },
                    () => isSelectedValid);

                Selected = new Movie();
                isSelectedValid = false;
                BindingOperations.EnableCollectionSynchronization(Movies, Selected);
            }
        }
    }
}
