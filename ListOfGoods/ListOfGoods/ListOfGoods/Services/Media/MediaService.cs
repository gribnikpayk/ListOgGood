using System;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using Xamarin.Forms;

namespace ListOfGoods.Services.Media
{
    public class MediaService:IMediaService
    {
        public async Task<MediaFile> TakePhotoFromGalleryAsync()
        {
            if (await PermissionProccesAsync(Permission.Storage) == PermissionStatus.Granted)
            {
                MediaFile mediaFile = await CrossMedia.Current.PickPhotoAsync(new PickMediaOptions { CompressionQuality = 70, PhotoSize = PhotoSize.Medium });
                return mediaFile;
            }
            return string.Empty;
        }

        public async Task<MediaFile> TakePhotoFromCameraAsync()
        {
            if (await PermissionProccesAsync(Permission.Camera) == PermissionStatus.Granted)
            {
                try
                {
                    MediaFile mediaFile = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions { AllowCropping = true, CompressionQuality = 70, PhotoSize = PhotoSize.Medium });
                    return mediaFile;
                }
                catch (Exception e)
                {
                    return string.Empty;
                }
            }
            return string.Empty;
        }

        private async Task<PermissionStatus> PermissionProccesAsync(Permission permission)
        {
            var status = PermissionStatus.Unknown;

            status = await CrossPermissions.Current.CheckPermissionStatusAsync(permission);
            if (status != PermissionStatus.Granted)
            {
                if (Device.OS != TargetPlatform.iOS)
                {
                    status = (await CrossPermissions.Current.RequestPermissionsAsync(permission))[permission];
                }
                else
                {
                    var iosStatus = (await CrossPermissions.Current.RequestPermissionsAsync(permission))[permission];
                    if (iosStatus != PermissionStatus.Granted)
                    {
                        //ShowErrorPopUp(permission, userDialogs);
                    }
                    return status;
                }
            }
            return status;
        }
    }
}
