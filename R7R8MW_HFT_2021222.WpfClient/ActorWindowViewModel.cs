﻿using Microsoft.Toolkit.Mvvm.ComponentModel;
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
    public class ActorWindowViewModel : ObservableRecipient
    {
        private Actor selected;

        public RestCollection<Actor> Actors { get; set; }
        public Actor Selected
        {
            get { return selected; }
            set
            {
                if(value != null)
                {
                    selected = new Actor()
                    {
                        Name = value.Name,
                        Id = value.Id
                    };
                    OnPropertyChanged();

                    isSelectedValid = true;
                    (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                else
                {
                    isSelectedValid = false;
                    (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                    (UpdateActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }
        public ICommand CreateActorCommand { get; }
        public ICommand DeleteActorCommand { get; }
        public ICommand UpdateActorCommand { get; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private bool isSelectedValid;
        public ActorWindowViewModel()
        {

            if (!IsInDesignMode)
            {
                Actors = new RestCollection<Actor>("http://localhost:60038/", "actor", "hub");
                CreateActorCommand = new RelayCommand(() =>
                {
                    Actors.Add(new Actor() { Name = Selected.Name });
                });

                DeleteActorCommand = new RelayCommand(() =>
                {
                    Actors.Delete(Selected.Id);
                },
                    () => isSelectedValid);

                UpdateActorCommand = new RelayCommand(() =>
                {
                    Actors.Update(Selected);
                },
                    () => isSelectedValid);

                Selected = new Actor();
                isSelectedValid = false;
                BindingOperations.EnableCollectionSynchronization(Actors, Selected);
            }
        }
    }
}
