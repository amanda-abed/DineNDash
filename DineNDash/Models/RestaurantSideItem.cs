﻿using System;
using Prism.Mvvm;

namespace DineNDash.Models
{
    public class RestaurantSideItem : BindableBase
    {
        private string _item;
        public string Item
        {
            get { return _item; }
            set { SetProperty(ref _item, value); }
        }

        public override string ToString()
        {
            return $"Item={Item}";
        }

        //public string Value()
        //{
        //    return Item;
        //}
    }
}
