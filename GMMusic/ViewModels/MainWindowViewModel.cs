﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.ViewModels.Base;

namespace GMMusic.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        #region Свойство заголовока окна

        private string _Title = "Медиаплеер GMMusic";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion
    }
}
