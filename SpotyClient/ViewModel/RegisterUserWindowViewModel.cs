using Microsoft.Win32;
using ModelsApi;
using SpotyClient.Components;
using SpotyClient.Tools;
using SpotyClient.View;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;



namespace SpotyClient.ViewModel
{
    public class RegisterUserWindowViewModel : Notify
    {
        private byte[] imageByte;
        public byte[] ImageByte
        {
            get => imageByte;
            set
            {
                imageByte = value;
                SignalChanged();
            }
        }

        private byte[] imageBitMap;
        public byte[] ImageBitMap
        {
            get => imageBitMap;
            set
            {
                imageBitMap = value;
                SignalChanged("ImageBitMap");
            }
        }

        public List<UserApi> users { get; set; }
        public UserApi AddUser { get; set; }
        public CustomCommand SaveUser { get; set; }
        public CustomCommand SelectImage { get; set; }
        public CustomCommand Back { get; set; }
        public string PasswordConfirm { get; set; }


        public RegisterUserWindowViewModel(UserApi user)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            Task.Run(GetListUsers);
            if (user == null)
            {
                AddUser = new UserApi();
            }
            else
            {
                AddUser = new UserApi
                {
                    Id = user.Id,
                    Email = user.Email,
                    Name = user.Name,
                    Password = user.Password,
                    Image = user.Image
                };
            }
            SaveUser = new CustomCommand(() =>
            {
                if (AddUser.Password == PasswordConfirm)
                {
                    if (AddUser.Id == 0)
                    {
                        Task.Run(CreateNewUser);
                        Thread.Sleep(200);
                        Task.Run(GetListUsers);
                    }
                    else
                        Task.Run(EditUsers);

                    MainWindow mw = new MainWindow();
                    mw.Show();

                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window.DataContext == this)
                            CloseWin(window);
                    }
                }
                else
                    MessageBox.Show("Чёт с паролем не так");
            });
            
            SelectImage = new CustomCommand(() =>
            {
                
                var res = ofd.ShowDialog();
                if (res == true)
                {
                    try
                    {
                        
                        //ImageBitMap = new BitmapImage(new Uri(ofd.FileName));
                        ImageBitMap = ConvertBitmapSourceToByteArray(new BitmapImage(new Uri(ofd.FileName)));
                            
                        //ImageBitMap = LoadImage(t);

                        
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Код ошибки: Image Error", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            });

            Back = new CustomCommand(() =>
            {
                MainWindow mw = new MainWindow();
                mw.Show();
                foreach (Window window in Application.Current.Windows)
                {
                    if (window.DataContext == this)
                        CloseWin(window);
                }
            });
        }

        #region
        //public static ImageSource LoadImage(string url)
        //{
        //    var img = new BitmapImage();
        //    using (var stream = new FileStream(url, FileMode.Open))
        //    {
        //        img.BeginInit();
        //        img.CacheOption = BitmapCacheOption.OnLoad;
        //        img.StreamSource = stream;
        //        img.UriSource = new Uri(url, UriKind.Absolute);
        //        stream.Close();
        //        img.EndInit();
        //    }
        //    return img;
        //}

        public byte[] getJPGFromImageControl(BitmapImage imageC)
        {
            MemoryStream memStream = new MemoryStream();
            JpegBitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(imageC));
            encoder.Save(memStream);
            return memStream.ToArray();
        }

        public static byte[] ConvertBitmapSourceToByteArray(BitmapSource image)
        {
            byte[] data;
            BitmapEncoder encoder = new JpegBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }
            return data;
        }


        private static BitmapImage LoadImage(byte[] imageData)
        {
            if (imageData == null || imageData.Length == 0) return null;
            var image = new BitmapImage();
            using (var mem = new MemoryStream(imageData))
            {
                mem.Position = 0;
                image.BeginInit();
                image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                image.CacheOption = BitmapCacheOption.OnLoad;
                image.UriSource = null;
                image.StreamSource = mem;
                image.EndInit();
            }
            image.Freeze();
            return image;
        }



        #endregion

        public void CloseWin(object obj)
        {
            Window win = obj as Window;
            win.Close();
        }

        public async Task EditUsers()
        {
            await Api.PutAsync<UserApi>(AddUser, "User");
        }

        public async Task CreateNewUser()
        {
            await Api.PostAsync<UserApi>(AddUser, "User");
        }

        public async Task GetListUsers()
        {
            var result = await Api.GetListAsync<UserApi[]>("User");
            users = new List<UserApi>(result);
            SignalChanged("users");
        }
    }
}
