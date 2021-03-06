﻿using System.Threading.Tasks;
using Xamarin.Forms;

namespace ListOfGoods.Infrastructure.Animations
{
    public static class AnimationExtensions
    {
        public static void ScaleEffect(this View view)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                await view.ScaleTo(0.95, 100);
                await view.ScaleTo(1, 100);
            });
        }

        public static void ItemDeleteFromListAffect(this View view)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                view.FadeTo(0);
                view.TranslateTo(0, 100);
            });
        }

        public static void ItemAddToListAffect(this View view)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                view.FadeTo(1,100);
                view.TranslateTo(0, 0,100);
            });
        }
    }
}
