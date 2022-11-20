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
    public class DirectorWindowViewModel : ObservableRecipient
    {
        private Director selected;

        public RestCollection<Director> Directors { get; set; }
        public Director Selected
        {
            get { return selected; }
            set
            {
                if (value != null)
                {
                    selected = new Director()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();

                    isSelectedValid = true;
                    (DeleteDirectorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateDirectorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                else
                {
                    isSelectedValid = false;
                    (DeleteDirectorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateDirectorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateDirectorCommand { get; }
        public ICommand DeleteDirectorCommand { get; }
        public ICommand UpdateDirectorCommand { get; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private bool isSelectedValid;
        public DirectorWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Directors = new RestCollection<Director>("http://localhost:60038/", "director", "hub");
                CreateDirectorCommand = new RelayCommand(() =>
                {
                    Directors.Add(new Director() { Name = Selected.Name });
                });

                DeleteDirectorCommand = new RelayCommand(() =>
                {
                    Directors.Delete(Selected.Id);
                },
                    () => isSelectedValid);

                UpdateDirectorCommand = new RelayCommand(() =>
                {
                    Directors.Update(Selected);
                },
                    () => isSelectedValid);

                Selected = new Director();
                isSelectedValid = false;
                BindingOperations.EnableCollectionSynchronization(Directors, Selected);
            }
        }
    }
}
