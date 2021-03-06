﻿using System;
using System.Collections.Generic;
using ListOfGoods.Infrastructure.Constants;
using ListOfGoods.Infrastructure.DependencyService;
using Xamarin.Forms;

namespace ListOfGoods.CustomControls
{
    public class SearchPictureResultsControl : ScrollView
    {
        private int _pictureWidth_Mobile = 100;
        private int _pictureWidth_Desctop = 200;
        private int _maxDisplayWidth = 500;
        private double _deviceWidth;
        private int _margin = 50;
        private int _grid_spacing = 10;
        public SearchPictureResultsControl(List<string> images, double deviceWidth)
        {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.CenterAndExpand;
            _deviceWidth = deviceWidth - (_margin * 2);

            var countOfColumn = getCountOfColumn();

            var countOfRow = getCountOfRow(countOfColumn, images.Count);
            var grid = getGrid(countOfRow, countOfColumn);

            var imageIndex = 0;
            var imageWidth = getImageWidth(_deviceWidth);
            for (int i = 0; i < countOfRow; i++)
            {
                for (int j = 0; j < countOfColumn; j++)
                {
                    var image = getImage(images, imageIndex, imageWidth);
                    if (image == null)
                    {
                        break;
                    }

                    grid.Children.Add(image, j, i);
                    imageIndex++;
                }
            }
            Content = grid;
        }

        private Image getImage(List<string> images, int index, double width)
        {
            if (images.Count > index)
            {
                var image = new Image
                {
                    IsOpaque = false,
                    Source = ImageSource.FromUri(new Uri(images[index])),
                    WidthRequest = width,
                    HeightRequest = width - _grid_spacing,
                    VerticalOptions = LayoutOptions.Center,
                    HorizontalOptions = LayoutOptions.Center,
                    Aspect = Aspect.AspectFill
                };
                image.GestureRecognizers.Add(new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        MessagingCenter.Send<SearchPictureResultsControl, string>(this, MessagingCenterConstants.PictureSelected, images[index]);
                        await image.ScaleTo(0.9, 100);
                        await image.ScaleTo(1, 100);
                    })
                });
                return image;
            }
            return null;
        }

        private int getCountOfColumn()
        {
            var imageWidth = getImageWidth(_deviceWidth);

            var countOfColumn = (int)_deviceWidth / imageWidth;
            return countOfColumn;
        }

        private int getCountOfRow(int columnCount, int pictureCount)
        {
            return pictureCount / columnCount;
        }

        private int getImageWidth(double displayWidth)
        {

            return displayWidth > _maxDisplayWidth
                ? _pictureWidth_Desctop
                : _pictureWidth_Mobile;
        }

        private Grid getGrid(int countOfRow, int countOfColumn)
        {
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                ColumnSpacing = _grid_spacing,
                RowSpacing = _grid_spacing
            };
            for (int i = 0; i < countOfColumn; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            for (int i = 0; i < countOfRow; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition());
            }
            return grid;
        }
    }
}
