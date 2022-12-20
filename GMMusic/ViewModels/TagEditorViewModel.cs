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

        #region Свойство первоначального имени тэга

        private string _PrevName;

        /// <summary>Первоначальное имя</summary>

        public string PrevName
        {
            get => _PrevName;
            set => Set(ref _PrevName, value);
        }

        #endregion

        #region Свойство первоначального цвета тэга

        private string _PrevColor;

        /// <summary>Первоначальный цвет</summary>

        public string PrevColor
        {
            get => _PrevColor;
            set => Set(ref _PrevColor, value);
        }

        #endregion

        public TagEditorViewModel()
        {

        }

        public TagEditorViewModel(Tag tag) 
        {
            ThisTag = tag;
            PrevName = tag.Name;
            _PrevColor = tag.Color;
        }
    }
}
