﻿using Adventures.NetStandard.Common.Interfaces;
using CsvEditSharp.Interfaces;
using System;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace CsvEditSharp.Commands
{
    public class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;

        [Dependency] public IUnityContainer IocContainer { get; set; }

        [Dependency] public IMainViewModel ViewModel { get; set; }

        [Dependency] public IMainWindow Window { get; set; }

        [Dependency] public StartupEventArgs StartupArgs { get; set; }



        public virtual bool CanExecute(object parameter) { return true; }

        public virtual void Execute(object parameter)
        {
        }

        public void InvokeCommand(string commandName, object para)
        {
            var runConfigCmd = IocContainer.Resolve<ICommand>(commandName);
            runConfigCmd.Execute(para);
        }
    }
}