﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GMMusic.Models
{
    public class Track: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public Track() { }

        public Track(string name, TimeSpan duration, string path)
        {
            Id = -1;
            Name = name;
            Duration = duration;
            SourcePath = path;
        }

        private int _Id;
        public int Id
        {
            get => _Id;
            set => Set(ref _Id, value);
        }

        private string _Name;
        public string Name
        {
            get => _Name;
            set => Set(ref _Name, value);
        }

        private TimeSpan _Duration;
        public TimeSpan Duration
        {
            get => _Duration;
            set => Set(ref _Duration, value);
        }
        
        private string _SourcePath;
        public string SourcePath
        {
            get => _SourcePath;
            set => Set(ref _SourcePath, value);
        }

        public virtual ObservableCollection<Tag> Tags { get; set; } = new ObservableCollection<Tag>();
        public virtual ObservableCollection<Playlist> Playlists { get; set; } = new ObservableCollection<Playlist>();

        public override string ToString()
        {
            return Name;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }

        public void Copy(Track track)
        {
            Name = track.Name;
            Duration = track.Duration;
            SourcePath = track.SourcePath;
        }
    }
}
