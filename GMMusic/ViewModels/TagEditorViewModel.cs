using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GMMusic.ViewModels.Base;
using GMMusic.Models;
using GMMusic.Infrastructure;
using GMMusic.Infrastructure.Commands;


namespace GMMusic.ViewModels
{
    internal class TagEditorViewModel : ViewModel
    {
        #region Свойство заголовока окна

        private string _Title = "Тэг";

        /// <summary>Заголовок окна</summary>

        public string Title
        {
            get => _Title;
            set => Set(ref _Title, value);
        }

        #endregion

        #region Свойство изменяемого тэга

        private Tag _ThisTag;

        /// <summary>Изменяемый тэг</summary>

        public Tag ThisTag
        {
            get => _ThisTag;
            set => Set(ref _ThisTag, value);
        }

        #endregion

        public TagEditorViewModel() { }
    }
}
